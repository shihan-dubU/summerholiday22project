using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    private float movementX;
    private float movementY;
    //components:

    private Rigidbody2D myBody;

    private Animator anim;

    private SpriteRenderer sr;

    private string WALK_ANIMATION = "Walk";

    private string SHOOT_ANIMATION = "Shoot";

    private bool notShooting;

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
        PlayerMovement();
        AnimatePlayer();
    }

    void PlayerMovement()
    {
        movementX = Input.GetAxis("Horizontal");
        movementY = Input.GetAxis("Vertical");

        Vector2 pos = transform.position;

        pos.x += movementX * speed * Time.deltaTime;
        pos.y += movementY * speed * 0.7f * Time.deltaTime;

        transform.position = pos;
    }

    void AnimatePlayer()
    {
        //cannot move while shooting
        if (notShooting == true)
        {
            return;
        }

        //going towards right
        if(movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        //going towards left
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
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

    //TO DO: add shooting mechanics
}
