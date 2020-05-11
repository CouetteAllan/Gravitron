using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Vector2 localGravity;
    [SerializeField]
    private string gravityInputDirection = "down";

    private Vector2 direction;

    
    
    

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("Le GameManager est null lulz");
            }
            return instance;
        }
    }
    private GameState gameState;
    public enum GameState 
    {
        InGame,
        Pause,
        MainMenu,
    }

    private Gravity gravity;
    public enum Gravity
    {
        Left,
        Right,
        Down,
        Up
    }

    private void Awake()
    {
        Debug.Log(Physics2D.gravity.magnitude);
        instance = this;
        localGravity = Physics2D.gravity;
    }


    public void ChangeState(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu:
                UIManager.Instance.AfficherMenuPause(false);
                break;
            case GameState.InGame:
                Time.timeScale = 1;
                break;
            case GameState.Pause:
                Time.timeScale = 0;
                UIManager.Instance.AfficherMenuPause(true);
                break;
            default:
                state = GameState.InGame;
                break;
        }
    }


    public void ChangeGravity()
    {
        switch (gravity)
        {
            case Gravity.Up:
                direction = Vector2.up;
                break;
            case Gravity.Left:
                direction = Vector2.left;
                break;
            case Gravity.Right:
                direction = Vector2.right;
                break;
            case Gravity.Down:
                direction = Vector2.down;
                break;
            default:
                direction = Vector2.down;
                break;
        }
        UIManager.Instance.Fgravity();
        Physics2D.gravity = direction * localGravity.magnitude;
        this.localGravity = Physics2D.gravity;//change la gravité
    }

    

    public Vector2 SendGravityDirection()
    {
        Vector2 gravityDirection = this.localGravity.normalized ;
        return gravityDirection;
    }

    public void SetGravityInput(Gravity input)
    {
        gravity = input;
    }

    public GameState SendGameState()
    {
        return this.gameState;
    }
}