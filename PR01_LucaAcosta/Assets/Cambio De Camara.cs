using Cinemachine;
using UnityEngine;

public class CameraTargetSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;

    public Transform chameleonTarget;
    public Transform playerTarget;

    public void SwitchToChameleon()
    {
        if (virtualCamera != null && chameleonTarget != null)
        {
            virtualCamera.Follow = chameleonTarget;
            virtualCamera.LookAt = chameleonTarget;
            Debug.Log("C�mara cambiada al camale�n.");
        }
    }

    public void SwitchToPlayer()
    {
        if (virtualCamera != null && playerTarget != null)
        {
            virtualCamera.Follow = playerTarget;
            virtualCamera.LookAt = playerTarget;
            Debug.Log("C�mara cambiada al jugador.");
        }
    }
}


