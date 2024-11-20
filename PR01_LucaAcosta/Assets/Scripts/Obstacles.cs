using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacles: MonoBehaviour
{
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        playerController player = collision.gameObject.GetComponent<playerController>();
    //        if (player != null)
    //        {
    //            player.Die(); // Llama al método de muerte del jugador
    //        }
    //    }
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        playerController player = collision.gameObject.GetComponent<playerController>();
    //        Shield shield = collision.gameObject.GetComponent<Shield>();  // Obtener el componente de escudo

    //        if (player != null && shield != null)
    //        {
    //            Verifica si el escudo está activado
    //            if (shield != null && shield.activeShield)
    //            {
    //                shield.activeShield = false; // Desactiva el escudo
    //                shield.shield.SetActive(false); // Desactiva el objeto del escudo
    //                UnityEngine.Debug.Log("Escudo desactivado debido a la colisión.");
    //            }
    //            else
    //            {
    //                player.Die(); // Llama al método de muerte si no hay escudo
    //            }
    //        }
    //    }
    //}
}
