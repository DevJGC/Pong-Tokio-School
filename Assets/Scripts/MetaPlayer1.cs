using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaPlayer1 : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    [SerializeField] GameController gameController;
    [SerializeField] BallMovement ball;


    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            audioSource.PlayOneShot(audioClip);
            gameController.Player2Scored();
            ball.velocity = 2;
        }
    }

}
