using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn_item : MonoBehaviour
{

    public float velocidadRotacion = 50f; // velocidad de rotación

    void Update()
    {
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);
    }


}
