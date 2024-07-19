using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzamientoVR : MonoBehaviour
{
    private Rigidbody rb;
    private bool lanzado = false;
    private Vector3 posicionInicial;
    private Quaternion rotacionInicial;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false; // Hacer el Rigidbody kinem�tico al principio para evitar que caiga
        posicionInicial = transform.position;
        rotacionInicial = transform.rotation;
    }

    void Update()
    {
        // Comprobar si se suelta el bot�n de agarre (o cualquier otro m�todo para soltar en VR)
        if (!lanzado && Input.GetButtonUp("Oculus_Grab")) // Cambiar "Oculus_Grab" por el nombre real del bot�n de soltar en Oculus
        {
            Lanzar();
        }
    }

    void Lanzar()
    {
        rb.isKinematic = false; // Activar el Rigidbody para que la f�sica lo afecte
        lanzado = true;
        
        // Calcular direcci�n y velocidad del lanzamiento
        Vector3 direccionLanzamiento = transform.forward; // Lanza hacia adelante seg�n la orientaci�n actual del objeto
        float velocidadLanzamiento = 5f; // Velocidad inicial de lanzamiento, ajustar seg�n sea necesario

        rb.velocity = direccionLanzamiento * velocidadLanzamiento;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Aqu� podr�as a�adir l�gica para manejar colisiones si es necesario
    }

    void ResetearObjeto()
    {
        // M�todo para resetear el objeto a su posici�n y rotaci�n inicial
        rb.isKinematic = true;
        lanzado = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = posicionInicial;
        transform.rotation = rotacionInicial;
    }
}


