using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggeringaction : MonoBehaviour
{
    public Text_setter setter;

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.tag=="Toby")
    //    {
    //        setter.at_every_update();
    //        Destroy(this.gameObject);
    //    }
    //}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Toby")
        {
            setter.at_every_update();
            Destroy(this.gameObject);
        }
    }
}
