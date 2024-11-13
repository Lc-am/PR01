using DG.Tweening;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int count;      
    public static int maxCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            count++;

            GetComponent<Collider>().enabled = false;

            transform.DOMove(transform.position + Vector3.up * 1.25f, 0.5f)
                .OnComplete(() =>
                {
                    transform.DOScale(Vector3.zero, 0.5f)
                        .OnComplete(() => Destroy(gameObject));
                });
        }
    }


    void Start()
    {
        transform.DORotate(Vector3.up * 360f, 1f).
        SetRelative().
        SetEase(Ease.Linear).
        SetLoops(-1);
    }
}



