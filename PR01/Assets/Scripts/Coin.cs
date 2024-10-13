//using DG.Tweening;
//using UnityEngine;

//public class Coin : MonoBehaviour
//{
//    public static int count;      // Monedas recogidas
//    public static int maxCount;   // Total de monedas
//    private static bool maxCountInitialized = false;  // Nuevo flag para evitar duplicaci�n

//    void /*Awake*/()
//    {
//        // Solo incrementamos maxCount si no ha sido inicializado
//        if (!maxCountInitialized)
//        {
//            maxCount++;  // Incrementa el n�mero total de monedas en la escena solo una vez
//        }
//    }

//    void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player"))  // Aseg�rate de que solo el jugador pueda recoger monedas
//        {
//            count++;  // Incrementa el n�mero de monedas recogidas

//            GetComponent<Collider>().enabled = false;  // Desactiva el collider para evitar m�ltiples activaciones

//            // Animaciones de recolecci�n
//            transform.DOMove(transform.position + Vector3.up * 1.25f, 0.5f)
//                .OnComplete(() =>
//                {
//                    transform.DOScale(Vector3.zero, 2f)
//                        .OnComplete(() => Destroy(gameObject));  // Destruye el objeto despu�s de la animaci�n
//                });
//        }
//    }

//    void Start()
//    {
//        // Solo marcamos maxCount como inicializado una vez que todas las monedas est�n creadas
//        maxCountInitialized = true;

//        // Animaci�n de rotaci�n infinita
//        transform.DORotate(Vector3.up * 360f, 1f).
//        SetRelative().
//        SetEase(Ease.Linear).
//        SetLoops(-1); // Rotaci�n infinita
//    }
//}



