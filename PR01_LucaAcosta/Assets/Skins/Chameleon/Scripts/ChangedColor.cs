using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private List<Material> materials; 
    [SerializeField] private InputActionReference changeColorAction; 

    private SkinnedMeshRenderer skinnedMeshRenderer;
    public int currentMaterialIndex = 0; 

    void Start()
    {
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();

        changeColorAction.action.performed += ChangeColor;
    }

    public void OnEnable()
    {
        changeColorAction.action.Enable();
    }

    public void OnDisable()
    {
        changeColorAction.action.Disable();
    }

    public void ChangeColor(InputAction.CallbackContext context)
    {
        if (materials.Count > 0 && skinnedMeshRenderer != null)
        {
            currentMaterialIndex = (currentMaterialIndex + 1) % materials.Count; 
            skinnedMeshRenderer.material = materials[currentMaterialIndex]; 
        }
    }
}





