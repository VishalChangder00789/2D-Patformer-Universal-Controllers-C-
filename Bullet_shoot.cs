//     [Attachments] 

//This Script is to be attacehd with the Enemy Bullet prefabs...

//       [Content]

//This script controls the Enemy's Bullet Movement in two major ways..
//1. The bullet follows the target's old location..
//2. The Bullet will be shot in a single direction.

//3. Bonus :
                //The bullet can follow the player also..
                //The targets location has to be defined in the update method rather than the start method..

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Bullet_shoot : MonoBehaviour
{
    //(The marked green below will enable the bullet to follow the players location...(current location) if uncommented)..
    //[Header("Drag and Drop : ")]
    //Static_Enemy_Weapon_Controller_with_shoot controller;
    //[Header("Player Dynamics Controller : ")]
    //Rigidbody2D bullet_rigidbody;

    [Header("Bullet Dynamics : ")]
    public float bullet_speed;

    //Accessing the component of the bullet..
    private Transform player;
    public Vector2 target;

    public void Start()
    {
        //(The marked green below will enable the bullet to follow the players location...(current location) if uncommented )..
        //bullet_rigidbody = transform.GetComponent<Rigidbody2D>();


        //Finding the component of the gameobject with tag..
        //setting the target
        player = GameObject.FindGameObjectWithTag("Toby").GetComponent<Transform>();
        target = new Vector2(player.position.x, player.position.y);
        
    }
    //Function to control the bullet prefab after it is Instantiated.
    public void movebullet()
    {
        //This fucntion takes in 3 component
            //1. transform.position---->enemy bullet's current posiiton  ..i.e--->firing point.
            //2. target--------->since target is a vector2 variable so (.position) is not added..it is the taget's position.
            //3. speed of bullet...(As the name suggests.)
        transform.position = Vector2.MoveTowards(transform.position, target, bullet_speed * Time.deltaTime);

        //when the bullet reaches its target the bullet will be destroyed.
        if (transform.position.x==target.x && transform.position.y==target.y)
        {
            //destroying the bullet.
            Destroy(this.gameObject);
        }
    }
    public void Update()
    {
        //(The marked green below will enable the bullet to follow the players location...(current location) if uncommented )..
        //bullet_rigidbody.velocity = transform.right * bullet_speed;

        //Above function is called every frame time..
        movebullet();
    }

}
