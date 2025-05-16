using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Valve.VR.InteractionSystem;

public class DetachedObject : MonoBehaviour
{
    public AudioClip detachSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = detachSound;
    }

    /*private void OnDetachedFromHand(Hand hand)
    {
        audioSource.Play();
    }*/
}
