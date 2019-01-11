using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusic : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip mainMusic;
    [SerializeField] AudioSource audioSource2;
    [SerializeField] AudioClip ambient;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = mainMusic;
        audioSource.Play();
        audioSource.loop = true;
        audioSource2.clip = ambient;
        audioSource2.Play();
        audioSource2.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
