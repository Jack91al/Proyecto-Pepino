using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;

    private void Awake()
    {
        instance = this;
    }

    public enum Clima
    {
        Normal,
        Fuego,
        Hielo,
        Roca
    }

    public Clima climaActual;

    Grid grid;

    public Tilemap[] tilesClimas;
    public Tilemap tileClimaActual;

    public float fadeTime;

    // Start is called before the first frame update
    void Start()
    {
        grid = GameObject.Find("Grid").GetComponent<Grid>();

        tilesClimas = new Tilemap[grid.transform.childCount];

        for (int i = 0; i < tilesClimas.Length; i++)
        {
            tilesClimas[i] = grid.transform.GetChild(i).GetComponent<Tilemap>();
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        UpdateCurrentClimate();

        if(Input.GetKeyUp(KeyCode.Space))
        {
            CambiarClima(Clima.Fuego);
        }
    }

    public void CambiarClima(Clima nuevoClima)
    {
        climaActual = nuevoClima;

        switch (climaActual)
        {
            case Clima.Normal:
                FadeScript.instance.StartCoroutine(FadeScript.instance.DoFadeOut(tileClimaActual, fadeTime));
                FadeScript.instance.StartCoroutine(FadeScript.instance.DoFadeIn(tilesClimas[0], fadeTime));
                break;

            case Clima.Fuego:
                FadeScript.instance.StartCoroutine(FadeScript.instance.DoFadeOut(tileClimaActual, fadeTime));
                FadeScript.instance.StartCoroutine(FadeScript.instance.DoFadeIn(tilesClimas[1], fadeTime));
                break;

            case Clima.Hielo:
                FadeScript.instance.StartCoroutine(FadeScript.instance.DoFadeOut(tileClimaActual, fadeTime));
                FadeScript.instance.StartCoroutine(FadeScript.instance.DoFadeIn(tilesClimas[2], fadeTime));
                break;

            case Clima.Roca:
                FadeScript.instance.StartCoroutine(FadeScript.instance.DoFadeOut(tileClimaActual, fadeTime));
                FadeScript.instance.StartCoroutine(FadeScript.instance.DoFadeIn(tilesClimas[3], fadeTime));
                break;
        }
    }

    void UpdateCurrentClimate()
    {
        switch (climaActual)
        {
            case Clima.Normal:
                tileClimaActual = tilesClimas[0];
                break;

            case Clima.Fuego:
                tileClimaActual = tilesClimas[1];
                break;

            case Clima.Hielo:
                tileClimaActual = tilesClimas[2];
                break;

            case Clima.Roca:
                tileClimaActual = tilesClimas[3];
                break;
        }
    }

}
