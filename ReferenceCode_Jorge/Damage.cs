using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage;
    public float speed;

    public bool IAmPush;
    public Vector2 empu;
    public Damage(float d, Vector2 p)
    {
        damage = d;
        empu = p;
    }
    public bool IAmStun;
    public bool IAmFrezze;

    public bool IAmVida;

    public bool AudioAlImpacto;
    public GameObject Audio;

    // Start is called before the first frame update
    void Start()
    {
        if (!AudioAlImpacto)
        {
            Instantiate(Audio, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if((col.gameObject.tag == "Enemy") && !IAmPush && !IAmFrezze)
        {
            col.gameObject.SendMessage("Hurt",damage);
            if (AudioAlImpacto)
            {
                Instantiate(Audio, transform.position, Quaternion.identity);
            }
        }

        if (IAmVida)
        {
            Destroy(gameObject);
        }
        
        if((IAmPush) && (col.gameObject.tag == "Enemy"))
        {
            col.gameObject.SendMessage("Push", new Damage(damage,empu));
            if (AudioAlImpacto)
            {
                Instantiate(Audio, transform.position, Quaternion.identity);
            }
        }
        if((IAmStun) && (col.gameObject.tag == "Enemy"))
        {
            col.gameObject.SendMessage("Stun", damage);
            if (AudioAlImpacto)
            {
                Instantiate(Audio, transform.position, Quaternion.identity);
            }
        }
        if ((IAmFrezze) && (col.gameObject.tag == "Enemy"))
        {
            col.gameObject.SendMessage("Freeze", damage);
            if (AudioAlImpacto)
            {
                Instantiate(Audio, transform.position, Quaternion.identity);
            }
        }
    }
 }
