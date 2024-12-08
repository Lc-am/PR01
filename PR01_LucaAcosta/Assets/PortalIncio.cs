using UnityEngine;
public class PortalSwitch : MonoBehaviour
{
    [SerializeField] private GameObject currentPlayer; // Personaje actual
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
        if (other.gameObject == currentPlayer)
        {
            // Instancia efectos visuales
            if (portalEffect != null)
            {
                Instantiate(portalEffect, transform.position, Quaternion.identity);
            }

            // Cambiar al camaleón
            chameleon.transform.position = currentPlayer.transform.position;
            chameleon.transform.rotation = currentPlayer.transform.rotation;

            currentPlayer.SetActive(false);
            chameleon.SetActive(true);

            // Cambiar objetivo de la cámara
            if (cameraTargetSwitcher != null)
            {
                cameraTargetSwitcher.SwitchToChameleon();
            }

            Debug.Log("Portal activado. Cambio de personajes realizado.");
        }
    }
}
