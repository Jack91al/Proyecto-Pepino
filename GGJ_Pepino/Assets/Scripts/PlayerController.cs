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

    public PlayerState playerState;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController.instance.StatusSwitch(PlayerState.Planting);
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
                
                break;

            case PlayerState.Running:

                break;

            case PlayerState.Jumping:

                break;

            case PlayerState.Attack:

                break;

            case PlayerState.Planting:

                break;

        }
    }

}
