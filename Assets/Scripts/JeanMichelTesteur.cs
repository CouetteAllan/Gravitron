using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeanMichelTesteur : MonoBehaviour
{
    #region Variables Jean Michel
    [HideInInspector]
    public JeanBaseState currentState;
    public readonly IdleState idleState = new IdleState();
    public readonly WalkingState walkingState = new WalkingState();
    public readonly JumpingState jumpingState = new JumpingState();
    public readonly GravityState gravityState = new GravityState();

    private Vector2 move;
    public Vector2 Move
    {
        get { return move; }
    }

    [HideInInspector] public bool triedWithoutEnergy = false;

    private float rotateGoal;
    public float RotateGoal
    {
        get { return rotateGoal; }
    }
    [SerializeField]
    private AudioClip step;

    [SerializeField]
    private float speed;
    public float Speed
    {
        get { return speed; }
    }
    [SerializeField]
    private float jump = 3500;
    public float Jump
    {
        get { return jump; }
    }
    float deplacement;

    public bool isFalling = false;
    
    private Rigidbody2D rb2d;
    public Rigidbody2D Rigidbody2D
    {
        get { return rb2d; }
    }

    private bool facingRight = true;
    [SerializeField]
    private Animator zwoshAnimator;

    public Animator ZwoshAnim
    {
        get { return zwoshAnimator; }
    }


    private float deathLateTimer;

    private bool isDead = false;
    #endregion
    [SerializeField] private CamShake shake;


    void Start()
    {
        TransitionToState(idleState);
        rb2d = this.GetComponent<Rigidbody2D>();
    }
    
    
    void Update()
    {
        if (isDead)
        {
            GameManager.Instance.LateGameOver(deathLateTimer); //Change le GameState en GameOver après un certains temps pour laisser quelques temps aux anims de se jouer
        }
        MoveWithGravity();

        if (triedWithoutEnergy)
        {
            this.Dead(1); //GameOver après 2s pour laisser le temps à l'animation de se jouer
        }
        
        #region Input pour la Gravité

        if (!isFalling)//Empêche le fait de pouvoir changer de gravité lorsqu'on tombe en mode gravité 
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (GameManager.Instance.SendGravityDirection() != Vector2.down)
                {
                    TransitionToState(gravityState);
                    GameManager.Instance.ChangeGravity(GameManager.Gravity.Down);
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (GameManager.Instance.SendGravityDirection() != Vector2.up)
                {
                    TransitionToState(gravityState);
                    GameManager.Instance.ChangeGravity(GameManager.Gravity.Up);
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (GameManager.Instance.SendGravityDirection() != Vector2.left)
                {
                    TransitionToState(gravityState);
                    GameManager.Instance.ChangeGravity(GameManager.Gravity.Left);
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (GameManager.Instance.SendGravityDirection() != Vector2.right)
                {
                    TransitionToState(gravityState);
                    GameManager.Instance.ChangeGravity(GameManager.Gravity.Right);
                }
            }
        }
        
        #endregion


        if (Input.GetKeyDown(KeyCode.Escape)) //Menu pause quand on appuie sur Echap
        {
            if (GameManager.Instance.GetGameState() == GameManager.GameState.InGame)
            {
                GameManager.Instance.ChangeState(GameManager.GameState.Pause);
            }
            else
            {
                GameManager.Instance.ChangeState(GameManager.GameState.InGame);
            }
        }

        Debug.Log(GameManager.Instance.GetGameState().ToString());
        currentState.Update(this);
        

        if (deplacement > 0 && !facingRight)
        {
            // ... flip JMT
            Flip();
        }
        
        else if (deplacement < 0 && facingRight)
        {
            
            Flip();
        }
    }

    

    

    public void TransitionToState(JeanBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    private void MoveWithGravity()
    {
        deplacement = Input.GetAxis("Horizontal");
        if (Vector2.left == GameManager.Instance.SendGravityDirection())//déplacement sur le mur de gauche
        {
             move = new Vector2(0 , -deplacement);
            this.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        if (Vector2.right == GameManager.Instance.SendGravityDirection())//déplacement sur le mur de droite
        {
             move = new Vector2(0 , deplacement);
            this.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (Vector2.up == GameManager.Instance.SendGravityDirection())//déplacement sur le mur du haut
        {
             move = new Vector2(-deplacement, 0);
            this.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (Vector2.down == GameManager.Instance.SendGravityDirection())//déplacement sur le mur du bas
        {
             move = new Vector2(deplacement, 0);
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        
    }

    public void Dead(float time)
    {
        this.isDead = true;
        this.shake.Shake();
        deathLateTimer = time;
        
    }

    public void PlayClipJMT(string sound) //Permet de jouer les différents sons tels que les bruits de pas ou de saut en accord avec ses anims
    {
        switch (sound)
        {
            case "step":
                AudioManager.Instance.Play(sound);
                break;
            case "jump":
                AudioManager.Instance.Play(sound);
                break;
        }
        
    }
    private void Flip()
    {
        
        facingRight = !facingRight;

        
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }




}
