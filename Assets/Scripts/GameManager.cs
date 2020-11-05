using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGamePaused = false;
    public bool isHuman = true;
    public GameObject pauseScreen;
    public GameObject levelCompletedScreen;
    public GameObject endScreenMenuButton;
    public GameObject gameOverScreen;
    public GameObject humanPrefab;
    public Text levelCompletionText;
    public int currentScene = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("LastScenePlayed", 0);
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(pauseScreen);
        DontDestroyOnLoad(levelCompletedScreen);
        DontDestroyOnLoad(gameOverScreen);
    }

    // Update is called once per frame
    void Update()
    {
        // Opens up the pause menu and stops the game so the player can restart
        if(Input.GetKeyDown(KeyCode.Escape) && currentScene != 0)
        {
            if(isGamePaused == false)
            {
                pauseScreen.SetActive(true);
                isGamePaused = true;
                Time.timeScale = 0;
            }      
            else
            {
                pauseScreen.SetActive(false);
                isGamePaused = false;
                Time.timeScale = 1;
            }             
        }
    }

    // Start the game
    public void StartNextLevel(int nextScene)
    {
        if (isGamePaused == true)
        {
            pauseScreen.SetActive(false);
            isGamePaused = false;
            ResetTimeScale();
        }

        SceneManager.UnloadSceneAsync(currentScene);
        SceneManager.LoadSceneAsync(nextScene);
        //Instantiate(pauseScreen);

        currentScene = nextScene;
        if(currentScene != 0)
        {
            PlayerPrefs.SetInt("LastScenePlayed", currentScene);
        }
    }

    public void ContinueGame()
    {
        StartNextLevel(PlayerPrefs.GetInt("LastScenePlayed"));
    }

    public void Restart()
    {
        StartNextLevel(currentScene);
        pauseScreen.SetActive(false);
        isGamePaused = false;
    }

    // Switch back to human at restart method
    public void SwitchToHumanIfNotHuman()
    {
        // Even though the player is still human, it will delete and create back the human
        Destroy(humanPrefab);
        Instantiate(humanPrefab, transform.position, transform.rotation);
        isHuman = true;
    }

    public void WinGame()
    {
        levelCompletedScreen.SetActive(true);

        if(currentScene == 1)
        {
            endScreenMenuButton.SetActive(false);
            levelCompletionText.text = "Tutorial Level Completed! You have collected the Diamond of Wisdom!";
            Invoke("WaitBeforeClosingMessageWindow", 3.5f);
            StartNextLevel(currentScene+1);

        }
        else if(currentScene == 2)
        {
            endScreenMenuButton.SetActive(true);
            levelCompletionText.text = "You have completed all the levels! You are now the True God!";
            Time.timeScale = 0;
        }      
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    public void WaitBeforeClosingMessageWindow()
    {
        levelCompletedScreen.SetActive(false);
    }

    public void ResetDataAfterGame(int nextScene)
    {
        currentScene = 0;
    }

    public void ResetTimeScale()
    {
        Time.timeScale = 1;
    }
}
