using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public int player1Score;

    public int player2Score;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            StartCoroutine("clearText");



        }
    }

    public void Player1Scored()
    {
        player1Score++;
        player1ScoreText.text = player1Score.ToString();
        Invoke("ResetBall1",1f);
    }

    public void Player2Scored()
    {
        player2Score++;
        player2ScoreText.text = player2Score.ToString();
        Invoke("ResetBall2", 1f);
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
