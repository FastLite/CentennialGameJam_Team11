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


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
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
                Time.timeScale = 0;
            }      
            else
            {
                pauseScreen.SetActive(false);
                Time.timeScale = 0;
            }             
        }
    }

    // Start the game
    //public void StartFirstLevel()
    //{
    //    SceneManager.UnloadSceneAsync(Scene 0);
    //    SceneManager.LoadScene(Scene 1);
    //    SwitchToHumanIfNotHuman();
    //}

    // Restart the game
    //public void RestartGame()
    //{
    //    SceneManager.UnloadSceneAsync(Scene 1);
    //    SceneManager.LoadScene(Scene 0);
    //    SwitchToHumanIfNotHuman();
    //}

    //public void BackToMenu()
    //{
    //    SceneManager.UnloadSceneAsync(Scene 1);
    //    SceneManager.LoadScene(Scene 0);
    //}

    // Switch back to human at restart method
    public void SwitchToHumanIfNotHuman()
    {
        // Even though the player is still human, it will delete and create back the human
        Destroy(gameObject);
        Instantiate(humanPrefab, transform.position, transform.rotation);
        isHuman = true;
    }
}
