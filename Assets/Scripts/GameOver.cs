using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static GameOver Instance; // Singleton instance
    public GameObject gameOverMenu;

    public string mainMenu;

    private void Awake()
    {
        // Ensure only one instance of GameOver exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple GameOver instances found! Destroying extra instance.");
            Destroy(gameObject);
            return;
        }

        // Initialize the gameOverMenu
        if (gameOverMenu != null)
        {
            gameOverMenu.SetActive(false); // Ensure the menu starts hidden
        }
        else
        {
            Debug.LogError("GameOverMenu is not assigned in the Inspector!");
        }
    }

    public void GameEnd()
    {
        if (gameOverMenu != null)
        {
            gameOverMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenu);
    }


    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

