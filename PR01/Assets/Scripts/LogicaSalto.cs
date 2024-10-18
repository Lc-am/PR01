using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaSalto : MonoBehaviour
{
    public playerController playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OntriggerStay(Collider other)
    {
        playerController.puedoSaltar = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerController.puedoSaltar = false;
    }
}
