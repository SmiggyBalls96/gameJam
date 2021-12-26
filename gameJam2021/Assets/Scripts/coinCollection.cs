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
        
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = coins.ToString();


        /*
         * if(player touches coin){
         *      update coin value text
         * }
         * if (player spends coin){
         *      update coin value text
         * }
         * 
         * 
         */
    }
}
