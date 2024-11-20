using System.Diagnostics;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject newSkin; // La nueva skin que se activará
    private GameObject player; // Referencia al jugador

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en el trigger es el jugador
        if (other.CompareTag("Player"))
        {
            player = other.gameObject; // Guarda la referencia al jugador

            // Cambia la skin del jugador
            ChangeSkin();

            // Desactiva al jugador
            DisablePlayer();
        }
    }

    private void ChangeSkin()
    {
        if (newSkin != null)
        {
            // Desactiva la skin actual del jugador
            player.SetActive(false);

            // Instancia la nueva skin en la posición del jugador
            GameObject newSkinInstance = Instantiate(newSkin, player.transform.position, player.transform.rotation);
            newSkinInstance.SetActive(true); // Activa la nueva skin
        }
        else
        {
            UnityEngine.Debug.LogWarning("No se ha asignado una nueva skin al portal.");
        }
    }

    private void DisablePlayer()
    {
        // Desactiva el objeto del jugador
        player.SetActive(false);
    }
}