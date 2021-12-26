using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDamage : MonoBehaviour
{
    public int damage = 0;  // How much damage the player takes
    int health = 10;

    public void playerTakeDamage(int damageReceived){   //Updates the value of health based on the damage dealt
        GameObject thePlayer = GameObject.Find("PlayerTemp");
        Health playerScript = thePlayer.GetComponent<Health>();
        playerScript.healthValue -= damageReceived;
        damage = 0;
        health = playerScript.healthValue; // Updates this scripts health value for easier access
    }

    void Update()
    {
        if (damage != 0)
        {
            playerTakeDamage(damage);
        }
        if(health <= 0)
        {
            Debug.Log("Game Over");
        }
    }

}
