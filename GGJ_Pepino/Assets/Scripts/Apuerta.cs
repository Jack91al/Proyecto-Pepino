using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apuerta : MonoBehaviour
{
    public bool iAmSpawners;
    public GameObject spawners;

    private Animator anim;
    int ab;
    bool cerrant;

    public float time;
    // Start is called before the first frame update
    void Start()
    {
        if (iAmSpawners)
        {
            spawners.SetActive(false);
        }
        anim = GetComponent<Animator>();
        cerrant = false;
        ab = Animator.StringToHash("abierto");
    }

    // Update is called once per frame
    void Update()
    {
        if (cerrant)
        {
            Invoke("tempo", time);

        }
    }
    public void Abrir()
    {
        cerrant = true;
        if (iAmSpawners)
        {
            spawners.SetActive(true);
        }

    }
    public void tempo()
    {
        anim.SetBool(ab, true);
    }
}
