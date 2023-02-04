using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public enum Pista
    {
        Normal,
        Fuego,
        Hielo,
        Roca,
        Mashup,
        Jefe
    }

    [Header("Aqui se cambia la musica")] public Pista pistaActual;

    [Header("Controladores de Musica")]
    public AudioSource pistaNormal;
    public AudioSource pistaFuego;
    public AudioSource pistaHielo;
    public AudioSource pistaRoca;
    public AudioSource pistaMashup;
    public AudioSource pistaJefe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarPista()
    {
        switch(pistaActual)
        {
            case Pista.Normal:
                


                break;

            case Pista.Fuego:

                break;

            case Pista.Hielo:

                break;

            case Pista.Roca:

                break;

            case Pista.Mashup:

                break;
        }
    }
}
