using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum Power
    {
        Fuego,
        Hielo,
        Roca
    }

    public Power power;

    public Sprite[] powerSprite = new Sprite[3];

    // Start is called before the first frame update
    void Start()
    {
        switch(power)
        {
            case Power.Fuego:
                GetComponent<SpriteRenderer>().sprite = powerSprite[0];
                break;

            case Power.Hielo:
                GetComponent<SpriteRenderer>().sprite = powerSprite[1];
                break;

            case Power.Roca:
                GetComponent<SpriteRenderer>().sprite = powerSprite[2];
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            switch(power)
            {
                case Power.Fuego:
                    PlayerController.instance.playerPower = PlayerController.PlayerPower.Fuego; 
                    break;

                case Power.Hielo:
                    PlayerController.instance.playerPower = PlayerController.PlayerPower.Hielo;
                    break;

                case Power.Roca:
                    PlayerController.instance.playerPower = PlayerController.PlayerPower.Roca;
                    break;
            }

            Destroy(gameObject);
        }
    }

}
