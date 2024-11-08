using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject newPlayerPrefab; // Prefab del nuevo jugador
    private GameObject currentPlayer; // Referencia al jugador actual

    void Start()
    {
        // Encuentra al jugador actual en la escena
        currentPlayer = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entró al portal es el jugador
        if (other.CompareTag("Player"))
        {
            // Cambia al prefab del jugador
            ChangePlayer();
        }
    }

    private void ChangePlayer()
    {
        // Destruye el jugador actual
        Destroy(currentPlayer);

        // Instancia el nuevo prefab del jugador
        Vector3 spawnPosition = new Vector3(0, 1, 0); // Cambia la posición según necesites
        currentPlayer = Instantiate(newPlayerPrefab, spawnPosition, Quaternion.identity);

        // Opcional: puedes asignar una etiqueta al nuevo jugador
        currentPlayer.tag = "Player";
    }
}
