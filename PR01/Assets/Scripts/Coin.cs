using DG.Tweening;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int count;      
    public static int maxCount;
    //private static bool maxCountInitialized = false;  

    //void Awake()
    //{
    //    if (!maxCountInitialized)
    //    {
    //        maxCount++; 
    //    }
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))  
    //    {
    //        count++; 

    //        GetComponent<Collider>().enabled = false;

    //        transform.DOMove(transform.position + Vector3.up * 1.25f, 0.5f)
    //            .OnComplete(() =>
    //            {
    //                transform.DOScale(Vector3.zero, 0.5f)
    //                    .OnComplete(() => Destroy(gameObject));  
    //            });
    //    }
    //}
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
    
        //maxCountInitialized = true;

        transform.DORotate(Vector3.up * 360f, 1f).
        SetRelative().
        SetEase(Ease.Linear).
        SetLoops(-1);
    }
}



