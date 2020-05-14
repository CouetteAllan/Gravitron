using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private Image level;
    [SerializeField] private List<Image> cartes = new List<Image>();

    private bool isCleared = false;

    private Color lockedColor = new Color(0.2f, 0.2f, 0.2f);

    private void Start()
    {
        ButtonColor();
    }

    public void Clear()
    {
        isCleared = true;
    }

    public void ButtonColor()
    {
        if (!isCleared)
        {
            this.level.color = lockedColor;
        }
        else
        {
            level.color = Color.white;
        }
    }

    public void Cacahuetes(int reward)
    {
        for (int i = 0; i < cartes.Count; i++)
        {
            if (i > reward)
            {
                cartes[i].color = lockedColor;
            }
            else
            {
                cartes[i].color = Color.white;
            }
        }
    }
}
