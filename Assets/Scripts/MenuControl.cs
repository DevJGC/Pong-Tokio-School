using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    [SerializeField] TMP_Text onePlayer;
    [SerializeField] TMP_Text twoPlayer;
    [SerializeField] AudioClip insertCoin;
    [SerializeField] AudioClip upDown;
    [SerializeField] AudioSource soundOption;
    [SerializeField] Animation insertCoinAnim;


    // Si es TRUE es 1 Jugador, si es FALSE son 2 Jugadores
    [SerializeField] bool isPlayer = true;
    void Start()
    {
        onePlayer.text = "-> ONE PLAYER <-";
        onePlayer.fontSize = 6;
        twoPlayer.fontSize = 5;      
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.W)))
        {
            soundOption.PlayOneShot(upDown);
            onePlayer.text = "-> ONE PLAYER <-";
            twoPlayer.text = "TWO PLAYERS";
            onePlayer.fontSize = 6;
            twoPlayer.fontSize = 5;
            isPlayer = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetKeyDown(KeyCode.S)))
        {
            soundOption.PlayOneShot(upDown);
            onePlayer.text = "ONE PLAYER";
            twoPlayer.text = "-> TWO PLAYERS <-";
            onePlayer.fontSize = 5;
            twoPlayer.fontSize = 6;
            isPlayer = false;
        }  

        if (Input.GetKeyDown(KeyCode.Return) || (Input.GetKeyDown(KeyCode.Space)))
        {
            soundOption.PlayOneShot(insertCoin);
            insertCoinAnim.Play();
            StartCoroutine(LoadScene());
        }
        
    }

 IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1f);     
        SceneManager.LoadScene("Game");      
    }


    
}
