﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private AudioClip energyUp;

    [SerializeField] private Text energyTxt;
    private int energy = 0;
    private int half = 0;

    [SerializeField] private GameObject MenuPause;

    [SerializeField] private Image P;
    [SerializeField] private Sprite up;
    [SerializeField] private Sprite down;
    [SerializeField] private Sprite left;
    [SerializeField] private Sprite right;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    private void Start()
    {
        MenuPause.SetActive(false);
        ChangeEnergy(0);
    }



    //------------------------------------------------------------------------ MENU PAUSE ------------------------------------------------------------------------



    public void Resume()
    {
        MenuPause.SetActive(false);
        GameManager.Instance.ChangeState(GameManager.GameState.InGame);
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
        MenuPause.SetActive(setActive);
    }



    //------------------------------------------------------------------------ INGAME ------------------------------------------------------------------------



    public void ChangeEnergy(int amount, bool semi = false)
    {
        if (semi)
        {
            half++;
            if (half >= 2)
            {
                half -= 2;
                energy++;
                AudioManager.Instance.PlayClip(energyUp);
            }
        }
        else
        {
            energy += amount;
            if (amount > 0)
            {
                AudioManager.Instance.PlayClip(energyUp);
            }
            if (energy < 0)
            {
                energy = 0;
            }
        }
        energyTxt.text = " X" + energy;
    }
    

    public void Fgravity()
    {
        Vector2 actualGravity = GameManager.Instance.SendGravityDirection();
        if (actualGravity == Vector2.up)
        {
            P.sprite = up;
        }
        if (actualGravity == Vector2.down)
        {
            P.sprite = down;
        }
        if (actualGravity == Vector2.left)
        {
            P.sprite = left;
        }
        if (actualGravity == Vector2.right)
        {
            P.sprite = right;
        }
    }



    //------------------------------------------------------------------------ MENU PRINCIPAL ------------------------------------------------------------------------


    public void Play()
    {
        SceneManager.LoadScene("Main");
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
}
