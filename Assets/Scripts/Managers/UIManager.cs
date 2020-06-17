using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //Sky
    public static UIManager Instance;
    
    [SerializeField] private Text chargesLeft;
    [SerializeField] private Image totalBattery;
    [SerializeField] private TMP_Text energyTxt;
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
    [SerializeField] private GameObject dot1;
    [SerializeField] private GameObject dot2;
    [SerializeField] private GameObject dot3;
    [SerializeField] private TMP_Text timerText;

    [SerializeField] private Canvas tuto;

    //--------------------------------- Pour le ScoreBoard ------------------------------------------------------
    [SerializeField] private Text timePassed;
    [SerializeField] private float expectedMinPassed;
    [SerializeField] private float expectedSecPassed;
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
        if (GameManager.Instance.GetGameState() == GameManager.GameState.MainMenu)
        {
            return;
        }
        ChangeEnergy(0);
        startTime = Time.time;
    }

    private void Update()
    {
        InGameTimer();
    }



    //------------------------------------------------------------------------ MENU PAUSE ------------------------------------------------------------------------


    public void Resume()
    {
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
        AudioManager.Instance.Play("PopUp");
        menuPause.SetActive(setActive);
    }

    public void AfficherGameOver(bool setActive)
    {
        AudioManager.Instance.Play("PopUp");
        menuGameOver.SetActive(setActive);
    }



    //------------------------------------------------------------------------ INGAME ------------------------------------------------------------------------



    public void ChangeEnergy(float amount)
    {
        if (GameManager.Instance.GetGameState() == GameManager.GameState.MainMenu)
        {
            return;
        }
        Debug.Log("Remplissage initial : " + remplissage);
        remplissage += amount;
        while (remplissage >= 1)
        {
            remplissage -= 1;
            energy++;
            AudioManager.Instance.Play("energyUp");
        }
        if (amount == -1)
        {
            remplissage++;
            energy--;
        }
        if (energy <= 0)
        {
            energy = 0;
            totalBattery.color = Color.red;
        }
        WaterScript.Instance.ChangeWater(energy);
        EnergyMask.Instance.ChangeMaskSize(remplissage);
        Debug.Log("remplissage de l'énergie : " + remplissage);
        energyTxt.text = " X" + energy;
    }
    
    public int SendEnergy()
    {
        return energy;
    }

    public void Fgravity()
    {
        if (GameManager.Instance.GetGameState() == GameManager.GameState.MainMenu)
        {
            return;
        }
        Vector2 actualGravity = GameManager.Instance.SendGravityDirection();
        if (actualGravity == Vector2.up)
        {
            Arrow.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (actualGravity == Vector2.down)
        {
            Arrow.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (actualGravity == Vector2.left)
        {
            Arrow.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (actualGravity == Vector2.right)
        {
            Arrow.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    }



    //------------------------------------------------------------------------ MENU PRINCIPAL ------------------------------------------------------------------------


    public void PlayLastLevelUnlock()
    {
        ChangeScene(LevelList.lastLevelUnlock);
    }


    public void Quit()
    {
        Application.Quit();
    }

    public void LoadLevelList()
    {
        DontDestroyOnLoad(gameObject);
        ChangeScene(0);

        GameObject mainMenu = GameObject.Find("MenuPrincipal");
        if (mainMenu == null)
        {
            Debug.LogError("mainMenu object not found!!");
            Destroy(gameObject);
            return;
        }
        mainMenu.SetActive(false);

        GameObject levelList = GameObject.Find("ListeNiveaux");
        if (levelList == null)
        {
            Debug.LogError("levelList object not found!!");
            Destroy(gameObject);
            return;
        }
        levelList.SetActive(true);
        Destroy(gameObject);
    }

    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
        GameManager.Instance.ChangeState(GameManager.GameState.InGame);
    }


    
    //------------------------------------------------------------------------ MENU VICTOIRE ------------------------------------------------------------------------

    public void nextLevel()
    {
        int nextLevelIndex = FindObjectOfType<Sortie>().GetIndex() + 1;
        ChangeScene(nextLevelIndex);
    }


    //-------------------------------------------------------- SCORE BOARD ---------------------------------------------------------

    public void AfficherScoreBoard(bool setActive)
    {
        AudioManager.Instance.Play("PopUp");
        if (tuto != null)
        {
            tuto.enabled = false;
        }
        scoreBoard.SetActive(setActive);
    }

    public void ActualEnergy()
    {
        int actualEnergy = energy;
        chargesLeft.text = actualEnergy.ToString() + "/" + expectedELeft;

        if(actualEnergy >= expectedELeft)
        { 
            condition2 = true;
        }

        if (actualEnergy < expectedELeft)
        {
            chargesLeft.color = Color.red;    
        }
    }

    public void InGameTimer()
    {
        if (GameManager.Instance.GetGameState() == GameManager.GameState.MainMenu)
        {
            return;
        }
        if (finished)
            return;

        timeSinceStart = Time.time - startTime;

        string minutes = ((int)timeSinceStart / 60).ToString();
        string seconds = (timeSinceStart % 60).ToString("f2");
        timerText.text = minutes + ": " + seconds;
    }

    public void TimerAtTheEnd()
    {
        finished = true;
        timerText.color = Color.red;
        timePassed.text = ((int)timeSinceStart /60).ToString() + ":" + (timeSinceStart % 60).ToString("f2") + 
                          "/" + (expectedMinPassed/60).ToString() + ":" + expectedSecPassed.ToString();

        if (timeSinceStart > (expectedMinPassed + expectedSecPassed))
        {
            timePassed.color = Color.red;
        }
        else if (timeSinceStart < (expectedMinPassed + expectedSecPassed))
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
            dot1.SetActive(false);
        }
        else if (starCount == 2)
        {
            badge1.SetActive(true);
            badge2.SetActive(true);
            dot1.SetActive(false);
            dot2.SetActive(false);
        }
        else if (starCount == 3)
        {
            badge1.SetActive(true);
            badge2.SetActive(true);
            badge3.SetActive(true);
            dot1.SetActive(false);
            dot2.SetActive(false);
            dot3.SetActive(false);
        }

    }

}
