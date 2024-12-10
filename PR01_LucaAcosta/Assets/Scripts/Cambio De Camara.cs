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
        }
    }

    public void SwitchToPlayer()
    {
        if (virtualCamera != null && playerTarget != null)
        {
            virtualCamera.Follow = playerTarget;
            virtualCamera.LookAt = playerTarget;
        }
    }
}


