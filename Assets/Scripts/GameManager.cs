using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameStarted;
    public GameObject platformSpawner;

    [Header("GameOver")]
    public GameObject gameOverPanel;
    public GameObject newHighScoreImage;
    public Text lastScoreText;

    [Header("Score")]
    public Text scoreText;
    public Text bestText;
    public Text diamondText; 
    public Text startText;

    int score;
    int bestScore, totalDiamond, totalStar;
    bool countScore;
    int newStar;
    int newDiamond;

    [Header("for Player")]
    public GameObject[] player;
    Vector3 playerStartPos = new Vector3(0,2,0);
    int selectedCar = 0;

    [Header("for Music")]
    public AudioSource aSource;
    public AudioClip bgMusic;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        //get selected car
        selectedCar = PlayerPrefs.GetInt("SelectCar");
        Instantiate(player[selectedCar], playerStartPos, Quaternion.identity); 
    }
    // Start is called before the first frame update
    void Start()
    {
        aSource.clip = bgMusic;
        aSource.Play();
        //play with old score
        
        if(PlayerPrefs.GetInt("oldScore") != 0)
        {
            score = PlayerPrefs.GetInt("oldScore");
            PlayerPrefs.SetInt("oldScore", 0);
        }
        
        //total Diamond
        totalDiamond = PlayerPrefs.GetInt("totalDiamond");
        diamondText.text = totalDiamond.ToString();
        //total Star
        totalStar = PlayerPrefs.GetInt("totalStar");
        startText.text = totalStar.ToString();
        //best Score
        bestScore = PlayerPrefs.GetInt("bestScore");
        bestText.text = bestScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameStarted)
        {
            if(Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
        }
    }

    public void GameStart()
    {
        isGameStarted = true;
        countScore = true;
        StartCoroutine(UpdateScore());
        platformSpawner.SetActive(true);
    }

    public void GameOver()
    {
        aSource.Stop();
        gameOverPanel.SetActive(true);
        lastScoreText.text = score.ToString();
        countScore = false;
        platformSpawner.SetActive(false);
        if(score > bestScore)
        {
            PlayerPrefs.SetInt("bestScore", score);
            newHighScoreImage.SetActive(true);
        }

    }

    public void startWithScore()
    {
        PlayerPrefs.SetInt("oldScore", score);
        SceneManager.LoadScene("Level");
    }

    public void Home()
    {
        SceneManager.LoadScene("ChooseCar");
        PlayerPrefs.SetInt("totalStar", newStar+1);
        PlayerPrefs.SetInt("totalDiamond", newDiamond+1);
    }

    IEnumerator UpdateScore()
    {
        while(countScore)
        {
            yield return new WaitForSeconds(1f);
            score++;
            if(score>bestScore)
            {
                bestText.text = score.ToString();
            }
                scoreText.text = score.ToString();

        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void GetStar()
    {
        SoundManager.sm.StarSound();
        newStar = totalStar++;
        PlayerPrefs.SetInt("totalStar", newStar);
        startText.text = totalStar.ToString();
    }

    public void GetDiamond()
    {
        SoundManager.sm.DiamondSound();
        newDiamond = totalDiamond++;
        PlayerPrefs.SetInt("totalDiamond", newDiamond);
        diamondText.text = totalDiamond.ToString();
    }
}
