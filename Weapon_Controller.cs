//     [Attachment]
//This script is attached to an Empty Gameobject as a firing point from where the prefab will instantiate.
//       [Content]

//This script controls the Weapon Trigger Mechanism with KEY--->"F"..
//This script only instantiates a prefab to its desired position...
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Controller : MonoBehaviour
{
    [Header("Drag and Drop : ")]
    public Transform firepoint_position;
    public GameObject bulletprefab;

    
    void Update()
    {
        //If "F" key is pressed then the fucntion will be called upon..
       if(Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }

    //Simple logic to instantiate a gameobject to a desired position..
    void Shoot()
    {
        //This method takes 3 argument.
        //1.bullet prefab---------->what to instantiate..
        //2.firepoint_position.position--------->where to instantiate..
        //3. firepoint_position.rotation---------> How to instantiate (as in what will be it stransform type.)
        Instantiate(bulletprefab, firepoint_position.position, firepoint_position.rotation);
    }

}
