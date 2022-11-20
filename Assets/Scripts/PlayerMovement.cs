using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 7f;
    [SerializeField] bool isPlayerOne = true;
    void Start()
    {
        
    }

    
    void Update()
    {
        float pMovement;

        if (isPlayerOne)
        {
            pMovement = Input.GetAxisRaw("VerticalPlayer1");
        }
        else
        {
            pMovement = Input.GetAxisRaw("VerticalPlayer2");
        }
            

           Vector2 playerPosition = transform.position;
           playerPosition.y = Mathf.Clamp(playerPosition.y + pMovement * speed * Time.deltaTime, -3.9f, 3.9f);
           transform.position = playerPosition;       
        
    }

    
}
