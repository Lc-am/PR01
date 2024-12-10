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

    private ColorChanger colorChanger;

    void Start()
    {

        colorChanger = GetComponentInParent<ColorChanger>();  

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
        if (other.gameObject.CompareTag("Obstacle") ||
        (other.gameObject.CompareTag("ParedVerde") && colorChanger.currentMaterialIndex != 0) ||
        (other.gameObject.CompareTag("ParedRoja") && colorChanger.currentMaterialIndex != 1) ||
        (other.gameObject.CompareTag("ParedAmarilla") && colorChanger.currentMaterialIndex != 2) ||
        (other.gameObject.CompareTag("ParedAzul") && colorChanger.currentMaterialIndex != 3))
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

    public int GetCurrentMaterialIndex()
    {
        if (colorChanger != null)
        {
            return colorChanger.currentMaterialIndex;
        }
        else
        {
            return -1; 
        }
    }
}
