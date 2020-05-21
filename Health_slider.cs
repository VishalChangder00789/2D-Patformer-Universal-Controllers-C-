//     [Attachments] 
//This script is to be attached with Player_health script..
//       [Content]
//This Scripts controlls the Slider UI settings in the Health Gameobject..
//This take the Slider Component UI as a drag and drop in the Health Gameobject..
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_slider : MonoBehaviour
{
    [Header("Drag and Drops : ")]
    //This refers to the Slider in th Health Gameobject..
    public Slider slider;

    //sets max value of the slider and takes in integer..
    //also sets value of the slider..
    //This function will be used in the beginning of the game as it sets the values at the very beginning of the game.
    public void setmaxhealth(int health)
    {
        //slider.maxValue is the maximum amout of the player's health
        slider.maxValue = health;
        //slider.value sets the fill of the player's health inorder to indicate the health of the player
        slider.value = health;
    }

    //a function to set the health of the player..
    //during the in game motion and the damage taken.
    public void sethealth(int health)
    {
        slider.value = health;
    }


}
