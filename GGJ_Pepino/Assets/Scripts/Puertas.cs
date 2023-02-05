using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{

    public bool FireDoor;
    public bool iceDoor;
    public bool earthDoor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && FireDoor)
        {
            if (Input.GetKey(KeyCode.S))
            {
                col.gameObject.SendMessage("plantingEarth");

            }
        }
        if (col.gameObject.tag == "Player" && iceDoor)
        {
            if (Input.GetKey(KeyCode.S))
            {
                col.gameObject.SendMessage("plantingFire");

            }
        }
        if (col.gameObject.tag == "Player" && earthDoor)
        {
            if (Input.GetKey(KeyCode.S))
            {
                col.gameObject.SendMessage("plantingIce");

            }
        }
    }
}
