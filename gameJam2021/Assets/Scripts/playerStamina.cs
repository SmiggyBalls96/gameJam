using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerStamina : MonoBehaviour
{

    public float staminaValue;      // How much Stamina you currently have, update this when losing stamina
    public int numOfStamina; //How many hearts are shown (max health)

    public Image[] staminaOringal;  //Original Stamina array, this is the one that will be displayed
    public Sprite[] stamina;  //Image array for staminaFull
    public Sprite[] staminaEmpty; //Image array for staminaEmpty

    public Sprite emptyStamina;



    private void Update()
    {
        if (staminaValue > numOfStamina) //If your stamina somehow goes above maximum, set it to max
        {
            staminaValue = numOfStamina;
        }

        //This part is the main code

        for (int i = 0; i < staminaOringal.Length; i++)
        {

            if (i < staminaValue) //If your stamina is more than I, displays full stamina
            {
                staminaOringal[i].sprite = stamina[i];
            }
            else //Other wise show empty stamina ( if lost stamina damage)
            {
                staminaOringal[i].sprite = staminaEmpty[i];
            }

            //This part only matters if I change the stamina value 

            if (i < numOfStamina)
            {
                staminaOringal[i].enabled = true;   //Depending on how much stamina is enabled, show that many
            }
            else
            {
                staminaOringal[i].enabled = false;
            }
        }
    }

}


