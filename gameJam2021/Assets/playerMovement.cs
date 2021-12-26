using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float enduranceTimer = 0f;  //Counter, once it reaches one second, goes back to zero and adds 1 to sprintTimer  
    public float sprintTimer = 0f; // How long you've sprinted for in seconnds

    public float sprintDelay = 0f; // Delay between exhausting your endurance and before you can sprint again, increases by 5 seconds every time you exhaust endurance (5 second sprint cooldown)

    public Rigidbody2D rigidBody;

    Vector2 movement;

    bool Sprint = false;

    
    void Update()
    {
        enduranceTimer += Time.deltaTime;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        if (!Sprint)    //If not sprinting then and pressing control, then sprint
        {
            if(Input.GetKey(KeyCode.LeftControl) == true && sprintTimer < 5 && sprintDelay == 0)   // You can only sprint for 5 seconds, and if your delay between sprintign and resting is over
            {
                movementSpeed = 10f;
                if (enduranceTimer >= .5) //Every second increase sprintTimer 
                {   
                    enduranceTimer = 0f;
                    sprintTimer++;
                    Debug.Log(sprintTimer);
                }
            } else
            {
                movementSpeed = 5f;
                if (enduranceTimer >= .5 && sprintTimer > 0) //Every second decrease sprintTimer
                {
                    enduranceTimer = 0f;
                    sprintTimer--;
                    sprintDelay--;

                    //Debug.Log(sprintTimer);
                    //Debug.Log(sprintDelay);
                }
                if (sprintTimer == 5)
                {
                    sprintDelay = 5; //Increase the delay between sprints by 5 seconds every time endurance is exhausted
                }
                
            }
        }

    }
    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
