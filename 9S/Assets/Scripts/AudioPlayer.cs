using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{


    [SerializeField] private AudioSource Source;
    [SerializeField] private AudioClip Clip;

    [SerializeField] private float time = 0.1f;

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
        if (Input.GetMouseButton(0) && t <= 0)
        {
            Source.PlayOneShot(Clip);
            t = time;
        }
    }
}
