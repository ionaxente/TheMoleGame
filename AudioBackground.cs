using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBackground : MonoBehaviour
{

    private float _VolumNecesar = 0.6f; //Seconds

    private bool VolumSetat = false;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource)
            audioSource.volume = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!VolumSetat)
        {
            if(audioSource.volume < _VolumNecesar)
            {
                audioSource.volume += 0.05f;
            }
            else
            {
                VolumSetat = true;
            }
        }
    }
}
