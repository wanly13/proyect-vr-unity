using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class Animaciones_Horse : MonoBehaviour
{
    Animator n_animator;
    bool isJump = false;  // Variable para controlar la animaci�n de salto
    bool isTrot = false;  // Variable para controlar la animaci�n de trote
    bool isRight = false; // Variable para controlar la animaci�n de movimiento a la derecha
    bool isLeft = false;  // Variable para controlar la animaci�n de movimiento a la izquierda
    Vector3 startPosition;
    Vector3 targetPosition;
    public float trotDistance = 5f; // Distancia del trote, ajusta seg�n sea necesario
    public float jumpDistance = 5f; // Distancia del salto, ajusta seg�n sea necesario
    public float sideStepDistance = 2f; // Distancia de movimiento lateral, ajusta seg�n sea necesario
    public float jumpHeight = 2f; // Altura del salto, ajusta seg�n sea necesario
    private bool trotting = false;
    private bool jumping = false;
    private bool movingRight = false;
    private bool movingLeft = false;
    private float moveProgress = 0f;
    private float moveDuration = 1f; // Duraci�n del movimiento

    // Start is called before the first frame update
    void Start()
    {
        n_animator = GetComponent<Animator>();
        n_animator.applyRootMotion = false; // Desactiva el root motion
    }

    // Update is called once per frame
    void Update()
    {
        // Verificar si se presiona la tecla W (trotar/avanzar)
        if (!isTrot && Input.GetKeyDown(KeyCode.W))
        {
            isTrot = true;
            trotting = true;
            moveProgress = 0f;
            startPosition = transform.position;
            targetPosition = transform.position + transform.forward * trotDistance;
            n_animator.SetBool("isTrot", isTrot);
            Debug.Log("INICIO DE TROTE");
        }

        // Verificar si se hace clic derecho (bot�n derecho del rat�n) para salto
        if (!isJump && Input.GetMouseButtonDown(1))  // 1 representa el bot�n derecho del rat�n
        {
            isJump = true;
            jumping = true;
            moveProgress = 0f;
            startPosition = transform.position;
            targetPosition = transform.position + transform.forward * jumpDistance;
            n_animator.SetBool("isJumping", isJump);
            Debug.Log("INICIO DE SALTO");
        }

        // Verificar si se presiona la tecla A (izquierda)
        if (!isLeft && Input.GetKeyDown(KeyCode.A))
        {
            isLeft = true;
            movingLeft = true;
            moveProgress = 0f;
            startPosition = transform.position;
            targetPosition = transform.position - transform.right * sideStepDistance;
            n_animator.SetBool("isLeft", isLeft);
            Debug.Log("MOVIMIENTO A LA IZQUIERDA INICIADO");
        }

        // Verificar si se presiona la tecla D (derecha)
        if (!isRight && Input.GetKeyDown(KeyCode.D))
        {
            isRight = true;
            movingRight = true;
            moveProgress = 0f;
            startPosition = transform.position;
            targetPosition = transform.position + transform.right * sideStepDistance;
            n_animator.SetBool("isRight", isRight);
            Debug.Log("MOVIMIENTO A LA DERECHA INICIADO");
        }

        // Control del trote/avance
        if (trotting)
        {
            moveProgress += Time.deltaTime / moveDuration;
            if (moveProgress >= 1f)
            {
                moveProgress = 1f;
                trotting = false;
                OnTrotAnimationFinish();
            }

            transform.position = Vector3.Lerp(startPosition, targetPosition, moveProgress);
        }

        // Control del salto
        if (jumping)
        {
            moveProgress += Time.deltaTime / moveDuration;
            if (moveProgress >= 1f)
            {
                moveProgress = 1f;
                jumping = false;
                OnJumpAnimationFinish();
            }

            float height = Mathf.Sin(Mathf.PI * moveProgress) * jumpHeight;
            transform.position = Vector3.Lerp(startPosition, targetPosition, moveProgress) + Vector3.up * height;
        }

        // Control del movimiento a la izquierda
        if (movingLeft)
        {
            moveProgress += Time.deltaTime / moveDuration;
            if (moveProgress >= 1f)
            {
                moveProgress = 1f;
                movingLeft = false;
                OnLeftAnimationFinish();
            }

            transform.position = Vector3.Lerp(startPosition, targetPosition, moveProgress);
        }

        // Control del movimiento a la derecha
        if (movingRight)
        {
            moveProgress += Time.deltaTime / moveDuration;
            if (moveProgress >= 1f)
            {
                moveProgress = 1f;
                movingRight = false;
                OnRightAnimationFinish();
            }

            transform.position = Vector3.Lerp(startPosition, targetPosition, moveProgress);
        }
    }

    // M�todo que se llamar� al final de la animaci�n de trote
    public void OnTrotAnimationFinish()
    {
        isTrot = false;
        n_animator.SetBool("isTrot", isTrot);
        Debug.Log("ANIMACI�N DE TROTE FINALIZADA");

        // Ajustar la posici�n final despu�s de la animaci�n
        transform.position = targetPosition;
    }

    // M�todo que se llamar� al final de la animaci�n de salto
    public void OnJumpAnimationFinish()
    {
        isJump = false;
        n_animator.SetBool("isJumping", isJump);
        Debug.Log("ANIMACI�N DE SALTO FINALIZADA");

        // Ajustar la posici�n final despu�s de la animaci�n
        transform.position = targetPosition;
    }

    // M�todo que se llamar� al final de la animaci�n de movimiento a la izquierda
    public void OnLeftAnimationFinish()
    {
        isLeft = false;
        n_animator.SetBool("isLeft", isLeft);
        Debug.Log("MOVIMIENTO A LA IZQUIERDA FINALIZADO");

        // Ajustar la posici�n final despu�s de la animaci�n
        transform.position = targetPosition;
    }

    // M�todo que se llamar� al final de la animaci�n de movimiento a la derecha
    public void OnRightAnimationFinish()
    {
        isRight = false;
        n_animator.SetBool("isRight", isRight);
        Debug.Log("MOVIMIENTO A LA DERECHA FINALIZADO");

        // Ajustar la posici�n final despu�s de la animaci�n
        transform.position = targetPosition;
    }
}

