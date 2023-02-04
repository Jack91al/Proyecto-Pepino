using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    public float time;

    public GameObject spawners;
    public GameObject Puerta;

    enum PlayerState
    {
        Planting
    }

    // Start is called before the first frame update
    void Start()
    {
        spawners.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        float IniTime;

        IniTime = Time.deltaTime;
        if ((col.gameObject.tag == "Player"))
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                spawners.SetActive(true);
                Debug.Log("AAAAAAA");
                col.gameObject.SendMessage("StatusSwitch", PlayerState.Planting);
                if (col.gameObject.tag == "" && IniTime <= time)
                {
                    col.gameObject.SendMessage("Abrir");
                    Debug.Log("AAAAAAA");
                }
            }

        }
    }
}
