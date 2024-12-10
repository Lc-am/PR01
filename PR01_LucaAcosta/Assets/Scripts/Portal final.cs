using UnityEngine;

public class ChameleonSwitcher : MonoBehaviour
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
            if (portalEffect != null)
            {
                Instantiate(portalEffect, transform.position, Quaternion.identity);
            }

            currentPlayer.transform.position = chameleon.transform.position;
            currentPlayer.transform.rotation = chameleon.transform.rotation;

            chameleon.SetActive(false);
            currentPlayer.SetActive(true);

            if (cameraTargetSwitcher != null)
            {
                cameraTargetSwitcher.SwitchToPlayer();
            }

        }
    }
}
