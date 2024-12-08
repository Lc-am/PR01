using UnityEngine;

public class Shield : MonoBehaviour
{
    // Referencia al objeto que contiene el efecto del escudo
    public GameObject shieldEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verificar si el objeto que colisiona es el jugador
        {
            playerController playerController = other.GetComponent<playerController>();
            if (playerController != null)
            {
                playerController.ActivarEscudo(); // Activar la lógica del escudo

                // Activar el efecto visual del escudo
                if (shieldEffect != null)
                {
                    shieldEffect.SetActive(true);
                }

                Destroy(gameObject); 
            }
        }
    }
}