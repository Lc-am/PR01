using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChameleonController : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 10f;
    public Rigidbody rb;
    private Animator animator;
    private bool isCorrer;

    [SerializeField] private InputActionReference jump;

    private bool canMove = true;

    public bool isGrounded { get; private set; }

    void Start()
    {
        isGrounded = false;
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

            isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

            if (isGrounded && jump.action.triggered)
            {
                animator.SetBool("Saltar", true);
                rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
            }
            
            else
            {
                animator.SetBool("Saltar", false);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Die();
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
}
