using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levier : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private float rotationSpeed = 1;

    private Quaternion trainedRotation = Quaternion.Euler(0, 0, 45);
    private Quaternion bentRotation = Quaternion.Euler(0, 0, 135);

    private bool trained = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            trained = !trained;
            InvokeRepeating("Train", 0, Time.deltaTime);
        }
    }



    public void Train()
    {
        Vector3 move = transform.position;

        Debug.Log("Invokating");
        transform.rotation = trained ?
            Quaternion.Lerp(transform.rotation, bentRotation, rotationSpeed * Time.deltaTime):
            Quaternion.Lerp(transform.rotation, trainedRotation, rotationSpeed * Time.deltaTime);


        transform.localPosition = new Vector3(-transform.localRotation.z * 1.5f, 0, 0);

        if (transform.rotation == Quaternion.Euler(0,0,50) || transform.rotation == Quaternion.Euler(0, 0, 130))
        {
            Debug.Log("NotInvokating");
            CancelInvoke();
        }
    }
}
