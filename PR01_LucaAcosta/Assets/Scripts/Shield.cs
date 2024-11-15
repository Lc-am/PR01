using UnityEngine;
using DG.Tweening;
using System.Diagnostics;

public class Shield : MonoBehaviour
{
    public GameObject shield;
    public GameObject orbe;

    private bool activeShield;

    void Start()
    {
        transform.DORotate(Vector3.up * 360f, 1f).
        SetRelative().
        SetEase(Ease.Linear).
        SetLoops(-1);

        if (orbe != null)
        {
            orbe.SetActive(false);
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            activeShield = !activeShield;

            if (activeShield)
            {
                shield.SetActive(true);
            }
            else
            {
                shield.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("El escudo ha colisionado con el jugador!");

            Destroy(gameObject);

            if (orbe != null)
            {
                orbe.SetActive(true);  
            }
        }
    }
}
