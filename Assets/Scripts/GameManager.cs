using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int enemiesAlive = 0;
    public int round = 0;
    public GameObject[] spawnPoints;
    public GameObject enemyPrefab;
    public TMP_Text roundText, healthText, roundsSurvived;
    public GameObject gameOverPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesAlive == 0){
            round++;
            roundText.text = "Round " + round;
            NextWave(round);
        }
           
        
    }

    public void NextWave(int round){

        for (var x = 0; x < round; x++)
        {
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            GameObject enemySpawned = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            enemySpawned.GetComponent<EnemyManager>().gameManager= GetComponent<GameManager>();
            enemiesAlive ++;
            
        }   
    }

    public void GameFailed(){

        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        gameOverPanel.SetActive(true);
        roundsSurvived.text=round.ToString();
    }

    public void Restart(){

        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(1);
    }

    public void BackToMainMenu(){

        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
