using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class MovePersonaje : MonoBehaviour
{
    public float vida;
    private bool recivirDmg;
    public float SpeedWalk;
    private float SpeedStun = 4f;
    public float ImpulseJump;
    public int NumJump;
    public int LimitJump;
    public int Maxvida;
    public Slider sliderVida;

    public Vector2 ImpulsePush;
    private float direccion;

    public GameObject DeadEffect;
    public GameObject Stuned;

    private Rigidbody2D Body;
    private Vector2 movement;
    private AudioSource AudioWalk;
    public GameObject AudioJump;
    public GameObject AudioHurt;

    private float HorInput;
    public bool JumpInput;
    public bool IAmGround;
    int VelYID;
    int InGroundID;

    private bool Down = false;
    public Vector2 ColiderDePie;
    public Vector2 OffSetDePIe;
    public Vector2 ColiderAgachado;
    public Vector2 OffSetAgachado;
    int DownID;
    int PushID;

    private bool FacingRight;

    private Animator anim;
    private CapsuleCollider2D coll;
    private SpriteRenderer spr;

    public bool IAmMove;
    private bool IAmStun = false;
    public bool IAmDown;

    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        vida = Maxvida;
        IAmDown = false;
        NumJump = 0;

        Body = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
        spr = GetComponent<SpriteRenderer>();
        AudioWalk = GetComponent<AudioSource>();

        
        FacingRight = true;

        recivirDmg = true;

        anim = GetComponent<Animator>();

        VelYID = Animator.StringToHash("VertSpeed");
        InGroundID = Animator.StringToHash("EnSuelo");
        DownID = Animator.StringToHash("Agachar");
        PushID = Animator.StringToHash("Push");

        ColiderDePie = coll.size;
        OffSetAgachado = coll.offset;
        ColiderAgachado = new Vector2(coll.size.x, coll.size.y /2f);
        OffSetAgachado = new Vector2(coll.offset.x, coll.offset.y -1.3f);
    }

    // Update is called once per frame
    void Update()
    {
        sliderVida.value = vida;
        IAmGround = Checkground.IsGround;
        JumpInput = CrossPlatformInputManager.GetButtonDown("Jump");
        HorInput = joystick.Horizontal * SpeedWalk;

        anim.SetFloat("HorWalk", Mathf.Abs(HorInput));
        anim.SetFloat(VelYID, Body.velocity.y);

        if (HorInput != 0 && Checkground.IsGround && !Down && !IAmDown)
        {

        }
        else
        {
            AudioWalk.Play();
        }

        Agachar();

        if ((HorInput < 0) && FacingRight)
        {
            Flip();
            FacingRight = false;

        }
        else if ((HorInput > 0) && !FacingRight)
        {
            Flip();
            FacingRight = true;
        }


    }
    //=========================================
    private void FixedUpdate()
    {
        if (IAmMove)
        {
            if(HorInput != 0)
            {
                Body.velocity = new Vector2(HorInput, Body.velocity.y);
            }
            else
            {
                Body.velocity = new Vector2(0, Body.velocity.y);
            }

            
            if (Checkground.IsGround)
            {
                NumJump = 0;
                anim.SetBool(InGroundID, true);
            }
            if (JumpInput && Checkground.IsGround)
            {
                NumJump++;
                Body.AddForce(Vector2.up * ImpulseJump);
                Instantiate(AudioJump, transform.position, Quaternion.identity);
                anim.SetBool(InGroundID, false);

            }
            if (!Checkground.IsGround && NumJump > 0 && NumJump < LimitJump && JumpInput)
            {
                NumJump++;
                Body.velocity = Vector2.zero;
                Body.AddForce(Vector2.up * ImpulseJump);
                Instantiate(AudioJump, transform.position, Quaternion.identity);
            }

        }
        if (IAmStun)
        {
            if (HorInput != 0)
            {
                Body.velocity = new Vector2(HorInput/SpeedStun, Body.velocity.y);
            }
            else
            {
                Body.velocity = new Vector2(0, Body.velocity.y);
            }

        }
        if (!Checkground.IsGround)
        {
            if(Body.velocity.y < -18f)
            {
                movement = Body.velocity;
                movement.y = -18f;
                Body.velocity = movement;
            }
        }

    }
    //=========================================
    private void Flip()
    {
        transform.Rotate(Vector3.up,180);
    }
    //=========================================
    private void Agachar()
    {

        if (CrossPlatformInputManager.GetButton("Down"))
        {
            Down = true;
            coll.size = ColiderAgachado;
            coll.offset = OffSetAgachado;
            IAmMove = false;
        }
        else if(!IAmDown){
            Down = false;
            coll.size = ColiderDePie;
            coll.offset = OffSetDePIe;
            IAmMove = true;
        }

        anim.SetBool(DownID, Down);

    }
    //=========================================
    public void quieto()
    {
        HorInput = 0;
        IAmMove = false;
        IAmDown = true;
    }
    //=========================================
    public void HurtPlayer(float damage)
    {
        vida -= damage;
        spr.color = Color.red;
        Invoke("Sano", 0.3f);
        Instantiate(AudioHurt, transform.position, Quaternion.identity);
        
        if (vida <= 0)
        {
            vida = 0;
            Instantiate(DeadEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    //=========================================
    public void PushPlayer(float damage)
    {
        IAmDown = true;
        if (FacingRight)
        {
            direccion = -1f;
        }
        else
        {
            direccion = 1f;
        }

        if (recivirDmg)
        {
            vida -= damage;
            spr.color = Color.red;
            Invoke("Sano", 0.3f);
            IAmMove = false;
            HorInput = 0;
            Body.velocity = new Vector2(direccion * ImpulsePush.x, ImpulsePush.y);
            anim.SetBool(PushID, true);
            Instantiate(AudioHurt, transform.position, Quaternion.identity);
            recivirDmg = false;
        }

        if (vida <= 0)
        {
            vida = 0;
            Instantiate(DeadEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        Invoke("MoverPlayer", damage);
    }
    //=========================================
    public void StunPlayer(float damage)
    {
        vida -= damage;
        IAmMove = false;
        IAmStun = true;
        spr.color = Color.red;
        Invoke("Sano", 0.3f);
        Instantiate(AudioHurt, transform.position, Quaternion.identity);
        Stuned.gameObject.SetActive(true);

        if (vida <= 0)
        {
            vida = 0;
            Instantiate(DeadEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
        Invoke("MoverPlayer", damage);
    }
    //=========================================
    void MoverPlayer()
    {
        IAmMove = true;
        IAmStun = false;
        Stuned.gameObject.SetActive(false);
        anim.SetBool(PushID, false);
        HorInput = joystick.Horizontal * SpeedWalk;
        IAmDown = false;
        recivirDmg = true;

    }
    void Sano()
    {
        spr.color = Color.white;
    }
}
