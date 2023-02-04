using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FadeScript : MonoBehaviour
{
    public static FadeScript instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator DoFadeIn(Tilemap tilemap, float fadeTime)
    {
        Color tmpColor = tilemap.color;

        while(tmpColor.a < 1)
        {
            tmpColor.a += Time.deltaTime / fadeTime;
            tilemap.color = tmpColor;

            if(tmpColor.a >= 1)
            {
                tmpColor.a = 1;
            }

            yield return null;
        }

        tilemap.color = tmpColor;
    }

    public IEnumerator DoFadeOut(Tilemap tilemap, float fadeTime)
    {
        Color tmpColor = tilemap.color;

        while (tmpColor.a > 0)
        {
            tmpColor.a -= Time.deltaTime / fadeTime;
            tilemap.color = tmpColor;

            if (tmpColor.a <= 0)
            {
                tmpColor.a = 0;
            }

            yield return null;
        }

        tilemap.color = tmpColor;
    }

}
