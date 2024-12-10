using UnityEngine;
public class PortalSwitch : MonoBehaviour
{
    [SerializeField] private GameObject currentPlayer; 
    [SerializeField] private GameObject chameleon;     
    [SerializeField] private GameObject portalEffect;  

    private CameraTargetSwitcher cameraTargetSwitcher;

    private void Start()
    {
        cameraTargetSwitcher = FindObjectOfType<CameraTargetSwitcher>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == currentPlayer)
        {
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

        }
    }
}



