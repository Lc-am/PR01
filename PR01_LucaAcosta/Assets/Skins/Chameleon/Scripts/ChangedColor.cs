using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private List<Material> materials; // Lista de materiales para cambiar
    [SerializeField] private InputActionReference changeColorAction; // Referencia de InputAction para el cambio de color

    private SkinnedMeshRenderer skinnedMeshRenderer;
    private int currentMaterialIndex = 0; // �ndice del material actual

    void Start()
    {
        // Buscar el SkinnedMeshRenderer en el objeto y sus hijos
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        if (skinnedMeshRenderer == null)
        {
            Debug.LogError("No se ha encontrado un SkinnedMeshRenderer en el objeto o en sus hijos.");
        }

        if (materials.Count == 0)
        {
            Debug.LogError("La lista de materiales est� vac�a. A�ade materiales en el inspector.");
        }

        // Aseg�rate de que la acci�n de cambio de color est� habilitada
        changeColorAction.action.performed += ChangeColor;
    }

    private void OnEnable()
    {
        changeColorAction.action.Enable();
    }

    private void OnDisable()
    {
        changeColorAction.action.Disable();
    }

    private void ChangeColor(InputAction.CallbackContext context)
    {
        if (materials.Count > 0 && skinnedMeshRenderer != null)
        {
            currentMaterialIndex = (currentMaterialIndex + 1) % materials.Count; // Cambia al siguiente material en la lista
            skinnedMeshRenderer.material = materials[currentMaterialIndex]; // Aplica el nuevo material
            Debug.Log($"Material cambiado a: {materials[currentMaterialIndex].name}");
        }
    }
}
