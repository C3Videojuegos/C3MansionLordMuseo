using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detecta_suelo : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

            // Detectar colisiones con otros objetos
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("suelo")){
                audioSource.Play();
            }
    }
}
