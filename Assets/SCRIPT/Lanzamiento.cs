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
        rb.isKinematic = false; // Hacer el Rigidbody kinemático al principio para evitar que caiga
        posicionInicial = transform.position;
        rotacionInicial = transform.rotation;
    }

    void Update()
    {
        // Comprobar si se suelta el botón de agarre (o cualquier otro método para soltar en VR)
        if (!lanzado && Input.GetButtonUp("Oculus_Grab")) // Cambiar "Oculus_Grab" por el nombre real del botón de soltar en Oculus
        {
            Lanzar();
        }
    }

    void Lanzar()
    {
        rb.isKinematic = false; // Activar el Rigidbody para que la física lo afecte
        lanzado = true;
        
        // Calcular dirección y velocidad del lanzamiento
        Vector3 direccionLanzamiento = transform.forward; // Lanza hacia adelante según la orientación actual del objeto
        float velocidadLanzamiento = 5f; // Velocidad inicial de lanzamiento, ajustar según sea necesario

        rb.velocity = direccionLanzamiento * velocidadLanzamiento;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Aquí podrías añadir lógica para manejar colisiones si es necesario
    }

    void ResetearObjeto()
    {
        // Método para resetear el objeto a su posición y rotación inicial
        rb.isKinematic = true;
        lanzado = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = posicionInicial;
        transform.rotation = rotacionInicial;
    }
}


