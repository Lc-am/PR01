using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    public Rigidbody rb;
    private Animator animator; 

    public bool isGrounded;
    private int dobleSalto;

    private bool escudoActivo = false; 
    public GameObject shieldEffect;

    private bool canMove = true;

    [SerializeField] private InputActionReference jump;

    void Start()
    {
        isGrounded = false;
        dobleSalto = 0;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        if (jump != null)
        {
            jump.action.Enable(); 
        }
    }

    void Update()
    {
        if (!animator.GetBool("Morir") && canMove)
        {
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

            if (isGrounded)
            {
                if (jump.action.triggered)
                {
                    animator.SetBool("Saltar", true);
                    rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
                }
                animator.SetBool("TocarSuelo", true);
                dobleSalto = 0;
            }
            else
            {
                if (jump.action.triggered && dobleSalto < 2)
                {
                    animator.SetBool("Saltar", true);
                    rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
                    dobleSalto = 2;
                }
                EstoyCayendo();
            }
        }
    }

    public void ActivarEscudo()
    {
        escudoActivo = true;
        shieldEffect.SetActive(true);
    }

    private void DesactivarEscudo()
    {
        escudoActivo = false;
        shieldEffect.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            if (escudoActivo)
            {

                if (animator != null)
                {
                    animator.SetBool("Choque", true);
                }

                DesactivarEscudo(); 
            }
            else
            {
                Die();
            }

            StartCoroutine(ResetChoqueBool());
        }
    }

    public void Die()
    {
        animator.SetBool("Morir", true);
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        GetComponent<Collider>().enabled = false;

        if (GameManager.instance != null)
        {
            GameManager.instance.PlayerDied();
        }
    }

    public void EstoyCayendo()
    {
        animator.SetBool("TocarSuelo", false);
        animator.SetBool("Saltar", false);
    }

    private IEnumerator ResetChoqueBool()
    {
        yield return new WaitForSeconds(0.5f);

        if (animator != null)
        {
            animator.SetBool("Choque", false);
        }
    }
}


