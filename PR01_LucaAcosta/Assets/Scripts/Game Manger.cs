using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    // Cambio de cámaras a la hora de ganar
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
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayerDied()
    {
        if (isPlayerDead) return; 
        isPlayerDead = true;

        intentos++;
        StartCoroutine(RestartScene());
    }

    private IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(2f); 
        isPlayerDead = false; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TriggerVictory()
    {
        if (gameWon) return;
        gameWon = true;

        mainCamera.Priority = 0;
        victoryCamera.Priority = 10;

        if (victoryCanvas != null)
        {
            victoryCanvas.SetActive(true);
        }

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
