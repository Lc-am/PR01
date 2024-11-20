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
        // Inicializaci�n de la rotaci�n del escudo
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
            shield.SetActive(true);  // Aseg�rate de que el escudo est� activado al inicio
        }
    }

    // M�todo p�blico para obtener el estado del escudo
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

    // M�todo para activar el escudo
    public void ActivateShield()
    {
        activeShield = true;  // Activa el escudo
        shield.SetActive(true);  // Aseg�rate de que el escudo est� visible

        if (orbe != null)
        {
            orbe.SetActive(true);  // Activa el orbe como efecto visual del escudo
        }
    }

    // Este m�todo es para manejar las colisiones con los obst�culos
    private void OnCollisionEnter(Collision other)
    {
        // Si el escudo est� activado y colisiona con un obst�culo, desact�valo
        if (other.gameObject.CompareTag("Obstacle"))
        {
            if (activeShield)
            {
                DeactivateEffect();  // Desactiva el escudo si est� activo
                UnityEngine.Debug.Log("Escudo desactivado debido a la colisi�n con un obst�culo.");
            }
        }
    }

    // M�todo para desactivar el escudo
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
