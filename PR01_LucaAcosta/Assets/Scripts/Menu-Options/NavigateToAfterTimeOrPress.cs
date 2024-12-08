using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class NavigateToAfterTimeOrPress : MonoBehaviour
{
    [SerializeField] private string nextSceneName;
    [SerializeField] private float waitTime;
    [SerializeField] private InputActionReference skipAction;
    [SerializeField] private List<string> skipEnabledScenes; 
    [SerializeField] private string skipOnlyScene; 

    private bool hasNavigated = false;

    private void Awake()
    {
        if (waitTime > 0 && SceneManager.GetActiveScene().name != skipOnlyScene)
        {
            Invoke(nameof(NavigateToNextScreen), waitTime);
        }
    }

    private void Update()
    {
        if (skipEnabledScenes.Contains(SceneManager.GetActiveScene().name) && skipAction.action.triggered)
        {
            NavigateToNextScreen();
        }
    }

    void OnEnable()
    {
        skipAction.action.Enable();
    }

    void OnDisable()
    {
        skipAction.action.Disable();
    }

    private void NavigateToNextScreen()
    {
        if (!hasNavigated)
        {
            hasNavigated = true;
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
