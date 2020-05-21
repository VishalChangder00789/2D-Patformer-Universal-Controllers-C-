//      [Attachment]
//This script is attached with the player's bullet prefabs.
//        [Content]
//This script will decide if the bullet is hitting the Enemy or not..
//This script will do certain things if the bullet hits the Enemy
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_effect : MonoBehaviour
{
    //Only an OnTrigger option is stated here as it will only trigger below statements if the player's 
    //bullet collider enters  the enemy colliders..
    private void OnTriggerEnter2D(Collider2D player_bullet_collider)
    {
        //if the player_bullet_collider touches a gameobject with tag Enemy or someother tag name
        //the player bullet will setactive to false.

        //The enemy gameobject will be destroyed.
        if (player_bullet_collider.tag=="Enemy" || player_bullet_collider.tag=="someother")
        {
            //The bullet will be setactive to false.
            player_bullet_collider.gameObject.SetActive(false);
            //The enemy will be destroyed.
            Destroy(this.gameObject);
        }
    }
}
