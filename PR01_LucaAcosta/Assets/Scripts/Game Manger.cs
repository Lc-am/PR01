using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Cambio de c�maras a la hora de ganar
    public static GameManager instance;
    public CinemachineVirtualCamera mainCamera;
    public CinemachineVirtualCamera victoryCamera;
    public GameObject victoryCanvas;

    private bool gameWon = false;

    // Contador de intentos
    private int intentos = 0;
    private bool isPlayerDead = false;

    public GameObject finishLine;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Revisar
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayerDied()
    {
        if (isPlayerDead) return; // Evitar m�ltiples reinicios
        isPlayerDead = true;

        intentos++;
        StartCoroutine(RestartScene());
    }

    private IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(3f); // Esperar antes de reiniciar
        isPlayerDead = false; // Resetear estado
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TriggerVictory()
    {
        if (gameWon) return;
        gameWon = true;

        // Cambiar prioridad de c�maras
        mainCamera.Priority = 0;
        victoryCamera.Priority = 10;

        // Activar Canvas de victoria si est� configurado
        if (victoryCanvas != null)
        {
            victoryCanvas.SetActive(true);
        }

        // Detener movimiento del jugador
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            playerController playerController = player.GetComponent<playerController>();
            if (playerController != null)
            {
                playerController.Victoria();
            }

        }
    }
}
