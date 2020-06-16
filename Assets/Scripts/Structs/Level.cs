using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour // Emile
{
    private Button levelButton;
    [SerializeField] private List<Image> cartes = new List<Image>();
    [SerializeField] private GameObject cadenas;

    private Color lockedColor = new Color(0.2f, 0.2f, 0.2f);

    private void Awake()
    {
        levelButton = GetComponentInChildren<Button>();
    }


    public void EnableButton(bool clear)
    {
        if (clear)
        {
            this.levelButton.interactable = true;
            Debug.Log("Bouton activé");
            levelButton.GetComponent<Image>().color = Color.white;
        }
        else
        {
            this.levelButton.interactable = false;
            Debug.Log("Bouton désactivé");
            levelButton.GetComponent<Image>().color = lockedColor;
            cadenas.SetActive(true);
        }
    }
}
