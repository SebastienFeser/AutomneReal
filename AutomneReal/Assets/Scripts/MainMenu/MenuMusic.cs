using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip menuMusic;
    [SerializeField] AudioSource audioSource2;
    [SerializeField] AudioClip ambientSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = menuMusic;
        audioSource.loop = true;
        audioSource.Play();

        audioSource2.clip = ambientSound;
        audioSource2.loop = true;
        audioSource2.Play();
    }

    
}
