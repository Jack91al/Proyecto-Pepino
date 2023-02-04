using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance; 

    private void Awake()
    {
        instance = this;
    }


    public enum Pista
    {
        Normal,
        Fuego,
        Hielo,
        Roca,
        Mashup,
        Jefe
    }

    [Header("Aqui se muestra que musica suena")] public Pista pistaActual;

    [Header("Controladores de Musica")]

    public AudioSource[] controladores = new AudioSource[1];

    // Start is called before the first frame update
    void Start()
    {
        controladores = new AudioSource[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            controladores[i] = transform.GetChild(i).GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarPista(Pista nuevaPista)
    {
        pistaActual = nuevaPista;

        switch(pistaActual)
        {
            case Pista.Normal:

                for (int i = 0; i < controladores.Length; i++)
                {
                    controladores[i].volume = 0;
                    controladores[1].volume = 1;
                }

                break;

            case Pista.Fuego:

                for (int i = 0; i < controladores.Length; i++)
                {
                    controladores[i].volume = 0;
                    controladores[2].volume = 1;
                }

                break;

            case Pista.Hielo:

                for (int i = 0; i < controladores.Length; i++)
                {
                    controladores[i].volume = 0;
                    controladores[3].volume = 1;
                }

                break;

            case Pista.Roca:

                for (int i = 0; i < controladores.Length; i++)
                {
                    controladores[i].volume = 0;
                    controladores[4].volume = 1;
                }

                break;

            case Pista.Mashup:

                for (int i = 0; i < controladores.Length; i++)
                {
                    controladores[i].volume = 0;
                    controladores[5].volume = 1;
                }

                break;

            case Pista.Jefe:

                for (int i = 0; i < controladores.Length; i++)
                {
                    controladores[i].volume = 0;
                    controladores[6].volume = 1;
                }

                break;
        }

        

    }
}
