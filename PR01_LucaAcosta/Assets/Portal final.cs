using UnityEngine;

public class ChameleonSwitch : MonoBehaviour
{
    [SerializeField] private GameObject currentPlayer; // Personaje original
    [SerializeField] private GameObject chameleon;     // Camaleón
    [SerializeField] private GameObject portalEffect;  // Efecto visual del portal

    private CameraTargetSwitcher cameraTargetSwitcher;

    private void Start()
    {
        // Encuentra el script CameraTargetSwitcher en la escena
        cameraTargetSwitcher = FindObjectOfType<CameraTargetSwitcher>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == chameleon)
        {
            // Instancia efectos visuales
            if (portalEffect != null)
            {
                Instantiate(portalEffect, transform.position, Quaternion.identity);
            }

            // Cambiar al jugador original
            currentPlayer.transform.position = chameleon.transform.position;
            currentPlayer.transform.rotation = chameleon.transform.rotation;

            chameleon.SetActive(false);
            currentPlayer.SetActive(true);

            // Cambiar objetivo de la cámara
            if (cameraTargetSwitcher != null)
            {
                cameraTargetSwitcher.SwitchToPlayer();
            }

            Debug.Log("Portal activado. Cambio de personajes realizado.");
        }
    }
}
