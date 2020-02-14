using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    //Put this component on the Player!


    // Create private references to the count of pick up objects picked up so far
    public int CoinsNeeded;
    public string CoinsCollisionTag;
    public GameObject ObjectToToggle;
    public Text countText;
    public Text winText; 

    private int count;

    // At the start of the game..
    void Start()
    {

        // Set the count to zero 
        count = 0;
        SetCountText();
        winText.text = ""; 

    }

    
    void OnTriggerEnter(Collider other)
    {
        // ..and if the game object we intersect has the tag we choose assigned to it..
        if (other.gameObject.CompareTag(CoinsCollisionTag))
        {
            // Make the other game object (the pick up) inactive, to make it disappear
            other.gameObject.SetActive(false);

            // Add one to the score variable 'count'
            count = count + 1;
            // Run the 'SetCountText()' function (see below)
            SetCountText ();
        }
    }


    // Create a standalone function that can check if the required amount to win has been achieved
    void SetCountText()
    {
        countText.text = "Count: " + countText.ToString();
        if (count >= 6)
        {
            winText.text = "You Win!"; 
        }
        // Check if our 'count' is equal to or exceeded the number we choose and toggle on/off the object chosen
        if (count >= CoinsNeeded)
        {
            ObjectToToggle.SetActive(!ObjectToToggle.activeInHierarchy);
        }
    }
}