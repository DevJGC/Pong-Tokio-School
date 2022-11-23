using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // Direcciones Ball
    public int directionX;
    public int directionY;

    // Dirección aleatoria inicial Ball
    int direInicial;

    // Velocidad Ball
    public float velocity;

    // Contador de toques con las paredes o paletas
    [SerializeField] int hits;

    // Sonidos
    [SerializeField] AudioSource sounds;
    [SerializeField] AudioClip clipHit;
    [SerializeField] AudioClip win;
    [SerializeField] AudioClip lose;


    void Start()
    {
        // Inicia la bola en una dirección aleatoria
        directionStart();
    }


    void FixedUpdate()
    {
        // Mueve la bola
        transform.Translate((directionX) * Time.deltaTime * velocity, (directionY) * Time.deltaTime * velocity, 0);
    }

  
    // Detecta colisiones con paredes o techo/suelo
    private void OnCollisionEnter2D(Collision2D other)
    {     
        // Sonido colisión Ball
        sounds.PlayOneShot(clipHit);

        // Si choca con las paletas (Izquierda o Derecha)
        if (other.gameObject.tag == "Left_Right")
        {         
            // Invierte direccion en X
            directionX = directionX * -1;
            velocity = velocity + 0.5f;
        }

        // Si toca con el techo o suelo
        if (other.gameObject.tag == "Up_Down")
        {          
            // Invierte direccion en Y
            directionY = directionY * -1;
        }
        
        // Contador de toques de Ball con cualquier cosa
        hits--;
        if (hits == 0)
        {
            // Tras llegar a 0 resetea Ball

            //directionStart();
        }
    }


    // Inicia la bola en una direccion aleatoria y mira si no tiene vida, en cuyo caso resetea
    void directionStart()
    {
        // Cuando los toques llegan a 0 resetea Ball

        //if (hits == 0)
        //{
        //    transform.position = new Vector3(0, 0, 0);
        //    hits = 10;
        //    velocity = 2;
        //}

        // Dirección aleatoria al comienzo de la partida
        direInicial = Random.Range(1, 5);

        switch (direInicial)
        {
            case 1:
                directionX = 1;
                directionY = 1;
                break;
            case 2:
                directionX = -1;
                directionY = 1;
                break;
            case 3:
                directionX = 1;
                directionY = -1;
                break;
            case 4:
                directionX = -1;
                directionY = -1;
                break;
            default:
                // Debug.Log("No hay direccion!!");
                break;
        }
    }
}
