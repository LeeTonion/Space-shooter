
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UI_Manager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textscore, textbestscore;
    [SerializeField] private Image _image1, _image2;
    [SerializeField] private Sprite[] _livesprite;
    [SerializeField] private TextMeshProUGUI textgameover,teststartgame;
    [SerializeField] private TextMeshProUGUI restart;
    private bool player1destroy, player2destroy;
    private Player player1;
    private Player player2;
    private GameObject menupause;
    private Game_Manager game;
    private SpawnManager spawnManager;
    private int score;
    static int bestscore = 0;

    void Start()
    {
        textscore.text = "Score : " + 0;
        textbestscore.text = "Best :" + bestscore;
        menupause = GameObject.Find("GameManager");
        game = menupause.GetComponent<Game_Manager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        GameObject gameplayer1 = GameObject.Find("Player 1");
        if (gameplayer1 != null) { player1 = gameplayer1.GetComponent<Player>(); }
        GameObject gameplayer2 = GameObject.Find("Player 2");
        if (gameplayer2 != null) { player2 = gameplayer2.GetComponent<Player>(); }
        StartCoroutine(StartGame());
    }



    public void UpdateScore(int ScorePlayer)
    {
        textscore.text = "Score : " + ScorePlayer.ToString();
        score = ScorePlayer; ;

    }
    public void CheckForBestScore()
    {
        if (score > bestscore)
        {
            bestscore = score;
            textbestscore.text = "Best : " + bestscore;

        }
    }
    public void UpdateLive1(int currentLive)
    {
        if (player1 != null)
        {
            if (player1._player1) { _image1.sprite = _livesprite[currentLive]; }
        }

        if (currentLive == 0)
        {
            player1destroy = true;
        }
        if (player2destroy && player1destroy)
        {
            CheckForBestScore();
            gameover();
        }
        else if (SceneManager.GetActiveScene().name == "1 player" && player1destroy)
        {
            CheckForBestScore();
            gameover();
        }
    }
    public void UpdateLive2(int currentLive)
    {

        if (player2 != null)
        {
            if (player2._player2) { _image2.sprite = _livesprite[currentLive]; }
        }
        if (currentLive == 0)
        {
            player2destroy = true;
        }
        if (player2destroy && player1destroy)
        {
            CheckForBestScore();
            gameover();
        }


    }
    public void gameover()
    {
        if (spawnManager != null) { spawnManager.isEnemy(); }
        textgameover.gameObject.SetActive(true);
        restart.gameObject.SetActive(true);
        game.SetGameOver();
        StartCoroutine(GameoverFlick());
    }
    IEnumerator StartGame()
    {
   
            while (true)
            {
                teststartgame.text = "";
                yield return new WaitForSeconds(0.5f);
            teststartgame.text = "Nhấn Space để bắt đầu !";
                yield return new WaitForSeconds(0.5f);
            }
    }
    IEnumerator GameoverFlick()
    {
        while (true)
        {
            textgameover.text = "";
            yield return new WaitForSeconds(0.5f);
            textgameover.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
        }
    }
    public void Resume()
    {
        Game_Manager game = GameObject.Find("GameManager").GetComponent<Game_Manager>();

        game.Resume();
    }
    public void mainmenu()
    {
        SceneManager.LoadScene("menu");
        Time.timeScale = 1;
        bestscore = 0;  
    }
}