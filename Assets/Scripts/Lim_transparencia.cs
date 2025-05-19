using UnityEngine;

public class Lim_transparencia : MonoBehaviour
{
    private Renderer renderizado;

    void Start()
    {
        renderizado = GetComponent<Renderer>();

        // Transparencia al inicio
        Color colorActual = renderizado.material.color;
        colorActual.a = 0.01f; // 0 invisible
        renderizado.material.color = colorActual;
    }

    void OnColliderEnter(Collider otro)
    {
        // Cambiar la transparencia cuando el objeto entra en el collider
        Color colorActual = renderizado.material.color;
        colorActual.a = 0.5f; // valor entre 0 (invisible) y 1 (opaco)
        renderizado.material.color = colorActual;

    }

    void OnColliderExit(Collider otro)
    {
        // Restaurar cuando sale del collider
        Color colorActual = renderizado.material.color;
        colorActual.a = 0f; // Totalmente invisible
        renderizado.material.color = colorActual;
    }
}
