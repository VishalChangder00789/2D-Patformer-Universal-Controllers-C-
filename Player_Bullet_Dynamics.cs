//          [Attachment]
//This script is attached with the player's bullet..
//            [Content]
//It will contain the information about how the bullet will travel in Game World space.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Bullet_Dynamics : MonoBehaviour
{
    [Header("Drag and Drop : ")]
    //Bullet prefab drag and drop.
    public Rigidbody2D player_bullet_rigidbody;
    [Header("Bullet Dynamics : ")]
    public float speed = 20f;

    void Start()
    {
        //sets the velocity of the bullet with which it will propogate.
        player_bullet_rigidbody.velocity = transform.right * speed;
    }
}
