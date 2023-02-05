using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnterrarse : MonoBehaviour
{
    public float timer, timerMaxTime;

    public bool activated, used;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= 1 * Time.deltaTime;
        }

        if(timer <= 0 && activated && used)
        {
            switch (PlayerController.instance.playerPower)
            {
                case PlayerController.PlayerPower.Fuego:
                    if(GridManager.instance.climaActual == GridManager.Clima.Fuego)
                    GridManager.instance.CambiarClima(GridManager.Clima.Fuego);

                    MovePersonaje.instance.vida = MovePersonaje.instance.Maxvida;
                    PlayerController.instance.StatusSwitch(PlayerController.PlayerState.Idle);
                    break;

                case PlayerController.PlayerPower.Hielo:
                    if (GridManager.instance.climaActual == GridManager.Clima.Hielo)
                        GridManager.instance.CambiarClima(GridManager.Clima.Hielo);

                    MovePersonaje.instance.vida = MovePersonaje.instance.Maxvida;
                    PlayerController.instance.StatusSwitch(PlayerController.PlayerState.Idle);
                    break;

                case PlayerController.PlayerPower.Roca:
                    if (GridManager.instance.climaActual == GridManager.Clima.Roca)
                        GridManager.instance.CambiarClima(GridManager.Clima.Roca);

                    MovePersonaje.instance.vida = MovePersonaje.instance.Maxvida;
                    PlayerController.instance.StatusSwitch(PlayerController.PlayerState.Idle);
                    break;

                case PlayerController.PlayerPower.Normal:
                    MovePersonaje.instance.vida = MovePersonaje.instance.Maxvida;
                    PlayerController.instance.StatusSwitch(PlayerController.PlayerState.Idle);
                    break;
            }
            print("Done");
            timer = 0;
        }

        if (activated && !used && Input.GetKeyDown(KeyCode.S))
        {
            used = true;

            timer = timerMaxTime;

            PlayerController.instance.StatusSwitch(PlayerController.PlayerState.Planting);           

            Debug.Log("AAAAAAA");
          
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.tag == "Player")
        {
            activated = true;             
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            activated = false;
        }
    }

}
