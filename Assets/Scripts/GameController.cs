using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    // Todos los objetos y componentes del controlador
    [SerializeField] GameObject ball;
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] TMP_Text player1ScoreText;
    [SerializeField] TMP_Text player2ScoreText;
    [SerializeField] TMP_Text textIntro;
    [SerializeField] Animation animText;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;
    [SerializeField] AudioClip complet; 

    // Score Player 1
    public int player1Score;

    // Score Player 2
    public int player2Score;

    // Saber si se está en juego
    bool isPlaying = false;

    // Número de jugadores
    public int players;

    void Start()
    {
        // Carga en la variable "players" el valor guardado en PlayerPrefs para saber si es un jugador o dos
        players = PlayerPrefs.GetInt("Players");

        // Si es un único jugador, desactiva Script 2 jugadores y activa segundo jugador controlado por IA
        if (players==1)
        {
            player2.GetComponent<PlayerMovement>().enabled = false;
            player2.GetComponent<Player2COM>().enabled = true;
        }
    }

    // Si pulsa Space y aún no ha comenzado el juego, le da comienzo
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isPlaying)
        {
            StartCoroutine("clearText");
            isPlaying = true;
        }

        // Al pulsar Escape sale al Menú de inicio
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    // Revisa la puntuación de los jugadores y termina cuando el primero llega a 10 puntos y lo muestra por pantalla
    void CheckScore()  
    {
        if (player1Score == 10)
        {
            player1ScoreText.color = Color.yellow;
            player1ScoreText.text = "\n Player 1 Wins!!";
            player2ScoreText.text = "\n Player 2 Loses!";
            StartCoroutine("resetGame");
        }

        if (player2Score == 10)
        {
            player2ScoreText.color = Color.yellow;
            player1ScoreText.text = "\n Player 1 Loses!";
            player2ScoreText.text = "\n Player 2 Wins!!";
            StartCoroutine("resetGame");
        }
    }

    // Resetea el juego volviendo los valores a su origen y vuelve al Menú
    IEnumerator resetGame()
    {
        source.PlayOneShot(complet);
        yield return new WaitForSeconds(1f);
        ball.GetComponent<BallMovement>().velocity = 0;
        ball.transform.position = new Vector2(0, 0); 
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Menu");  
    }

    // Suma 1 punto al jugador 1 y lo muestra por pantalla. Resetea bola para sacar desde puerta
    public void Player1Scored()
    {
        player1Score++;
        player1ScoreText.text = player1Score.ToString();
        Invoke("ResetBall1",1f);
        CheckScore();
    }

    // Suma 1 punto al jugador 2 y lo muestra por pantalla. Resetea bola para sacar desde puerta
    public void Player2Scored()
    {
        player2Score++;
        player2ScoreText.text = player2Score.ToString();
        Invoke("ResetBall2", 1f);
        CheckScore();
    }

    // Saca desde puerta jugador
    public void ResetBall1()
    {
        ball.transform.position = new Vector3(5, 0, 0);
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        ball.GetComponent<BallMovement>().directionX = ball.GetComponent<BallMovement>().directionX * -1;
    }

    // Saca desde puerta jugador
    public void ResetBall2()
    {
        ball.transform.position = new Vector3(-5, 0, 0);
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        ball.GetComponent<BallMovement>().directionX = ball.GetComponent<BallMovement>().directionX * -1;
    }

    // Borra texto e inicia partida
    IEnumerator clearText()
    {
        animText.Play();
        ball.GetComponent<BallMovement>().velocity = 2;
        source.PlayOneShot(clip);
        yield return new WaitForSeconds(.5f);
        textIntro.text = " ";
    }
}
