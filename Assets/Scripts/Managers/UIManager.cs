using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private AudioClip energyUp;

    [SerializeField] private Text energyTxt;
    [SerializeField] private int energy = 4;
    private float remplissage = 0;

    [SerializeField] private GameObject menuPause;
    [SerializeField] private GameObject menuGameOver;
    [SerializeField] private GameObject menuVictoire;

    [SerializeField] private Image P;


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

    public void Exit()
    {
        SceneManager.LoadScene(1);
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
            P.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (actualGravity == Vector2.down)
        {
            P.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (actualGravity == Vector2.left)
        {
            P.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        if (actualGravity == Vector2.right)
        {
            P.transform.rotation = Quaternion.Euler(0, 0, 90);
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

    public void AfficherMenuVictoire(bool setActive)
    {
        menuVictoire.SetActive(setActive);
    }
}
