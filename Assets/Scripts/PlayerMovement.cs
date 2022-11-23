using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movimientos raquetas
    // Crea variables
    [SerializeField] float speed = 7f;
    [SerializeField] bool isPlayerOne = true;

    // N�mero de jugadores
    public int players;

    // Carga el n�mero de jugadores por PlayerPrefs
    void Start()
    {       
        players = PlayerPrefs.GetInt("Players");       
    }

    // Carga funci�n de movimiento de raquetas seg�n est� jugando uno o dos personas
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

    // Al ser 1 jugador, �nicamente toma el Input por Axis de un jugador
    private void OnePlayer()
    {
        float pMovement;      
        pMovement = Input.GetAxisRaw("VerticalPlayer1");       
        Vector2 playerPosition = transform.position;
        playerPosition.y = Mathf.Clamp(playerPosition.y + pMovement * speed * Time.deltaTime, -3.9f, 3.9f);
        transform.position = playerPosition;  
    }
}
