using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private AudioClip energyUp;
    [SerializeField] private Text chargesLeft;
    [SerializeField] private Text energyTxt;
    [SerializeField] private int energy = 4;
    [SerializeField] private int expectedELeft;

    private float remplissage = 0;

    [SerializeField] private GameObject menuPause;
    [SerializeField] private GameObject menuGameOver;
    [SerializeField] private GameObject scoreBoard;
    [SerializeField] private CarteMere carteMere;
    [SerializeField] private Image Arrow;
    [SerializeField] private GameObject badge1;
    [SerializeField] private GameObject badge2;
    [SerializeField] private GameObject badge3;
    [SerializeField] private Text timerText;


    //--------------------------------- Pour le ScoreBoard ------------------------------------------------------
    [SerializeField] private Text timePassed;
    [SerializeField] private float expectedTPassed;
    float timeSinceStart;
    private float startTime;
    private bool finished = false;
    bool condition1 = false;
    bool condition2 = false;
    bool condition3 = false;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    private void Start()
    {
        menuPause.SetActive(false);
        ChangeEnergy(0);
        timerText.color = Color.blue;
        startTime = Time.time;
    }

    private void Update()
    {
        InGameTimer();
    }



    //------------------------------------------------------------------------ MENU PAUSE ------------------------------------------------------------------------



    public void Resume()
    {
        menuPause.SetActive(false);
        GameManager.Instance.ChangeState(GameManager.GameState.InGame);
        Debug.Log("JE SUIS CLICKED");
    }


    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        GameManager.Instance.ChangeState(GameManager.GameState.InGame);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
        GameManager.Instance.ChangeState(GameManager.GameState.MainMenu);
    }

    public void AfficherMenuPause(bool setActive)
    {
        menuPause.SetActive(setActive);
    }

    public void AfficherGameOver(bool setActive)
    {
        menuGameOver.SetActive(setActive);
    }



    //------------------------------------------------------------------------ INGAME ------------------------------------------------------------------------



    public void ChangeEnergy(float amount)
    {
        remplissage += amount;
        while (remplissage >= 1)
        {
            remplissage -= 1;
            energy++;
            AudioManager.Instance.PlayClip(energyUp);
        }
        if (amount < 0)
        {
            remplissage++;
        }
        if (energy < 0)
        {
            energy = 0;
        }
        EnergyMask.Instance.ChangeMaskSize(remplissage / 1);
        Debug.Log(remplissage / 3);
        energyTxt.text = " X" + energy;
    }
    
    public int SendEnergy()
    {
        return energy;
    }

    public void Fgravity()
    {
        Vector2 actualGravity = GameManager.Instance.SendGravityDirection();
        if (actualGravity == Vector2.up)
        {
            Arrow.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (actualGravity == Vector2.down)
        {
            Arrow.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (actualGravity == Vector2.left)
        {
            Arrow.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        if (actualGravity == Vector2.right)
        {
            Arrow.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }



    //------------------------------------------------------------------------ MENU PRINCIPAL ------------------------------------------------------------------------


    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    

    public void Quit()
    {
        Application.Quit();
    }

    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
        GameManager.Instance.ChangeState(GameManager.GameState.InGame);
    }


    
    //------------------------------------------------------------------------ MENU VICTOIRE ------------------------------------------------------------------------


    //-------------------------------------------------------- SCORE BOARD ---------------------------------------------------------

    public void AfficherScoreBoard(bool setActive)
    {
        scoreBoard.SetActive(setActive);
    }

    public void ActualEnergy()
    {
        int actualEnergy = energy;
        chargesLeft.text = actualEnergy.ToString() + "/" + expectedELeft;

        if(actualEnergy >= expectedELeft)
        {
            chargesLeft.color = Color.yellow; 
            condition2 = true;
        }

        if (actualEnergy < expectedELeft)
        {
            chargesLeft.color = Color.red;    
        }
    }

    public void InGameTimer()
    {
        if (finished)
            return;

        timeSinceStart = Time.time - startTime;

        string minutes = ((int)timeSinceStart / 60).ToString();
        string seconds = (timeSinceStart % 60).ToString("f2");
        float lastTime = timeSinceStart;
        timerText.text = minutes + ": " + seconds;
    }

    public void TimerAtTheEnd()
    {
        finished = true;
        timerText.color = Color.red;
        timePassed.text = timeSinceStart.ToString() + "/" + expectedTPassed.ToString();

        if (timeSinceStart > expectedTPassed)
        {
            timePassed.color = Color.red;
        }
        else if (timeSinceStart < expectedTPassed)
        {
            condition3 = true;
            
        }
    }

    public void ScoreDisplay()
    {
        int starCount = 0;

        if (carteMere.collected)
        {
            condition1 = true;
            if (condition1)
            {
                starCount++;
                
            }            
        }

        if (condition2)
        {
            starCount++;

        }

        if (condition3)
        {
            starCount++;

        }
        
        if (starCount == 1)
        {
            badge1.SetActive(true);
        }
        else if (starCount == 2)
        {
            badge1.SetActive(true);
            badge2.SetActive(true);
        }
        else if (starCount == 3)
        {
            badge1.SetActive(true);
            badge2.SetActive(true);
            badge3.SetActive(true);
        }

    }

}
