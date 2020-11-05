using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGamePaused = false;
    public bool isHuman = true;
    public GameObject pauseScreen;
    public GameObject levelCompletedScreen;
    public GameObject endScreenMenuButton;
    public GameObject gameOverScreen;
    public GameObject messageBoxScreen;
    public Text levelCompletionText;
    public int currentScene = 0;

    public AudioSource themeMusic;
    public AudioSource deathSound;
    public AudioSource puzzleSolved;
    public AudioSource singleLevelComplete;

    // Start is called before the first frame update
    void Start()
    {
        themeMusic.Play();
        PlayerPrefs.GetInt("LastScenePlayed", 0);
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(pauseScreen);
        DontDestroyOnLoad(levelCompletedScreen);
        DontDestroyOnLoad(gameOverScreen);
        DontDestroyOnLoad(messageBoxScreen);
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

        if(messageBoxScreen == true && currentScene != 1)
        {
            messageBoxScreen.SetActive(false);
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

        if (nextScene == 1)
        {
            TurnOnMessageBox();
        }
 
        if(nextScene == 0)
        {
            Destroy(gameObject, 0.1f);
        }

        SceneManager.UnloadSceneAsync(currentScene);
        SceneManager.LoadScene(nextScene);
        //Instantiate(pauseScreen);

        currentScene = nextScene;
        if (currentScene != 0)
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
        themeMusic.Play();
        pauseScreen.SetActive(false);
        isGamePaused = false;
    }
    
    public void WinGame()
    {
        levelCompletedScreen.SetActive(true);

        if(currentScene == 1)
        {
            singleLevelComplete.Play();
            endScreenMenuButton.SetActive(false);
            levelCompletionText.text = "Tutorial Level Completed! You have collected the Diamond of Wisdom!";
            Invoke("WaitBeforeClosingMessageWindow", 5f);
            StartNextLevel(currentScene+1);

        }
        else if(currentScene == 2)
        {
            themeMusic.Stop();
            puzzleSolved.Play();
            endScreenMenuButton.SetActive(true);
            levelCompletionText.text = "You have completed all the levels! You are now the True God!";
            Time.timeScale = 0;
        }      
    }

    public void GameOver()
    {
        themeMusic.Stop();
        deathSound.Play();
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
        Destroy(gameObject);
    }

    public void ResetTimeScale()
    {
        Time.timeScale = 1;
    }

    public void TurnOnMessageBox()
    {
        messageBoxScreen.SetActive(true);
        Invoke("WaitForTimeToCloseMessage", 3.5f);
    }

    public void WaitForTimeToCloseMessage()
    {
        messageBoxScreen.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
