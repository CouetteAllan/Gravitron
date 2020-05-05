using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private bool active = false;
    public bool Active
    {
        get { return active; }
        set { active = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        JeanMichelTesteur jean = collision.GetComponent<JeanMichelTesteur>();
        if (jean == null && active == true)
        {
            active = false;
        }
        if (jean == null)
        {
            active = true;
        }
    }
}
