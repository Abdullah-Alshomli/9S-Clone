

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{


    [SerializeField] private AudioSource Source;
    [SerializeField] private AudioClip Clip;

    [SerializeField] private float time = 0.1f;

    [SerializeField] private float timeToDestroy = 3f;

    private bool canPlay = true;

    private float t = 0;
    // Start is called before the first frame update
    void Start()
    { 
        t = time;
    }

    // Update is called once per frame
    void Update()
    {
        t -= Time.deltaTime;
        if (t <= 0 && canPlay)
        {
            Source.PlayOneShot(Clip);
            t = time;
            canPlay = false;
        }


        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0 )
        {
            Destroy(gameObject);
        }

    }
}
