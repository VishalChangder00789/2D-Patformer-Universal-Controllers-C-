using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Player_Controller_2D controller2D;
    float horizontal_move = 0f;
    bool jump = false;
    public float runspeed = 40f;


    // Update is called once per frame
    void Update()
    {
        horizontal_move = Input.GetAxisRaw("Horizontal") * runspeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

    }
    void FixedUpdate()
    {
        controller2D.Move(horizontal_move * Time.fixedDeltaTime, jump);
        jump = false;
    }

}
