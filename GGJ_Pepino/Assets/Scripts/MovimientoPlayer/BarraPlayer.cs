using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraPlayer : MonoBehaviour
{
    public Image barraPlayer;
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "EnemyA")
        {
            barraPlayer.fillAmount -= 0.1f;
            if (barraPlayer.fillAmount == 0f)
            {
                Destroy(player);     
            }

        }
    }
   
}
