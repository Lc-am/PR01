using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocidad = 2f; 
    private float tiempoDesdeInicio = 0f;
    private bool moviendo = false;

    void Update()
    {
        tiempoDesdeInicio += Time.deltaTime;

        if (tiempoDesdeInicio >= 5f)
        {
            moviendo = true; 
        }

        if (moviendo)
        {
            transform.Translate(transform.right * velocidad * Time.deltaTime);
        }

        if (tiempoDesdeInicio >= 120f)
        {
            Destroy(gameObject);
        }
    }
}
