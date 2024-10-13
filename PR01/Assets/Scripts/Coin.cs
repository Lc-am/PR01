//using DG.Tweening;
//using UnityEngine;

//public class Coin : MonoBehaviour
//{
//    public static int count;      // Monedas recogidas
//    public static int maxCount;   // Total de monedas
//    private static bool maxCountInitialized = false;  // Nuevo flag para evitar duplicación

//    void /*Awake*/()
//    {
//        // Solo incrementamos maxCount si no ha sido inicializado
//        if (!maxCountInitialized)
//        {
//            maxCount++;  // Incrementa el número total de monedas en la escena solo una vez
//        }
//    }

//    void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player"))  // Asegúrate de que solo el jugador pueda recoger monedas
//        {
//            count++;  // Incrementa el número de monedas recogidas

//            GetComponent<Collider>().enabled = false;  // Desactiva el collider para evitar múltiples activaciones

//            // Animaciones de recolección
//            transform.DOMove(transform.position + Vector3.up * 1.25f, 0.5f)
//                .OnComplete(() =>
//                {
//                    transform.DOScale(Vector3.zero, 2f)
//                        .OnComplete(() => Destroy(gameObject));  // Destruye el objeto después de la animación
//                });
//        }
//    }

//    void Start()
//    {
//        // Solo marcamos maxCount como inicializado una vez que todas las monedas estén creadas
//        maxCountInitialized = true;

//        // Animación de rotación infinita
//        transform.DORotate(Vector3.up * 360f, 1f).
//        SetRelative().
//        SetEase(Ease.Linear).
//        SetLoops(-1); // Rotación infinita
//    }
//}



