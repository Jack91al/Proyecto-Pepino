using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Plataformas : MonoBehaviour
{
    public float abajo;

    private void Start()
    {
        abajo = 0;
    }
    private void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            if (CrossPlatformInputManager.GetButton("Down"))
            {
                abajo++;
                if (CrossPlatformInputManager.GetButton("Down") && abajo > 24)
                {
                    abajo = 0;
                    Collider2D ColisionPlayer = coll.collider.GetComponent<Collider2D>();
                    StartCoroutine(IgnorarColision(ColisionPlayer));
                }
            }
            else
            {
                Invoke("Reset", 0.5f);
            }
        }
    }
    private void Reset()
    {

        abajo = 0;
    }

    IEnumerator IgnorarColision(Collider2D playerColider)
    {
        Physics2D.IgnoreCollision(playerColider, GetComponent<Collider2D>(), true);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(playerColider, GetComponent<Collider2D>(), false);
    }
}
