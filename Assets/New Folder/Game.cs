using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject restart;
    public float initialspeed = 5f;
    public float speedincrease = 0.5f;
    private float gamespeed;
    public PlayerController playercontroller;
    public Spawner spawner;
    public TextMeshProUGUI over;
    public TextMeshProUGUI score;
    public TextMeshProUGUI overscore;
    private float scoreint;
    private float hiscore;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playercontroller=FindFirstObjectByType<PlayerController>();
        spawner = FindFirstObjectByType<Spawner>();
        newgame();
        over.enabled = false;
        restart.SetActive(false);
       
    }
    public void newgame()
    {
        Obstacles[] obstacles = FindObjectsByType<Obstacles>(FindObjectsSortMode.None);
        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }
        gamespeed = initialspeed;
        playercontroller.enabled = true;
        spawner.enabled = true;
        over.enabled = false;
        Updatehiscore();

    }
    // Update is called once per frame

    private void Update()
    {
        gamespeed += speedincrease * Time.deltaTime;
        scoreint += gamespeed * Time.deltaTime;
        score.text = Mathf.RoundToInt(scoreint).ToString("D5");
    }
    
    public void pause()
    {
        Time.timeScale = 0f;
        playercontroller.enabled = false;
        spawner.enabled = false;
    }
    public void again()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
    public void gameover()
    {
        restart.SetActive(true);
        Time.timeScale = 0f;
        playercontroller.enabled = false;
        spawner.enabled = false;
        over.enabled = true;
        Updatehiscore();
       
}
    private void Updatehiscore()
    {
        float hiscore = PlayerPrefs.GetFloat("Highscore", 0);
        if (scoreint>hiscore)
        {
            hiscore = scoreint;
            PlayerPrefs.SetFloat("HighScore", hiscore);
            PlayerPrefs.Save();
            overscore.text = Mathf.RoundToInt(hiscore).ToString("D5");
        }
    }
}
