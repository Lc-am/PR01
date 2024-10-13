using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    public Transform objetivo;  // El cilindro como objetivo
    public Vector3 offset;  // Distancia desde la cámara al cilindro

    void LateUpdate()
    {
        transform.position = objetivo.position + offset;
    }
}
