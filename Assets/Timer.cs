using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Text timerText;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float timeSinceStart = Time.time - startTime;

        string minutes = ((int)timeSinceStart / 60).ToString();
        string seconds = (timeSinceStart % 60).ToString();
    }
}
