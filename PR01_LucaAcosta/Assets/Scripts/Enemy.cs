using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocidad = 2f; // Velocidad de movimiento
    private float tiempoDesdeInicio = 0f; // Temporizador
    private bool moviendo = false; // Estado de movimiento

    void Update()
    {
        // Incrementa el temporizador
        tiempoDesdeInicio += Time.deltaTime;

        // Verifica si han pasado 10 segundos
        if (tiempoDesdeInicio >= 5f)
        {
            moviendo = true; // Comienza a moverse
        }

        // Mueve el enemigo hacia adelante si está activo
        if (moviendo)
        {
            transform.Translate(transform.right * velocidad * Time.deltaTime);
        }

        // Desaparece después de 15 segundos
        if (tiempoDesdeInicio >= 15f)
        {
            Destroy(gameObject); // Elimina el objeto
            // O para desactivarlo: gameObject.SetActive(false);
        }
    }
}
