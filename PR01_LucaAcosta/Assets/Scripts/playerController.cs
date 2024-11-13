using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        isGrounded = false;
        dobleSalto = 0;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
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
}


