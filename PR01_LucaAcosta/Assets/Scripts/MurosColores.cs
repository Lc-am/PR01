//using UnityEngine;

//public class ColorComparer : MonoBehaviour
//{
//    [SerializeField] private GameObject camaleon; // Referencia al camaleón
//    [SerializeField] private Material obstaculoMaterial; // Material del obstáculo

//    private SkinnedMeshRenderer camaleonRenderer;

//    void Start()
//    {
//        // Obtener el componente SkinnedMeshRenderer del camaleón
//        camaleonRenderer = camaleon.GetComponent<SkinnedMeshRenderer>();
//    }

//    void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("Player"))
//        {
//            // Accede al SkinnedMeshRenderer del camaleón
//            SkinnedMeshRenderer camaleonRenderer = GetComponent<SkinnedMeshRenderer>();
//            if (camaleonRenderer != null)
//            {
//                // Obtén el material del SkinnedMeshRenderer
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