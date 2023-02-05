using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnterrarse : MonoBehaviour
{
    public float timer, timerMaxTime;

    public bool activated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer = -Time.deltaTime;
        }

        if(timer < 0)
        {
            switch (PlayerController.instance.playerPower)
            {
                case PlayerController.PlayerPower.Fuego:
                    if(GridManager.instance.climaActual == GridManager.Clima.Fuego)
                    GridManager.instance.CambiarClima(GridManager.Clima.Fuego);

                    MovePersonaje.instance.vida = MovePersonaje.instance.Maxvida;
                    break;

                case PlayerController.PlayerPower.Hielo:
                    if (GridManager.instance.climaActual == GridManager.Clima.Hielo)
                        GridManager.instance.CambiarClima(GridManager.Clima.Hielo);

                    MovePersonaje.instance.vida = MovePersonaje.instance.Maxvida;
                    break;

                case PlayerController.PlayerPower.Tierra:
                    if (GridManager.instance.climaActual == GridManager.Clima.Roca)
                        GridManager.instance.CambiarClima(GridManager.Clima.Roca);

                    MovePersonaje.instance.vida = MovePersonaje.instance.Maxvida;
                    break;

                case PlayerController.PlayerPower.Normal:
                    MovePersonaje.instance.vida = MovePersonaje.instance.Maxvida;
                    break;
            }


            timer = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && Input.GetKeyDown(KeyCode.S))
        {
            PlayerController.instance.StatusSwitch(PlayerController.PlayerState.Planting);

            Debug.Log("AAAAAAA");

            timer = timerMaxTime;

            
        }
    }

}
