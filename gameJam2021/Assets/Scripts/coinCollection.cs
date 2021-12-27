using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinCollection : MonoBehaviour
{
    private BoxCollider2D bc;
    private Rigidbody2D rb;     
    public Text txt;    //Text that will update

    public int coins;
    void Start()
    {
        gameObject.tag = "Player";
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Check to see if the tag on the collider is equal to Enemy
        if (other.gameObject.CompareTag("coin"))
        {
            coins++;
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = coins.ToString();
    }
}
