using UnityEngine;
using Cinemachine;
using System.Diagnostics;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public CinemachineVirtualCamera mainCamera;   // Cámara principal
    public CinemachineVirtualCamera victoryCamera; // Cámara de victoria
    public GameObject victoryCanvas;

    private bool gameWon = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TriggerVictory()
    {
        if (gameWon) return;
        gameWon = true;

        UnityEngine.Debug.Log("¡Victoria!");

        // Cambiar prioridades de las cámaras
        mainCamera.Priority = 0;
        victoryCamera.Priority = 10;

        // Activar Canvas de victoria
        if (victoryCanvas != null)
        {
            victoryCanvas.SetActive(true);
        }
    }
}
