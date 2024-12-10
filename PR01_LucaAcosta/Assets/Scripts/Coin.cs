using DG.Tweening;
using UnityEngine;
public class Coin : MonoBehaviour
{
    public static int count;
    public static int maxCount;

    public AudioClip collectSound;  
    private AudioSource audioSource; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        transform.DORotate(Vector3.up * 360f, 1f)
            .SetRelative()
            .SetEase(Ease.Linear)
            .SetLoops(-1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            count++; 

            if (audioSource != null && collectSound != null)
            {
                audioSource.PlayOneShot(collectSound);  
            }

            GetComponent<Collider>().enabled = false;

            transform.DOMove(transform.position + Vector3.up * 1.25f, 0.5f)
                .OnComplete(() =>
                {
                    transform.DOScale(Vector3.zero, 0.5f)
                        .OnComplete(() => Destroy(gameObject));  
                });
        }
    }
}

