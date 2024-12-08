using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Credits : MonoBehaviour
{
    void Start()
    {
        Invoke("WaitToEnd", 30); //Depende del tiempo que dure la animacion de los creditos
    }




    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("mainMenu");
        }
    }

    public void WaitToEnd()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
