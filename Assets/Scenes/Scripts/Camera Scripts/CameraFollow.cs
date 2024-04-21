        using System.Collections;
        using System.Collections.Generic;
        using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // O objeto que a câmera deve seguir
    public Vector3 offset; // O deslocamento da câmera em relação ao alvo
    public bool lookAtTarget = true; // Se verdadeiro, a câmera sempre olhará para o alvo

    private void LateUpdate()
    {
        // Atualize a posição da câmera com base na posição do alvo e no deslocamento
        transform.position = target.position + offset;

        // Se lookAtTarget for verdadeiro, faça a câmera olhar para o alvo
        if (lookAtTarget)
        {
            transform.LookAt(target);
        }
    }
}
