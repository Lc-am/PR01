using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacles: MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController player = collision.gameObject.GetComponent<playerController>();
            if (player != null)
            {
                player.Die(); // Llama al método de muerte del jugador
            }
        }
    }
}
