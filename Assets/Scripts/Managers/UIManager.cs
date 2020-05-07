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
    private int energy = 0;
    private int half = 0;

    [SerializeField] private GameObject MenuPause;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    private void Start()
    {
        ChangeEnergy(0);
    }


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


    public void Resume()
    {
        MenuPause.SetActive(false);
    }


    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
