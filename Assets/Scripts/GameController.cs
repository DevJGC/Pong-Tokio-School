using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
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

    public int player1Score;

    public int player2Score;

    bool isPlaying = false;

    public int players;

    void Start()
    {
        players = PlayerPrefs.GetInt("Players");


        if (players==1)
        {
            //player2.SetActive(false);
            player2.GetComponent<PlayerMovement>().enabled = false;
            player2.GetComponent<Player2COM>().enabled = true;
        }

    }

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isPlaying)
        {

            StartCoroutine("clearText");

            isPlaying = true;

        }
    }

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


    public void Player1Scored()
    {
        player1Score++;
        player1ScoreText.text = player1Score.ToString();
        Invoke("ResetBall1",1f);
        CheckScore();

    }

    public void Player2Scored()
    {
        player2Score++;
        player2ScoreText.text = player2Score.ToString();
        Invoke("ResetBall2", 1f);
        CheckScore();
    }

    public void ResetBall1()
    {
        ball.transform.position = new Vector3(5, 0, 0);
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        ball.GetComponent<BallMovement>().directionX = ball.GetComponent<BallMovement>().directionX * -1;
    }

    public void ResetBall2()
    {
        ball.transform.position = new Vector3(-5, 0, 0);
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        ball.GetComponent<BallMovement>().directionX = ball.GetComponent<BallMovement>().directionX * -1;
    }

    IEnumerator clearText()
    {
        animText.Play();
        ball.GetComponent<BallMovement>().velocity = 2;
        source.PlayOneShot(clip);
        yield return new WaitForSeconds(.5f);
        textIntro.text = " ";

    }

}
