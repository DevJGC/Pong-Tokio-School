using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    // Asigna objetos al controlador
    [SerializeField] TMP_Text onePlayer;
    [SerializeField] TMP_Text twoPlayer;
    [SerializeField] AudioClip insertCoin;
    [SerializeField] AudioClip upDown;
    [SerializeField] AudioSource soundOption;
    [SerializeField] Animation insertCoinAnim;


    // Si es TRUE es 1 Jugador, si es FALSE son 2 Jugadores
    [SerializeField] bool isPlayer = true;

    // Variable de datos "PlayerPref" de tipo INT para guardar el número de jugadores
    public int players;


    // Control 1 o 2 jugadores según variable PlayerPrefs
    void Awake()

    {
        // Carga el valor de la variable "PlayerPref" "Players" y lo guarda en la variable "players"
        players = PlayerPrefs.GetInt("Players",1);
        if (players == 1)
        {
            optionPlayer1();
        }
        if (players == 2)
        {
            optionPlayer2();
        }
        
    }

    // Por ahora sin utilizar
    void Start()
    {

    }

    // Cambia entre las opciones de 1 Jugador o 2 Jugadores y comienza partida
    void Update()
    {
        // Selecciona 1 o 2 jugadores pulsando flechas Arriba o Abajo o W - S
        if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.W)))
        {
            optionPlayer1();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetKeyDown(KeyCode.S)))
        {
            optionPlayer2();
        }  

        // Comienza el juego tras pulsar Enter o Space
        if (Input.GetKeyDown(KeyCode.Return) || (Input.GetKeyDown(KeyCode.Space)))
        {
            soundOption.PlayOneShot(insertCoin);
            insertCoinAnim.Play();
            StartCoroutine(LoadScene());
        }

        // Sale de juego
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
        
    }

    // Opción 1 Jugador - Cambia texto - Muestra sonido - Guarda y carga variable PlayerPrefs
    private void optionPlayer1()  
    {
            soundOption.PlayOneShot(upDown);
            onePlayer.text = "-> ONE PLAYER <-";
            twoPlayer.text = "TWO PLAYERS";
            onePlayer.fontSize = 6;
            twoPlayer.fontSize = 5;
            isPlayer = true;
            PlayerPrefs.SetInt("Players",1);
            players = PlayerPrefs.GetInt("Players");          
    }

    // Opción 2 Jugadores - Cambia texto - Muestra sonido - Guarda y carga variable PlayerPrefs
    private void optionPlayer2()
    {
            soundOption.PlayOneShot(upDown);
            onePlayer.text = "ONE PLAYER";
            twoPlayer.text = "-> TWO PLAYERS <-";
            onePlayer.fontSize = 5;
            twoPlayer.fontSize = 6;
            isPlayer = false;
            PlayerPrefs.SetInt("Players",2);
            players = PlayerPrefs.GetInt("Players");
    }

    // Carga escena Juego tras una pequeña pausa
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1f);     
        SceneManager.LoadScene("Game");      
    }

}
