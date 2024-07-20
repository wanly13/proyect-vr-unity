using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzamientoVR : MonoBehaviour
{
    public GameObject pelotaPrefab; // Variable para el prefab de la pelota
    public Transform spawnPoint; // Punto de aparición de la pelota
    public float speed; // Velocidad de lanzamiento

    void Start()
    {
        // Inicialización si es necesario
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) // Verifica si se presiona la flecha hacia arriba
        {
            LanzarPelota();
        }
    }

    void LanzarPelota()
    {
        
        // Obtiene el Rigidbody de la pelota y aplica una fuerza
        Rigidbody rb = pelotaPrefab.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        }
    }
}
