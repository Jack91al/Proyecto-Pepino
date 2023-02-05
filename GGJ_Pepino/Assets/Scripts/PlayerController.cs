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
        Planting,
        Dying
    }

    public enum PlayerPower
    {
        Normal,
        Fuego,
        Hielo,
        Roca
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
        SwitchAnimator();
    }

    public void StatusSwitch(PlayerState newState)
    {
        playerState = newState;

        switch (playerState)
        {
            case PlayerState.Idle:
                MovePersonaje.instance.IAmMove = true;
                MovePersonaje.instance.SetAnimation("Idle");

                break;

            case PlayerState.Running:
                MovePersonaje.instance.IAmMove = true;
                MovePersonaje.instance.SetAnimation("Walk");
                break;

            case PlayerState.Jumping:
                MovePersonaje.instance.IAmMove = true;
                MovePersonaje.instance.SetAnimation("Jump");
                break;

            case PlayerState.Attack:
                MovePersonaje.instance.IAmMove = false;
                MovePersonaje.instance.SetAnimation("Attack");
                break;

            case PlayerState.Planting:
                MovePersonaje.instance.IAmMove = false;
                MovePersonaje.instance.SetAnimation("Planting");
                break;

            case PlayerState.Dying:
                MovePersonaje.instance.IAmMove = false;
                MovePersonaje.instance.SetAnimation("Death");
                break;

        }
    }

    public void SwitchAnimator()
    {
        switch(playerPower)
        {
            case PlayerPower.Normal:

                MovePersonaje.instance.animNormal.gameObject.SetActive(true);
                MovePersonaje.instance.animFuego.gameObject.SetActive(false);
                MovePersonaje.instance.animHielo.gameObject.SetActive(false);
                MovePersonaje.instance.animRoca.gameObject.SetActive(false);

                MovePersonaje.instance.animActual = MovePersonaje.instance.animNormal;

                break;

            case PlayerPower.Fuego:

                MovePersonaje.instance.animNormal.gameObject.SetActive(false);
                MovePersonaje.instance.animFuego.gameObject.SetActive(true);
                MovePersonaje.instance.animHielo.gameObject.SetActive(false);
                MovePersonaje.instance.animRoca.gameObject.SetActive(false);

                MovePersonaje.instance.animActual = MovePersonaje.instance.animFuego;

                break;

            case PlayerPower.Hielo:

                MovePersonaje.instance.animNormal.gameObject.SetActive(false);
                MovePersonaje.instance.animFuego.gameObject.SetActive(false);
                MovePersonaje.instance.animHielo.gameObject.SetActive(true);
                MovePersonaje.instance.animRoca.gameObject.SetActive(false);

                MovePersonaje.instance.animActual = MovePersonaje.instance.animHielo;

                break;

            case PlayerPower.Roca:

                MovePersonaje.instance.animNormal.gameObject.SetActive(false);
                MovePersonaje.instance.animFuego.gameObject.SetActive(false);
                MovePersonaje.instance.animHielo.gameObject.SetActive(false);
                MovePersonaje.instance.animRoca.gameObject.SetActive(true);

                MovePersonaje.instance.animActual = MovePersonaje.instance.animRoca;

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
