using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int healthValue;      // How much health you currently have, update this when taking damage
    public int numOfHearts; //How many hearts are shown (max health)

    public Image[] hearts;  //Image array for hearts
    public Sprite fullHeart;    
    public Sprite emptyHeart;

    private void Update()
    {
        if(healthValue > numOfHearts) //If your health somehow goes above maximum, set it to max
        {
            healthValue = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < healthValue) //If your health is more than I, displays full hearts
            {
                hearts[i].sprite = fullHeart;
            }else //Other wise show empty hearts ( if taken damage)
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;   //Depending on how many hearts are enabled, show that many
            } else
            {
                hearts[i].enabled = false;
            }
        }
    }

}
