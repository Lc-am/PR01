using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HandleVictory();
        }
    }

    private void HandleVictory()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
