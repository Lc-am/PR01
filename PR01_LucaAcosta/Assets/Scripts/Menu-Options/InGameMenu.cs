using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; 
    private bool isPaused = false;

    private void Update()
    {
        // Verifica si se presiona ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);   
        Time.timeScale = 1f;            
        isPaused = false;               
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);    
        Time.timeScale = 0f;           
        isPaused = true;                
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;            
        SceneManager.LoadScene("MenuPrincipal"); 
    }

    public void Restart()
    {
        Time.timeScale = 1f;            
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
