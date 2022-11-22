using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 7f;
    [SerializeField] bool isPlayerOne = true;

    public int players;


    void Start()
    {
        
        players = PlayerPrefs.GetInt("Players");
       
        
    }



    
    void Update()
    {
        if (players==2)
        {
            TwoPlayers();
        }
        else
        {
            OnePlayer();
        }
        
     
        
    }

    private void TwoPlayers()
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

    private void OnePlayer()
    {
        float pMovement;
       
        pMovement = Input.GetAxisRaw("VerticalPlayer1");       
        Vector2 playerPosition = transform.position;
        playerPosition.y = Mathf.Clamp(playerPosition.y + pMovement * speed * Time.deltaTime, -3.9f, 3.9f);
        transform.position = playerPosition;  
    }

    
}
