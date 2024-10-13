using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float velocidadMovimiento = 5f;  // Velocidad constante hacia adelante
    public float fuerzaSalto = 7f;  // Fuerza del salto
    private Rigidbody rb;
    private bool enSuelo = true;

    // Start is called before the first frame update
    void Start()
    {
        // Obtener el Rigidbody del cilindro
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Mover constantemente hacia adelante
        transform.Translate(Vector3.forward * velocidadMovimiento * Time.deltaTime);

        // Verificar si se presiona la barra espaciadora para saltar
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            enSuelo = false;  // Desactivar la habilidad de saltar hasta que toque el suelo
        }
    }

    // Detectar si el cilindro está tocando el suelo para permitir saltar de nuevo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }
}
