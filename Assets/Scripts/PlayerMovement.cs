using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movimientos raquetas
    // Crea variables
    [SerializeField] float speed = 7f;
    [SerializeField] bool isPlayerOne = true;

    // Número de jugadores
    public int players;

    // Carga el número de jugadores por PlayerPrefs
    void Start()
    {       
        players = PlayerPrefs.GetInt("Players");       
    }

    // Carga función de movimiento de raquetas según esté jugando uno o dos personas
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

    // Al ser 2 jugadores, toma los Inputs desde dos Axis distintos
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

    // Al ser 1 jugador, únicamente toma el Input por Axis de un jugador
    private void OnePlayer()
    {
        float pMovement;      
        pMovement = Input.GetAxisRaw("VerticalPlayer1");       
        Vector2 playerPosition = transform.position;
        playerPosition.y = Mathf.Clamp(playerPosition.y + pMovement * speed * Time.deltaTime, -3.9f, 3.9f);
        transform.position = playerPosition;  
    }
}
