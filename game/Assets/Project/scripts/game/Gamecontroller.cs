using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamecontroller : MonoBehaviour
{
    [Header("Game")]
    public Player player;
    public GameObject EnemyContainer;
    

    [Header("UI")]
    public Text healthText;
    public Text ammoText;
    public Text enemyText;
    public Text infoText;

    private bool gameOver = false;
    private bool GameOver = false;

    private float resetTimer = 3f;

    void Start()
    {
        infoText.gameObject.SetActive(false);
    }
    
 
    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + player.Health;
        ammoText.text = "Ammo: " + player.Ammo;

        int aliveEnemies = 0;
        foreach(Enemy enemy in EnemyContainer.GetComponentsInChildren<Enemy>())
        {
            if (enemy.Killed == false)
            {
                aliveEnemies++;
            }
        }
        enemyText.text = "Enemies: " + aliveEnemies;

        if(aliveEnemies == 0)
        {
            gameOver = true;
            infoText.gameObject.SetActive(true);
            infoText.text = "You Protected The City ! \n Mission Accomplished";
        }

        if (player.Killed == true)
        {
            GameOver = true;
            infoText.gameObject.SetActive(true);
            infoText.text = "You Have been Infected :( ! \n Mission Failed";

        }
        

        if (gameOver == true)
        {
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0)
            {
                SceneManager.LoadScene("Menu");
            }
        }

        if (GameOver == true)
        {
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
