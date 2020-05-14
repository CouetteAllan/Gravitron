using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private Image level;
    [SerializeField] private Button playLevel;
    [SerializeField] private List<Image> cartes = new List<Image>();

    private bool isCleared = true;

    private Color lockedColor = new Color(0.2f, 0.2f, 0.2f);



 

    public void ButtonColor()
    {
        if (!isCleared)
        {
            this.level.color = lockedColor;
            playLevel.enabled = false;
        }
        else
        {
            level.color = Color.white;
            playLevel.enabled = true;
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
