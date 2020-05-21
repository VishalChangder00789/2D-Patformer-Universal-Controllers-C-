//     [Attachments] 
//This script has to be attached to the main player..
//        [Content]
//This Script controls the health system of the player.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_health : MonoBehaviour
{
    [Header ("Health Dynamics :")]
    public int max_health=5;
    public int current_health;

    [Header ("Drag and Drop :")]
    [SerializeField]public Health_slider Healthcontroller;

    void Start()
    {
        //sets the current health of the player at the very beginning of the game.
        current_health = max_health;
        //sets the maximum health that a player can posses at the very beginning of the game
        Healthcontroller.setmaxhealth(max_health);
    }

    //This function is used to provide damage to the player..
    //This function decreases the value of the players health ans also sets the sliders value
    //in the HealthBar gameobject 
    void takedamage(int damage)
    {
        current_health = current_health - damage;
        Healthcontroller.sethealth(current_health);
    }
    
    //Only trriggered when the player collides with Enemy Eagle collider.
    //is triggerd must on checked..
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            takedamage(2);
            if (current_health < 0)
            {
                Destroy(this.gameObject);

            }
        }
        else if (collision.gameObject.tag == "Enemy Bullet")
        {
            takedamage(1);
            if (current_health < 0)
            {
                Destroy(this.gameObject);
            }
        }
        else if (collision.gameObject.tag == "Enemy" && current_health < 0)
        {
            Destroy(this.gameObject);

        }
    }
//Repeat code for better effects.
//Subject to testing in the game..
//Can be removed but it could alter some Player Death mechanics..
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            takedamage(1);

            if (current_health < 0)
            {
                Destroy(this.gameObject);

            }

        }
    }

}
