using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zap : MonoBehaviour
{
    [SerializeField]
    private CamShake shake;
    [SerializeField]
    private Timer t;

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
        this.shake.Shake();
        JeanMichelTesteur jean = collision.GetComponent <JeanMichelTesteur>();
        if (jean != null)
        {
            t.Finish();
            Destroy(jean.gameObject);
        }
            
    }
}
