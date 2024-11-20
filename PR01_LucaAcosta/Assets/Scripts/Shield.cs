//using UnityEngine;
//using DG.Tweening;
//using System.Diagnostics;

//public class Shield : MonoBehaviour
//{
//    public GameObject shield;
//    public GameObject orbe;

//    public bool activeShield;

//    void Start()
//    {
//        transform.DORotate(Vector3.up * 360f, 1f).
//        SetRelative().
//        SetEase(Ease.Linear).
//        SetLoops(-1);

//        if (orbe != null)
//        {
//            orbe.SetActive(false);
//        }
//    }


//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.S))
//        {
//            activeShield = !activeShield;

//            if (activeShield)
//            {
//                shield.SetActive(true);
//            }
//            else
//            {
//                shield.SetActive(false);
//            }
//        }
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            UnityEngine.Debug.Log("El escudo ha colisionado con el jugador!");

//            Destroy(gameObject);

//            if (orbe != null)
//            {
//                orbe.SetActive(true);  
//            }
//        }
//    }
//}

using UnityEngine;
using DG.Tweening;

public class Shield : MonoBehaviour
{
    public GameObject shield;  // El objeto visual del escudo
    public GameObject orbe;    // El objeto del orbe, que representa el efecto del escudo

    public bool activeShield = false;  // Estado del escudo

    void Start()
    {
        // Inicialización de la rotación del escudo
        transform.DORotate(Vector3.up * 360f, 1f)
            .SetRelative()
            .SetEase(Ease.Linear)
            .SetLoops(-1);

        if (orbe != null)
        {
            orbe.SetActive(false);  // Desactiva el orbe al inicio
        }

        if (shield != null)
        {
            shield.SetActive(true);  // Asegúrate de que el escudo esté activado al inicio
        }
    }

    // Método público para obtener el estado del escudo
    public bool IsShieldActive()
    {
        return activeShield;
    }

    // Maneja las colisiones con los objetos con trigger
    private void OnTriggerEnter(Collider other)
    {
        // Si el jugador colisiona con el escudo, activa el escudo
        if (other.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("El jugador ha colisionado con el escudo!");

            ActivateShield();  // Activa el escudo
            Destroy(gameObject);  // Destruye el objeto del escudo una vez que el jugador lo ha recogido
        }
    }

    // Método para activar el escudo
    public void ActivateShield()
    {
        activeShield = true;  // Activa el escudo
        shield.SetActive(true);  // Asegúrate de que el escudo esté visible

        if (orbe != null)
        {
            orbe.SetActive(true);  // Activa el orbe como efecto visual del escudo
        }
    }

    // Este método es para manejar las colisiones con los obstáculos
    private void OnCollisionEnter(Collision other)
    {
        // Si el escudo está activado y colisiona con un obstáculo, desactívalo
        if (other.gameObject.CompareTag("Obstacle"))
        {
            if (activeShield)
            {
                DeactivateEffect();  // Desactiva el escudo si está activo
                UnityEngine.Debug.Log("Escudo desactivado debido a la colisión con un obstáculo.");
            }
        }
    }

    // Método para desactivar el escudo
    public void DeactivateEffect()
    {
        activeShield = false;  // Desactiva el escudo
        shield.SetActive(false);  // Desactiva el objeto visual del escudo

        if (orbe != null)
        {
            orbe.SetActive(false);  // Desactiva el orbe
        }

        UnityEngine.Debug.Log("Escudo desactivado.");
    }
}
