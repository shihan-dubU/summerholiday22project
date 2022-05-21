using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    private float movementX;
    private float movementY;
    private float facingX = 1; // 1 and -1 represents left and right but i cant really tell which is which
    //components:

    private Rigidbody2D myBody;

    private Animator anim;

    private SpriteRenderer sr;

    private string WALK_ANIMATION = "Walk";

    private string SHOOT_ANIMATION = "Shoot";

    private bool isShooting;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerShoot();
        PlayerMovement();
        AnimatePlayer();
    }

    void PlayerMovement()
    {
        //if shooting you cannot move.
        if (isShooting == true)
        {
            return;
        }

        movementX = Input.GetAxis("Horizontal");
        movementY = Input.GetAxis("Vertical");

        Vector2 pos = transform.position;

        pos.x += movementX * speed * Time.deltaTime;
        pos.y += movementY * speed * 0.7f * Time.deltaTime;

        transform.position = pos;
    }

    void AnimatePlayer()
    {
        //if shooting you cannot move.
        if (isShooting == true)
        {
            return;
        }

        //MOVEMENT
        //going towards right
        if(movementX > 0)
        {
            if (facingX < 0) //if you are facing to the left, rotate you to the right, set facing to right
            {
                transform.Rotate(0f, 180f, 0f);
                facingX = 1f;
            }
            anim.SetBool(WALK_ANIMATION, true);
            //sr.flipX = false;
        }
        //going towards left
        else if (movementX < 0)
        {
            if (facingX > 0) // if you are facing the right, rotate you to the left, set facing to left
            {
                transform.Rotate(0f, 180f, 0f);
                facingX = -1f;
            }
            anim.SetBool(WALK_ANIMATION, true);
            //sr.flipX = true;
        }
        //moving up or down
        else if (movementY != 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
        }
        //not moving
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerShoot()
    {
        if (Input.GetButtonDown("Fire1") && anim.GetBool(WALK_ANIMATION) == false)
        {
            Debug.Log("PlayerShoot called");
            isShooting = true;
            anim.SetBool(SHOOT_ANIMATION, true);
        }
    }

    void ShootComplete()
    {
        Debug.Log("Shoot Complete!");
        isShooting = false;
        anim.SetBool(SHOOT_ANIMATION, false);
    }

    //TO DO: add shooting mechanics

    //this method is to be called during the shooting animation.
    void fireWeapon()
    {
        Debug.Log("Fire Projectile!");
        //over here you can do smth like get weapon, call shoot method
    }
}
