using UnityEngine;

public class ChameleonSwitch : MonoBehaviour
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
        if (other.gameObject == chameleon)
        {
            // Instancia efectos visuales
            if (portalEffect != null)
            {
                Instantiate(portalEffect, transform.position, Quaternion.identity);
            }

            currentPlayer.transform.position = chameleon.transform.position;
            currentPlayer.transform.rotation = chameleon.transform.rotation;

            chameleon.SetActive(false);
            currentPlayer.SetActive(true);

            // Cambiar objetivo de la cámara
            if (cameraTargetSwitcher != null)
            {
                cameraTargetSwitcher.SwitchToPlayer();
            }
        }
    }
}
