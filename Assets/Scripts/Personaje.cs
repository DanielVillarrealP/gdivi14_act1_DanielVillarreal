using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    // Variables globales
    private CharacterController controller;
    [SerializeField] private Transform camara;
    [SerializeField] private float velocidad;
    [SerializeField] private Vector2 sensibilidad;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Bloqueamos el cursor para evitar que se salga de la ventana
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarMovimientoPersonaje();
        ActualizarMovimientoCamara();
    }

    private void ActualizarMovimientoPersonaje()
    {
        /* Movimiento del personaje */
        float vKeyInput = Input.GetAxisRaw("Vertical"); // Nota - Posibles valores: -1 0 1
        float hKeyInput = Input.GetAxisRaw("Horizontal"); // Nota - Posibles valores: -1 0 1
        
        Vector3 movimientoPersonaje = transform.right * hKeyInput + transform.forward * vKeyInput; // Montamos el vector de movimiento de forma local para que el personaje se mueve conforme a donde estamos mirando

        controller.SimpleMove(movimientoPersonaje * velocidad /* * Time.deltaTime - En SimpleMove no añadimos por tiempo (en Move normal sí) */);
    }

    private void ActualizarMovimientoCamara()
    {
        /* Movimiento de la cámara */
        float hMouseInput = Input.GetAxis("Mouse X") * Time.deltaTime;
        float vMouseInput = Input.GetAxis("Mouse Y") * Time.deltaTime;

        if (hMouseInput != 0)
        {
            transform.Rotate(Vector3.up * hMouseInput * sensibilidad.x);
        }

        if (vMouseInput != 0)
        {
            float angulo = (camara.localEulerAngles.x - vMouseInput * sensibilidad.y + 360) % 360;
            if (angulo > 180)
            {
                angulo -= 360;
            }
            angulo = Mathf.Clamp(angulo, -80, 80);

            camara.localEulerAngles = Vector3.right * angulo;
        }
    }

}
