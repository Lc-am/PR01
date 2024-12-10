using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CinemachineVirtualCamera mainCamera;

    private bool isPlayerDead = false;


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

        StartCoroutine(RestartScene());
    }

    private IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(2f); 
        isPlayerDead = false; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
