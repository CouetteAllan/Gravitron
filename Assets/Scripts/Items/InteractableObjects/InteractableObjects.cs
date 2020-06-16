using UnityEngine;

public class InteractableObjects : MonoBehaviour // Emile
{
    protected bool isMoving;

    [SerializeField] protected bool active = false;     // Change le premier comportement de l'objet (en début de partie)
    public bool Active
    {
        get { return active; }
        set { active = value; }
    }


    private void Start()
    {
        ChangeBehaviour();
    }


    public void ChangeBehaviour()
    {
        if (Active)
        {
            ActivateObject();
        }
        else if (!Active)
        {
            DisabledObject();
        }
        Active = !Active;
    }

    protected virtual void ActivateObject()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    } 

    protected virtual void DisabledObject()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }
}
