using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Arrastra el Panel aquí en el Inspector
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
        pauseMenuUI.SetActive(false);   // Oculta el menú de pausa
        Time.timeScale = 1f;            // Reanuda el tiempo
        isPaused = false;               // Marca como no pausado
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);    // Muestra el menú de pausa
        Time.timeScale = 0f;            // Pausa el tiempo
        isPaused = true;                // Marca como pausado
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;            // Asegúrate de reanudar el tiempo antes de cambiar de escena
        SceneManager.LoadScene("MainMenu"); // Cambia "MainMenu" por el nombre de tu escena principal
    }

    public void Restart()
    {
        Time.timeScale = 1f;            // Asegúrate de reanudar el tiempo antes de reiniciar
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia la escena actual
    }
}
