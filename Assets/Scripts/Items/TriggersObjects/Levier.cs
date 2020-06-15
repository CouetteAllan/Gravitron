using System.Collections;
using UnityEngine;

public class Levier : TriggerObjects
{

    [SerializeField] private float rotationSpeed = 1;

    private Quaternion ActiveRotation;
    private Quaternion bentRotation;

    private bool first = true;
    
    private Orientation lastTrain;

    [SerializeField] private bool bented;           // Change la première rotation du levier en début de partie


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

        switch (sens)
        {
            case Orientation.right:
                ActiveRotation = Quaternion.Euler(0, 0, 45);
                bentRotation = Quaternion.Euler(0, 0, 135);
                lastTrain = bented ? Orientation.up : Orientation.down;
                break;
            case Orientation.left:
                ActiveRotation = Quaternion.Euler(0, 0, -45);
                bentRotation = Quaternion.Euler(0, 0, -135);
                lastTrain = bented ? Orientation.down : Orientation.up;
                break;
            case Orientation.down:
                ActiveRotation = Quaternion.Euler(0, 0, 45);
                bentRotation = Quaternion.Euler(0, 0, -45);
                lastTrain = bented ? Orientation.right : Orientation.left;
                break;
            case Orientation.up:
                ActiveRotation = Quaternion.Euler(0, 0, 135);
                bentRotation = Quaternion.Euler(0, 0, -135);
                lastTrain = bented ? Orientation.left : Orientation.right;
                break;
        }


        if (sens == Orientation.right || sens == Orientation.left)
        {
            if (GameManager.Instance.SendGravityDirection() == Vector2.right
                || GameManager.Instance.SendGravityDirection() == Vector2.left)
            {
                ActivateLever();
                lastTrain = bented ? Orientation.down : Orientation.up;
            }
        }
        else if (sens == Orientation.up || sens == Orientation.down)
        {
            if (GameManager.Instance.SendGravityDirection() == Vector2.up
                || GameManager.Instance.SendGravityDirection() == Vector2.down)
            {
                ActivateLever();
                lastTrain = bented ? Orientation.right : Orientation.left;
            }
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
        CancelInvoke("TrainLever");
        InvokeRepeating("TrainLever", 0, Time.deltaTime);
        AudioManager.Instance.Play("lever");
        bented = !bented;
        StopAllCoroutines();
        StartCoroutine(StopTrain());
    }

    public void TrainLever()
    {
        Vector3 move = transform.position;

        transform.rotation = bented ?
            Quaternion.Lerp(transform.rotation, bentRotation, rotationSpeed * Time.deltaTime) :
            Quaternion.Lerp(transform.rotation, ActiveRotation, rotationSpeed * Time.deltaTime);

        transform.localPosition = new Vector3(-transform.localRotation.z * 1.5f, 0, 0);

    }


    IEnumerator StopTrain()
    {
        if (!first)
        {
            Snap();
        }
        else
        {
            first = false;
        }
        yield return new WaitForSeconds(1);
        CancelInvoke();
    }


}
