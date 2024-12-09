//using UnityEngine;

//public class ColorComparer : MonoBehaviour
//{
//    [SerializeField] private GameObject camaleon; // Referencia al camale�n
//    [SerializeField] private Material obstaculoMaterial; // Material del obst�culo

//    private SkinnedMeshRenderer camaleonRenderer;

//    void Start()
//    {
//        // Obtener el componente SkinnedMeshRenderer del camale�n
//        camaleonRenderer = camaleon.GetComponent<SkinnedMeshRenderer>();
//    }

//    void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("Player"))
//        {
//            // Accede al SkinnedMeshRenderer del camale�n
//            SkinnedMeshRenderer camaleonRenderer = GetComponent<SkinnedMeshRenderer>();
//            if (camaleonRenderer != null)
//            {
//                // Obt�n el material del SkinnedMeshRenderer
//                Material materialCamaleon = camaleonRenderer.material;
//                Material obstaculoMaterial = collision.gameObject.GetComponent<Renderer>().material;

//                if (materialCamaleon.name == obstaculoMaterial.name)
//                {
//                    Debug.Log("Los materiales son del mismo tipo.");
//                }
//                else
//                {
//                    Debug.Log("Los materiales son diferentes.");
//                }
//            }
//            else
//            {
//                Debug.LogError("El objeto 'Camaleon' no tiene un SkinnedMeshRenderer.");
//            }
//        }
//    }
//}