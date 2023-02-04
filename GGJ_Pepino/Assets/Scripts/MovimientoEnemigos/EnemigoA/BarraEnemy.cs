using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraEnemy : MonoBehaviour
{
    public Image barraEnemy;
    public GameObject Enemy;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Bala")
        {
            barraEnemy.fillAmount -= 0.1f;
            if (barraEnemy.fillAmount == 0f)
            {
                Destroy(Enemy);
            }
        }
    }
}
   
