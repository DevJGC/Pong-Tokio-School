using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2COM : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] float speed;
    

    void Start()
    {
        ball = GameObject.Find("Ball");
    }

    
    void Update()

    {
        
        if (ball.transform.position.x > 0)
        {
            if (ball.transform.position.y < transform.position.y) 
            {
               
                speed = -6;
            }
            
            
            if (ball.transform.position.y > transform.position.y) 
            {
               
                speed = 6;
            }
        } 

        if (ball.transform.position.x < 0)
        {            
            if (ball.transform.position.y < transform.position.y) 
            {
                
                speed = -1;
            }
            
            
            if (ball.transform.position.y > transform.position.y) 
            {
                
                speed = 1;
            }

        }  

        MovIA();           


    }

    private void MovIA()

    {
        float pMovement;
        pMovement = speed;      
        Vector2 playerPosition = transform.position;
        playerPosition.y = Mathf.Clamp(playerPosition.y + pMovement * Time.deltaTime, -3.9f, 3.9f);
        transform.position = playerPosition;  

    }
}
