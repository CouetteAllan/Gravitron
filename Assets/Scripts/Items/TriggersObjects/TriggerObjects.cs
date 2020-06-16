using UnityEngine;

public class TriggerObjects : MonoBehaviour // Emile
{
    [SerializeField] private InteractableObjects[] activableObjects;



    protected virtual void Snap()
    {
        foreach (InteractableObjects activableObject in activableObjects)
        {
            activableObject.ChangeBehaviour();
        }
    }
}
