using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Numerics;
using UnityEngine.Events;

public class Player_Controller_2D : MonoBehaviour
{
    [Header("Player Position Dynamics : ")]
    //Defining serialisable Game In-built variable..
    [SerializeField] private bool player_facing_right;
    [SerializeField] private float player_jump_force;
    //[SerializeField] public float player_run_speed;
    [Range(0, .3f)] [SerializeField] private float movement_smoothing = .05f;


    [Header("Ground Check Mechanism : ")]
    [Space]

    [SerializeField] Transform ground_check_object;
    [SerializeField] private LayerMask what_is_ground;
     


    [Header("Events : ")]
    [Space]
    UnityEvent OnLandEvent;


    //Defining common variable
    public Rigidbody2D player_rigidboy;
    private bool player_is_grounded;
    const float Overlap_Circle_Radius = 0.2f;
    private Vector3 movement_velocity = Vector3.zero;



    private void Awake()
    {
        player_rigidboy = transform.GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
        {
            //Stores the current event happening..
            OnLandEvent = new UnityEvent();
        }
    }
    void FixedUpdate()
    {
        bool player_was_grounded = player_is_grounded;
        player_is_grounded = false;

        // The Colliders2D[] is an array
        // It will be registering every collider applied on anything that our player will touch.

        // Since the jump mechanism is determined by the "Layer Mask ---> what_is_ground" so the gameobjects will not be recognised
        //by the "ground_checking_object"

        Collider2D[] colliders = Physics2D.OverlapCircleAll(ground_check_object.position,Overlap_Circle_Radius,what_is_ground);

        //using for loop enables us to check each and every part of the collider(Overlap circle surface) if it is a ground or not.
        for (int i = 0; i <= colliders.Length; i++)
        {
            // Basically the if condition is checking if the collider at the position i is any gameobject's collider or not.
            //if the collider doesn't finds a gameobject then it must be a "Layer Mask" and hence the OverlapCircleALL is hitting the ground..

            if (colliders[i].gameObject != gameObject)
            {
                player_is_grounded = true;

                if (!player_was_grounded)
                {
                    //Based on my starting scene 
                    // "OnLandEvent" is storing an event from the awake method..
                    //To be simplified.. This will register a standing state of the player to recognise if the player is not on anything.
                    OnLandEvent.Invoke();
                }

            }

        }

    }
    public void Move(float move, bool jump)
    {
       //A target velocity for the player to move 
        UnityEngine.Vector3 targetVelocity = new UnityEngine.Vector2(move * 10f, player_rigidboy.velocity.y);
        //A smooth damping system will help smooth the movement.
        player_rigidboy.velocity = Vector3.SmoothDamp(player_rigidboy.velocity,targetVelocity,ref movement_velocity,movement_smoothing);



        //conditions for fliping the movement of the player

        //if the player is moving in the righ tdirection that gives us the horizontal axis of +1 and thus if the player is not facing right..
        // a flip function is called where....."!player_facing_right" is exchanged with "player_facing_right".... To be more thorough
        //Refer to the "Flip_player()"...
        if (move>0 && !player_facing_right)
        {
            Flip_player();
        }
        //if the player is moving left that is if we get the value of horizontal axis as -1 then the player is moving left and also if the
        // player is facing right then the "Flip_player()" is called and the player flips to the left..
        else if(move<0 && player_facing_right)
        {
            Flip_player();
        }

        //Condition to check is the player is ground and is ready for the jump..
        if(player_is_grounded && jump)
        {
            player_is_grounded = false;

            // player_rigidboy.AddForce(new Vector2(0f, player_jump_force));
            player_rigidboy.velocity = new Vector2(0f, player_jump_force);
        }

    }

    //"Flip_player()" is called conditionally and can only be accessed if the function is called...
    // it is independent of the update().
    public void Flip_player()
    {
        //checks for the condition..
        //this is a by conditional bool checking statement.
        //if one of them is false then it is converted to the another bool..

        //For example if the player is facing right and the "Flip_player()" is called in a condition where it is required to 
        //change the players condition to player not facing right then the statements will be changing their values...
        player_facing_right = !player_facing_right;
        
        //Local scaling is not used.
        //Transform.Rotate is used..

        //One issue of this is-------------------->If i use a sprite rendere.flipx then if any game object is 
        //attached to my player it will not flip...
        transform.Rotate(0, 180, 0);
                    
                    //ISSUES WITH THIS MAY BE RESOLVED LATER..
    }
}

