using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MovePersonaje : MonoBehaviour
{
    public static MovePersonaje instance;

    private void Awake()
    {
        instance = this;
    }


    public float vida;
    private bool recivirDmg;
    public float SpeedWalk;
    private float SpeedStun = 4f;
    public float ImpulseJump;
    public int NumJump;
    public int LimitJump;
    public int Maxvida;
    public Slider sliderVida;

    private float direccion;

    public GameObject DeadEffect;

    private Rigidbody2D Body;
    private Vector2 movement;

    private float HorInput;
    public bool JumpInput;
    public bool IAmGround;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    int VelYID;
    int InGroundID;

    private bool FacingRight;

    [Header("Animaciones")]

    public Animator animActual;

    public Animator animNormal;
    public Animator animFuego;
    public Animator animHielo;
    public Animator animRoca;

    [Tooltip("X es powerup, Y es vida")]
    //0: normal, 1: fuego, 2: hielo, 3: roca
    public Animator[,] pepinos = new Animator[4, 3];
    int poder;

    private CapsuleCollider2D coll;


    public bool IAmMove;
    private bool IAmStun = false;


    // Start is called before the first frame update
    void Start()
    {
        vida = Maxvida;
        NumJump = 0;

        Body = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();

        FacingRight = true;

        recivirDmg = true;

        //anim = GetComponent<Animator>();

        VelYID = Animator.StringToHash("VertSpeed");
        InGroundID = Animator.StringToHash("EnSuelo");
    }

    // Update is called once per frame
    void Update()
    {
        //sliderVida.value = vida;
        IAmGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,whatIsGround);
        JumpInput = Input.GetKey(KeyCode.W);
        HorInput = Input.GetAxisRaw("Horizontal") * SpeedWalk;

        //anim.SetFloat("HorWalk", Mathf.Abs(HorInput));
        //anim.SetFloat(VelYID, Body.velocity.y);



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

            if (IAmGround && HorInput != 0)
            {
                PlayerController.instance.StatusSwitch(PlayerController.PlayerState.Running);
            }

            if (IAmGround && HorInput == 0)
            {
                PlayerController.instance.StatusSwitch(PlayerController.PlayerState.Idle);
            }


            if (IAmGround)
            {
                NumJump = 0;
            }


            if (JumpInput && IAmGround)
            {
                NumJump++;
                Body.AddForce(Vector2.up * ImpulseJump);
                PlayerController.instance.StatusSwitch(PlayerController.PlayerState.Jumping);

            }
            if (!IAmGround && NumJump > 0 && NumJump < LimitJump && JumpInput)
            {
                NumJump++;
                Body.velocity = Vector2.zero;
                Body.AddForce(Vector2.up * ImpulseJump);
               
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
        if (!IAmGround)
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
    public void quieto()
    {
        HorInput = 0;
        IAmMove = false;
    }
    //=========================================
    public void HurtPlayer(float damage)
    {
        vida -= damage;



        
        if (vida <= 0)
        {
            vida = 0;
            Instantiate(DeadEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void SetAnimation(string animBool)
    {
        animActual.SetBool("Idle", false);
        animActual.SetBool("Walk", false);
        animActual.SetBool("Jump", false);
        animActual.SetBool("Planting", false);
        animActual.SetBool("Attack", false);
        animActual.SetBool("Death", false);

        animActual.SetBool(animBool, true);
    }

    public void UpdateAnimator()
    {
        

        switch(PlayerController.instance.playerPower)
        {
            case PlayerController.PlayerPower.Normal:
                poder = 0;
                break;

            case PlayerController.PlayerPower.Fuego:
                poder = 1;
                break;

            case PlayerController.PlayerPower.Hielo:
                poder = 2;
                break;

            case PlayerController.PlayerPower.Roca:
                poder = 3;
                break;
        }

        animActual = pepinos[poder, (int)vida];

    }

}
