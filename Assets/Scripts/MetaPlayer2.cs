using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaPlayer2 : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            audioSource.PlayOneShot(audioClip);
        }
    }

}
