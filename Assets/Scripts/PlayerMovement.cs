using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{

    #region Singleton

    public static PlayerMovement instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    #endregion
    public GameObject sceneChanger;
    public AudioSource[] allAudioSources;

    public float holdTime = 3.0f; // how long you need to hold to trigger the effect

    private float startTime = 0f;
    private float timer = 0f;
    public float oldMoveSpeed;
    public float MoveSpeed = 1;
    public float jumpHeight = 3;
    public float jumpSpeed = 1;
    public float fallSpeed = 0.5f;
    public Animator animator;

    private Vector2 newDirection;


    [SerializeField] LayerMask playformLayerMask;
    public float distanceGround;

    public float yAxisDistance;

    public float incSpeed = 2.0f;
    public bool pleaseJump = false;
    public bool movingLeft = false;
    public bool movingRight = false;
    public bool movingUp = false;
    public bool movingDown = false;
    private float KnockbackForce = 100f;
    private bool isHit = false;

    public CharacterStat characterStat;

    public AudioSource springmusic;
    public AudioSource summermusic;
    public AudioSource fallmusic;
    public AudioSource wintermusic;



    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        //springmusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Spring World")
        {
            StopAllMusic();
            springmusic.Play();
        }
        HandleMameInputs();
        gameObject.GetComponent<Rigidbody>().velocity = new Vector2(0, gameObject.GetComponent<Rigidbody>().velocity.y);
        MoveSpeed = characterStat.speed.GetValue();
    }

    void FixedUpdate()
    {
        if (pleaseJump == true)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, jumpHeight,    0f), ForceMode.Force);
            pleaseJump = false;
        }
        if (movingLeft == true)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(-transform.right * MoveSpeed, ForceMode.Force);
            movingLeft = false;
        }
        if (movingRight == true)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(transform.right * MoveSpeed, ForceMode.Force);
            movingRight = false;
        }
        if(movingUp == true)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * MoveSpeed, ForceMode.Force);
            movingUp = false;
        }
        if(movingDown == true)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * MoveSpeed, ForceMode.Force);
            movingDown = false;
        }
        /*if (isHit)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 10f), ForceMode2D.Impulse);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(KnockbackForce, 0f), ForceMode2D.Impulse);
            Debug.Log("knocked back");
            animator.SetBool("Hit", true);
            isHit = false;
        }
        */
    }

    private void HandleMameInputs()
    {

        ///////////////////////////////////////////
        //  Default Keymap	
        ///////////////////////////////////////////
        /* Main Keys	
        5,6,7,8	   Insert coin	
        1,2,3,4	   Players 1 - 4 start buttons	
        
        Arrow Keys	Controller (Player 1)	
        
        Left Ctrl	Fire 1 (Player 1)	
        Left Alt	Fire 2 (Player 1)	
        Space	    Fire 3 (Player 1)	
        Left Shift	Fire 4 (Player 1)	
        Z	        Fire 5 (Player 1)	
        X           Fire 6(Player 1)	
        
        R,F,G,D	Controller (Player 2)	
        A         Fire 1 (Player 2)	
        S         Fire 2 (Player 2)	
        Q         Fire 3 (Player 2)	
        W         Fire 4 (Player 2)	
        E         Fire 5 (Player 2)	Not set by default
        T         Fire 6 (Player 2)	Not Set By Default	
        
        Playchoice 10 Additional Keys	
        5         Adds Time	
        0         Select Game	
        1         Toggles 1 or 2 Player Mode	
        2         Start Game
        */


        /////////////////////////////////////////////
        // Control Keys
        /////////////////////////////////////////////




        /////////////////////////////////////////////
        // Player 1 Movements
        /////////////////////////////////////////////
        if (Input.GetKey(KeyCode.LeftArrow) /*&& healthText.GetComponent<HealthScript>().getHealth() >= 1*/)
        {
            movingLeft = true;
            //transform.localScale = new Vector3(-3f, 3f, 0.5f);
            KnockbackForce = 30f;

        }

        if (Input.GetKey(KeyCode.RightArrow) /* && healthText.GetComponent<HealthScript>().getHealth() >= 1*/)
        {
            movingRight = true;
            //transform.localScale = new Vector3(3f, 3f, 0.5f);
            KnockbackForce = -30f;
        }
        if (Input.GetKey(KeyCode.UpArrow) /* && healthText.GetComponent<HealthScript>().getHealth() >= 1*/)
        {
            movingUp = true;
            //transform.localScale = new Vector3(3f, 3f, 0.5f);
            KnockbackForce = -30f;
        }
        if (Input.GetKey(KeyCode.DownArrow) /* && healthText.GetComponent<HealthScript>().getHealth() >= 1*/)
        {
            movingDown = true;
            //transform.localScale = new Vector3(3f, 3f, 0.5f);
            KnockbackForce = -30f;
        }
        if (!Input.GetKey(KeyCode.RightArrow) /*&& !(Input.GetKey(KeyCode.LeftArrow))*/)
        {
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && IsGrounded())
        {
            Debug.Log("Trying to jump");
            pleaseJump = true;
        }




        /////////////////////////////////////
        // Player 1 Actions
        /////////////////////////////////////
        // Left Ctrl   Fire 1(Player 1)
        /*if (Input.GetKeyDown(KeyCode.Space) && healthText.GetComponent<HealthScript>().getHealth() >= 1)
        {
            fireAudio.Play();
            gameObject.GetComponent<FireLaser>().fireLaser();



            animator.SetBool("Lazer", true);
        }
        if (!Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Lazer", false);
        }

        // Left Alt    Fire 2(Player 1)
        if (Input.GetKey(KeyCode.LeftAlt) && !Fast && healthText.GetComponent<HealthScript>().getHealth() >= 1)
        {
            if (staminaController.playerStamina > 0 && (movingLeft || movingRight))
            {
                staminaController.weAreSprinting = true;
                staminaController.Sprinting();
                animator.SetBool("Sprint", true);
            }
            if (staminaController.playerStamina <= 0)
            {
                staminaController.weAreSprinting = false;

            }

        }
        if (!Input.GetKey(KeyCode.LeftAlt) || (!movingLeft && !movingRight))
        {
            staminaController.weAreSprinting = false;
            animator.SetBool("Sprint", false);


        }
        */



    }

    bool IsGrounded()
    {
        Vector3 centerOfPlayer = GetComponent<BoxCollider>().bounds.center;

        Vector3 rightofPlayer = centerOfPlayer + new Vector3(GetComponent<BoxCollider>().bounds.extents.x - 0.05f, 0f);
        Vector3 leftofPlayer = centerOfPlayer - new Vector3(GetComponent<BoxCollider>().bounds.extents.x - 0.05f, 0f);

        float rayDist = distanceGround;

        bool raycastHit = Physics.Raycast(centerOfPlayer, Vector3.down, rayDist);
        bool raycastHitLeft = Physics.Raycast(leftofPlayer, Vector3.down, rayDist);
        bool raycastHitRight = Physics.Raycast(rightofPlayer, Vector3.down, rayDist);

        Debug.DrawRay(centerOfPlayer, Vector3.down * rayDist, Color.green);
        Debug.DrawRay(leftofPlayer, Vector3.down * rayDist, Color.green);
        Debug.DrawRay(rightofPlayer, Vector3.down * rayDist, Color.green);
        

        return (raycastHit || raycastHitLeft|| raycastHitRight);
    }

    /*void changeScene()
    {

        sceneChanger.GetComponent<SceneChanger>().ChangeScene("InitialScene");
    }

    void stopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
    }
    */

    void StopAllMusic()
    {
        springmusic.Stop();
        summermusic.Stop();
        fallmusic.Stop();
        wintermusic.Stop();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "SpringWorld")
        {
            StopAllMusic();
            springmusic.Play();
        }
        if (scene.name == "SummerWorld")
        {
            StopAllMusic();
            summermusic.Play();
        }
        if (scene.name == "AutumnWorld")
        {
            StopAllMusic();
            fallmusic.Play();
        }
        if (scene.name == "WinterWorld")
        {
            StopAllMusic();
            wintermusic.Play();
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
    }

}

