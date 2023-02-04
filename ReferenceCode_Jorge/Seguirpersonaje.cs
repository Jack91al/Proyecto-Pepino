using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguirpersonaje : MonoBehaviour
{
    public GameObject Personaje;
    public float Smooth;

    public Vector3 MinPosition;
    public Vector3 MaxPosition;

    //public float separation;
    //public float separationY;


    // Update is called once per frame
    void Update()
    {
        Personaje = GameObject.FindWithTag("Player");

        if(Personaje != null)
        {
            if (transform.position != Personaje.transform.position)
            {
                Vector3 TargetPosition = new Vector3(Personaje.transform.position.x, Personaje.transform.position.y, transform.position.z);

                TargetPosition.x = Mathf.Clamp(TargetPosition.x, MinPosition.x, MaxPosition.x);
                TargetPosition.y = Mathf.Clamp(TargetPosition.y, MinPosition.y, MaxPosition.y);

                transform.position = Vector3.Lerp(transform.position, TargetPosition, Smooth);
            }
        }
        //transform.position = new Vector3(Personaje.transform.position.x+separation, Personaje.transform.position.y + separationY, transform.position.z);
    }
}
