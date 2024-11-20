using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    public Rigidbody rb;
    private Animator animator; 

    public bool isGrounded;
    private int dobleSalto;

    private Shield shield;

    void Start()
    {
        isGrounded = false;
        dobleSalto = 0;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        shield = FindObjectOfType<Shield>();
    }

    void Update()
    {

        if (!animator.GetBool("Morir"))
        {
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

            if (isGrounded)
            {
                dobleSalto = 0;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    animator.SetBool("Saltar", true);
                    rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
                }
                animator.SetBool("TocarSuelo", true);
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) && dobleSalto < 2)
                {
                    animator.SetBool("Saltar", true);
                    rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
                    dobleSalto = 2;  
                }
                EstoyCayendo();
            }
        }
    }

    public void EstoyCayendo()
    {
        animator.SetBool("TocarSuelo", false);
        animator.SetBool("Saltar", false);
    }

    public void Die()
    {
        animator.SetBool("Morir", true); 
        rb.velocity = Vector3.zero;
        rb.isKinematic = true; 
        GetComponent<Collider>().enabled = false; 

        StartCoroutine(HandleDeath()); 
    }

    private IEnumerator HandleDeath()
    {
        yield return new WaitForSeconds(3f); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            if (shield != null && shield.IsShieldActive())
            {
                // Desactivar el escudo y continuar vivo
                shield.DeactivateEffect();
                UnityEngine.Debug.Log("El escudo ha absorbido el impacto, el jugador sigue vivo.");
            }
            else
            {
                // Si no hay escudo, el jugador muere
                Die();
            }
        }
    }
}


