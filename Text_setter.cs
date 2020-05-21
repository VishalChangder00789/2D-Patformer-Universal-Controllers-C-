//         [Attachment]
//This script has to be attaches with the text UI inside the canvas..
//           [Content]
// This script does:
        //sets the coins value to 0 at the initial stage of the game;
        //if the player runs into a coin then this script has a function to update each coin value increments by 1..
        //This script also modifies the text acoording to the string coverted from the integer 
        //with the help of int.tostring()
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Text_setter : MonoBehaviour
{
    [Header("Drag and Drop : ")]
    public Text text;

    //Variable declaration..
    //for the coin value at the very beginning of the game
    private string coins_at_the_beginning;
    //for the coin value after every update of the game.
    private string coins_at_every_update;
    //This will keep the value of the initial coin counter so as to convert the coins value of in type
    //to string type...
    private int coins;


    // coin value of type int is set to 0
    //same value is store in a string
    //then passed to text ui...
    void Start()
    {
        coins = 0;
        coins_at_the_beginning = coins.ToString();
        text.text=(coins_at_the_beginning); 
    }

    //This function is used at every point of update..

    public void at_every_update()
    {
        //temporary int value..
        int temp;

        coins = coins + 1;
        temp = coins;
        coins_at_every_update = temp.ToString();
        text.text = (coins_at_every_update);

    }
}
