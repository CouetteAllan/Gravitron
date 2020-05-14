using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timerText;

    //--------------------------------- Pour le ScoreBoard -------------
    [SerializeField] private Text timePassed;
    [SerializeField] private float expectedTPassed;
    //------------------------------------------------------------------
    float timeSinceStart;
    private float startTime;
    private bool finished = false;
    // Start is called before the first frame update
    void Start()
    {
        timerText.color = Color.blue;
        startTime = Time.time;        
    }

    // Update is called once per frame
    void Update()
    {
        if (finished)
            return;

        timeSinceStart = Time.time - startTime;

        string minutes = ((int)timeSinceStart / 60).ToString();
        string seconds = (timeSinceStart % 60).ToString("f2");
        float lastTime = timeSinceStart;
        timerText.text = minutes + ": " + seconds;
    }

    public void Finish()
    {
        finished = true;
        timerText.color = Color.red;
        timePassed.text = timeSinceStart.ToString() + "/" + expectedTPassed.ToString();
        if (timeSinceStart > expectedTPassed)
        {
            timePassed.color = Color.red;
        }
    }

}
