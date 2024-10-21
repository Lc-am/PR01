using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocidad = 2f; 
    private float tiempoDesdeInicio = 0f; 
    private bool moviendo = false; 

    void Update()
    {
        tiempoDesdeInicio += Time.deltaTime;

        if (tiempoDesdeInicio >= 1f)
        {
            moviendo = true; 
        }

        if (moviendo)
        {
            transform.Translate(Vector2.left * velocidad * Time.deltaTime);

            if (transform.position.x < -Screen.width)
            {
                transform.position = new Vector2(Screen.width, transform.position.y);
            }
        }

        if (tiempoDesdeInicio >= 10f)
        {
            Destroy(gameObject);
        }
    }
}
