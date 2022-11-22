using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public int directionX;
    public int directionY;

    int direInicial;

    public float velocity;
    [SerializeField] int hits;
    [SerializeField] AudioSource sounds;
    [SerializeField] AudioClip clipHit;
    [SerializeField] AudioClip win;
    [SerializeField] AudioClip lose;


    void Start()
    {
        // Inicia la bola 
        directionStart();

    }


    void FixedUpdate()
    {
        // Mueve la bola
        transform.Translate((directionX) * Time.deltaTime * velocity, (directionY) * Time.deltaTime * velocity, 0);

    }

  
    // Detecta colisiones con paredes o techo/suelo - Resta una vida en cada choque y resetea a los 10
    private void OnCollisionEnter2D(Collision2D other)
    {
       
        sounds.PlayOneShot(clipHit);
        
        if (other.gameObject.tag == "Left_Right")
        {
            //Debug.Log("Hay colision con pared");
            // Invierte direccion en X
            directionX = directionX * -1;
            velocity = velocity + 0.5f;

        }

        if (other.gameObject.tag == "Up_Down")
        {
            //Debug.Log("Hay colision con techo");
            // Invierte direccion en Y
            directionY = directionY * -1;
        }
        
        // Resta una vida y si llega a 0 resetea
        
        //hits--;
        //if (hits == 0)
        //{
        //    directionStart();
        //}

    }




    // Inicia la bola en una direccion aleatoria y mira si no tiene vida, en cuyo caso resetea
    void directionStart()
    {
        //if (hits == 0)
        //{
        //    transform.position = new Vector3(0, 0, 0);
        //    hits = 10;
        //    velocity = 2;
        //}

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
