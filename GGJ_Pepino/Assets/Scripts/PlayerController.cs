using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private void Awake()
    {
        instance = this;
    }

    public enum PlayerState
    {
        Idle,
        Running,
        Jumping,
        Attack,
        Planting
    }

    public enum PlayerPower
    {
        Normal,
        Fuego,
        Hielo,
        Tierra
    }

    public PlayerState playerState;
    public PlayerPower playerPower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StatusSwitch(PlayerState newState)
    {
        playerState = newState;

        switch (playerState)
        {
            case PlayerState.Idle:
                MovePersonaje.instance.IAmMove = true;
                break;

            case PlayerState.Running:
                MovePersonaje.instance.IAmMove = true;
                break;

            case PlayerState.Jumping:
                MovePersonaje.instance.IAmMove = true;
                break;

            case PlayerState.Attack:
                MovePersonaje.instance.IAmMove = false;
                break;

            case PlayerState.Planting:

                MovePersonaje.instance.IAmMove = false;

                break;

        }
    }
    public void planting()
    {
        PlayerController.instance.StatusSwitch(PlayerState.Planting);
    }
    public void desplanting()
    {
        PlayerController.instance.StatusSwitch(PlayerState.Idle);
    }

}
