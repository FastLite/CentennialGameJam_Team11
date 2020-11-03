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
    public GameObject humanPrefab;
    public GameObject lvl1Text;
    public GameObject lvl2Text;
    public Text levelPassed;
    public int currentScene = 0;
    //fsbsfbsfbs


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("LastScenePlayed", 0);
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(pauseScreen);
    }

    // Update is called once per frame
    void Update()
    {
        // Opens up the pause menu and stops the game so the player can restart
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused == false)
            {
                pauseScreen.SetActive(true);
                isGamePaused = true;
            }      
            else
            {
                pauseScreen.SetActive(false);
                isGamePaused = false;
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
        }

        SceneManager.UnloadSceneAsync(currentScene);
        SceneManager.LoadScene(nextScene);
        Instantiate(pauseScreen);

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
    }

    // Switch back to human at restart method
    public void SwitchToHumanIfNotHuman()
    {
        // Even though the player is still human, it will delete and create back the human
        Destroy(humanPrefab);
        Instantiate(humanPrefab, transform.position, transform.rotation);
        isHuman = true;
    }
}
