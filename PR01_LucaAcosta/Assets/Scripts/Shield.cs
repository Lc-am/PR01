using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shield : MonoBehaviour
{
    public GameObject shield;          // Aseg�rate de asignar el objeto escudo en el Inspector

    private bool activeShield;

    void Start()
    {
        activeShield = false;

        // Aseg�rate de que el escudo est� desactivado al principio
        shield.SetActive(false);

        // Rota el escudo 360 grados en el eje Y de manera continua
        // El m�todo DORotate rota el objeto en torno a un vector, aqu� es alrededor de Y
        transform.DORotate(Vector3.up * 360f, 5f, RotateMode.Local)   // 5 segundos para una rotaci�n completa
            .SetEase(Ease.Linear)                                      // Rotaci�n constante
            .SetLoops(-1, LoopType.Restart);                           // Bucle infinito
    }

    void Update()
    {
        // Activar y desactivar el escudo con la tecla "S" (puedes cambiarla si lo necesitas)
        if (Input.GetKeyDown(KeyCode.S))  // Cambia la tecla si es necesario
        {
            activeShield = !activeShield;  // Alterna el estado del escudo

            if (activeShield)
            {
                shield.SetActive(true);    // Activa el escudo
            }
            else
            {
                shield.SetActive(false);   // Desactiva el escudo
            }
        }
    }
}

