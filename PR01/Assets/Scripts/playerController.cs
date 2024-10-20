//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public class playerController : MonoBehaviour
//{
//    public float velocidadMovimiento = 5f;  
//    public float fuerzaSalto = 7f;  
//    public Rigidbody rb;
//    //private bool enSuelo = true;

//    private Animator animator;
//    public bool puedoSaltar;


//    void /*Start*/()
//    {
//        puedoSaltar = false;
//        rb = GetComponent<Rigidbody>();
//        animator = GetComponent<Animator>();
//    }

//    void /*Update*/()
//    {
//        transform.Translate(Vector3.forward * velocidadMovimiento * Time.deltaTime);

//        if(puedoSaltar)
//        {
//            if (Input.GetKeyDown(KeyCode.Space) /*&& enSuelo*/)
//            {
//                animator.SetBool("Saltar", true);
//                rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
//                //enSuelo = false;  
//            }
//            animator.SetBool("TocarSuelo", true);
//        }
//        else
//        {
//            EstoyCayendo();
//        }   
//    }

//    public void EstoyCayendo()
//    {
//        animator.SetBool("TocarSuelo", false);
//        animator.SetBool("Saltar", false);
//    }

//    // Detectar si el cilindro está tocando el suelo para permitir saltar de nuevo
//    //private void OnCollisionEnter(Collision collision)
//    //{
//    //    if (collision.gameObject.CompareTag("Suelo"))
//    //    {
//    //        enSuelo = true;
//    //    }
//    //}
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float fuerzaSalto = 7f;
    public Rigidbody rb;
    private Animator animator; 
    public bool puedoSaltar; 

    void Start()
    {
        puedoSaltar = false;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * velocidadMovimiento * Time.deltaTime);

        if(puedoSaltar)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("Saltar", true);
                rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
            }
            animator.SetBool("TocarSuelo", true);
        }
        else
        {
            EstoyCayendo();
        }
    }

    public void EstoyCayendo()
    {
        animator.SetBool("TocarSuelo", false);
        animator.SetBool("Saltar", false);
    }
}


