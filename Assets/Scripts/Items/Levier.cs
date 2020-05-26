using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levier : MonoBehaviour
{

    [SerializeField] private float rotationSpeed = 1;

    private Quaternion trainedRotation;
    private Quaternion bentRotation;

    [SerializeField] private bool trained = false;
    private Orientation lastTrain;


    [SerializeField] private Orientation sens;
    private enum Orientation
    {
        up,
        right,
        down,
        left,
    }

    private void Start()
    {
        Levier[] leviers = FindObjectsOfType<Levier>();
        foreach (Levier l in leviers)
        {
            Debug.Log(l + " est dans le sens " + l.sens);
        }
        
        switch (sens)
        {
            case Orientation.right:
                trainedRotation = Quaternion.Euler(0, 0, 45);
                bentRotation = Quaternion.Euler(0, 0, 135);
                break;
            case Orientation.left:
                trainedRotation = Quaternion.Euler(0, 0, -45);
                bentRotation = Quaternion.Euler(0, 0, -135);
                break;
            case Orientation.down:
                trainedRotation = Quaternion.Euler(0, 0, 45);
                bentRotation = Quaternion.Euler(0, 0, -45);
                break;
            case Orientation.up:
                trainedRotation = Quaternion.Euler(0, 0, 135);
                bentRotation = Quaternion.Euler(0, 0, -135);
                break;
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            trained = !trained;
            CancelInvoke("ActivateLever");
            InvokeRepeating("ActivateLever", 0, Time.deltaTime);
            StopAllCoroutines();
            StartCoroutine(StopTrain());
        }
    }


    public void Train(GameManager.Gravity gravity)
    {
        switch (gravity)
        {
            case GameManager.Gravity.Down:
                if (lastTrain != Orientation.down)
                {
                    if (sens == Orientation.right || sens == Orientation.left)
                    {
                        lastTrain = Orientation.down;
                        ActivateLever();
                    }
                }
                break;
            case GameManager.Gravity.Up:
                if (lastTrain != Orientation.up)
                {
                    if (sens == Orientation.right || sens == Orientation.left)
                    {
                        lastTrain = Orientation.up;
                        ActivateLever();
                    }
                }
                break;
            case GameManager.Gravity.Left:
                if (lastTrain != Orientation.left)
                {
                    if (sens == Orientation.up || sens == Orientation.down)
                    {
                        lastTrain = Orientation.left;
                        ActivateLever();
                    }
                }
                break;
            case GameManager.Gravity.Right:
                if (lastTrain != Orientation.right)
                {
                    if (sens == Orientation.up || sens == Orientation.down)
                    {
                        lastTrain = Orientation.right;
                        ActivateLever();
                    }
                }
                break;
        }
    }


    public void ActivateLever()
    {
        Vector3 move = transform.position;

        Debug.Log("Invokating");
        transform.rotation = trained ?
            Quaternion.Lerp(transform.rotation, bentRotation, rotationSpeed * Time.deltaTime):
            Quaternion.Lerp(transform.rotation, trainedRotation, rotationSpeed * Time.deltaTime);


        transform.localPosition = new Vector3(-transform.localRotation.z * 1.5f, 0, 0);
    }


    IEnumerator StopTrain()
    {
        yield return new WaitForSeconds(1);
        CancelInvoke();
        Debug.Log("InInvokating");
    }


}
