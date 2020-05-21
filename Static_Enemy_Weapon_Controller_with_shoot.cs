//          [Attachment]
//This script has to attached to an Empty Gameobject that is child of the Enemy prefab gameobject.
//This Empty gameobject is the firing point of the Enemy prefab Gameobject.
//          [Content]
//This Script Instantiates Bullet with a Coroutine respawn timer..
//Coroutine Respawn Timer is the function used to involve in betwwen time for every consecutive prefab instantiates.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Static_Enemy_Weapon_Controller_with_shoot : MonoBehaviour
{


    [Header("Drag and Drop : ")]
    [Space]

    public GameObject enemy;
    //represents the empty gameobject object from where the bullet will eject
    public Transform firepoint;
    //The folder selection in which the bullet will be residing.
    public GameObject Bullet_prefabs;
   
    [Header("Adjustable : ")]
    [Space]
   
    //The amount of time until the next bullet will start ejecting.
    //In between time of the following bullet.
    [SerializeField]public float respawntime=5.0f;

    // Start is called before the first frame update
    
    void bullet_fire()
    {
        Instantiate(Bullet_prefabs, firepoint.position, firepoint.rotation);
    }
    public IEnumerator respawn_bullet()
    {
        while(enemy.active)
        {
            yield return new WaitForSeconds(respawntime);
            bullet_fire();
        }
        
        
    }




}
