using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2COM : MonoBehaviour
{
    // Controlador IA player 2
    // Carga objetos y crea variables
    [SerializeField] GameObject ball;
    [SerializeField] float speed;
    
    // Busca la Bola y la inicializa
    void Start()
    {
        ball = GameObject.Find("Ball");
    }

    // Contro de movimiento de raqueta IA
    // Comportamiento ligeramente impreciso para dar realismo a la IA
    void Update()
    {       
        // Si la bola está en su campo se mueve más rápido
        if (ball.transform.position.x > 0)
        {
            if (ball.transform.position.y < transform.position.y) 
            {             
                speed = -7;
            }
                      
            if (ball.transform.position.y > transform.position.y) 
            {         
                speed = 7;
            }
        } 

        // Si la bola está en campo contrario, se mueve más lento
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

        // Llama al movimiento
        MovIA();           

    }

    // Crea movimiento raqueta IA según velocidad y posición de la bola
    private void MovIA()
    {
        float pMovement;
        pMovement = speed;      
        Vector2 playerPosition = transform.position;
        playerPosition.y = Mathf.Clamp(playerPosition.y + pMovement * Time.deltaTime, -3.9f, 3.9f);
        transform.position = playerPosition;  
    }
}
