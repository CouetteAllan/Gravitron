using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector2 localGravity;
    private Vector2 firstGravity;
    

    private Vector2 direction;
    

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("Le GameManager est null lulz");
            }
            return instance;
        }
    }
    private GameState gameState;
    public enum GameState 
    {
        InGame,
        Pause,
        MainMenu,
        GameOver,
        Victory,
    }

    [SerializeField]
    private Gravity gravity;
    public enum Gravity
    {
        Left,
        Right,
        Down,
        Up
    }

    private void Awake()
    {
        Debug.Log(Physics2D.gravity.magnitude);
        instance = this;
        localGravity = Physics2D.gravity;
        firstGravity = localGravity;
    }

    private void Start()
    {
        FirstGravity(gravity);
        ChangeGravity(gravity);
        Physics2D.gravity = firstGravity;
    }


    public void ChangeState(GameState state)
    {
        gameState = state;
        switch (state)
        {
            case GameState.MainMenu:
                UIManager.Instance.AfficherMenuPause(false);
                break;
            case GameState.InGame:
                UIManager.Instance.AfficherMenuPause(false);
                UIManager.Instance.AfficherScoreBoard(false);
                UIManager.Instance.AfficherGameOver(false);
                UIManager.Instance.InGameTimer();
                UIManager.Instance.ActualEnergy();
                Time.timeScale = 1;
                break;
            case GameState.Pause:
                Time.timeScale = 0;
                UIManager.Instance.AfficherMenuPause(true);
                break;
            case GameState.GameOver:
                Time.timeScale = 0;
                UIManager.Instance.AfficherGameOver(true);
                UIManager.Instance.TimerAtTheEnd();
                break;
            case GameState.Victory:
                UIManager.Instance.ActualEnergy();
                UIManager.Instance.TimerAtTheEnd();
                UIManager.Instance.AfficherScoreBoard(true);
                UIManager.Instance.ScoreDisplay();
                Time.timeScale = 0;
                break;
            default:
                state = GameState.InGame;
                break;
        }
    }


    public void ChangeGravity(Gravity g)
    {
        if (UIManager.Instance.SendEnergy() > 0)
        {
            UIManager.Instance.ChangeEnergy(-1);
            AudioManager.Instance.Play("swosh");
            gravity = g;
            switch (gravity)
            {
                case Gravity.Up:
                    direction = Vector2.up;
                    break;
                case Gravity.Left:
                    direction = Vector2.left;
                    break;
                case Gravity.Right:
                    direction = Vector2.right;
                    break;
                case Gravity.Down:
                    direction = Vector2.down;
                    break;
                default:
                    direction = Vector2.down;
                    break;
            }
            Physics2D.gravity = direction * localGravity.magnitude;
            this.localGravity = Physics2D.gravity;//change la gravité
            UIManager.Instance.Fgravity();

            Levier[] leviers = FindObjectsOfType<Levier>();
            foreach (Levier l in leviers)
            {
                l.Train(gravity);
            }
        }
        else
        {
            AudioManager.Instance.Play("noEnergy");
        }
    }  

    

    public Vector2 SendGravityDirection()
    {
        Vector2 gravityDirection = this.localGravity.normalized ;
        return gravityDirection;
    }

    public GameState GetGameState()
    {
        return this.gameState;
    }

    public void LateGameOver(float time)
    {
        Invoke(nameof(GameOver), time);
    }

    private void GameOver()
    {
        ChangeState(GameState.GameOver);
    }
    
    private void FirstGravity(Gravity gravity)
    {
        switch (gravity)
        {
            case Gravity.Down:
                firstGravity = Vector2.down * localGravity.magnitude;
                break;
            case Gravity.Left:
                firstGravity = Vector2.left * localGravity.magnitude;
                break;
            case Gravity.Up:
                firstGravity = Vector2.up * localGravity.magnitude;
                break;
            case Gravity.Right:
                firstGravity = Vector2.right * localGravity.magnitude;
                break;
            default:
                firstGravity = Vector2.down * localGravity.magnitude;
                break;
        }
    }
}