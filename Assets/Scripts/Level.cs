using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    private Button levelButton;
    [SerializeField] private List<Image> cartes = new List<Image>();
    

    private Color lockedColor = new Color(0.2f, 0.2f, 0.2f);

    private void Start()
    {
        levelButton = GetComponent<Button>();
    }


    public void EnableButton(bool clear)
    {
        if (clear)
        {
            
        }
        else
        {

        }
    }
}
