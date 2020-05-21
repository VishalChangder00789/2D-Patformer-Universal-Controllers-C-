//     [Attachments] 
//This script has to be attached to an Empty gameobject with istrigger option checked in the inspector Menu.
//      [Content]
//This will Trigger the weaponry system for the enemies..
//Works as One trigger for one enemy if the class names are different..
//Need to be connected to Static_Enemy_Weapon_Controller_with_Shoot..
//Works better with a circle collider..
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Activator_Zone : MonoBehaviour
{
    [Header("Circle Collider Dynamics")]
    [SerializeField]
    public float spawningtime = 1.0f;

    [Header("Script Attachments")]
    public Static_Enemy_Weapon_Controller_with_shoot shoottrigger;

    //OnTrigger is activated only by Main Characters Tag.
    //Name of the circle collider is kept as circle_collider_activator.
    //This function will access the Coroutine function of the Script Static_Enemy_Weapon_Controller_with_shoot.
    // Start is called before the first frame update

    public void OnTriggerEnter2D(Collider2D circle_collider_activator)
    {
        if (circle_collider_activator.gameObject.tag == "Toby")
        {
            //starts coroutine fucntions...
            StartCoroutine(shoottrigger.respawn_bullet());

        }
    }
}
