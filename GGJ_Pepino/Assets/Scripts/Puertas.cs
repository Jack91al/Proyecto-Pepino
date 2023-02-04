using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    public float time;

    public bool iAmSpawners;
    public GameObject spawners;
    public Apuerta Puerta;



    // Start is called before the first frame update
    void Start()
    {
        if (iAmSpawners)
        {
            spawners.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.S))
            {
                col.gameObject.SendMessage("planting");
                Debug.Log("AAAAAAA");
                if (iAmSpawners)
                {
                    spawners.SetActive(true);
                }
                Puerta.Abrir();

            }
        }
    }
}
