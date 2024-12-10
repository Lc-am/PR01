using UnityEngine;
using DG.Tweening;

public class Shield : MonoBehaviour
{
    public GameObject shieldEffect;

    private void Start()
    {
        transform.DORotate(Vector3.up * 360f, 1f)
            .SetRelative()
            .SetEase(Ease.Linear)
            .SetLoops(-1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            playerController playerController = other.GetComponent<playerController>();
            if (playerController != null)
            {
                playerController.ActivarEscudo(); 

                if (shieldEffect != null)
                {
                    shieldEffect.SetActive(true);
                }

                transform.DOScale(Vector3.zero, 1f) 
                    .OnComplete(() =>
                    {
                        transform.DOScale(Vector3.one, 1f)  
                            .SetLoops(-1, LoopType.Yoyo)  
                            .SetEase(Ease.InOutSine); 
                    });

                GetComponent<Collider>().enabled = false;
            }
        }
    }
}
