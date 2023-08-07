using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{


    [SerializeField] private AudioSource Source;
    [SerializeField] private AudioClip Clip;

    [SerializeField] private float time = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (Input.GetMouseButton(0) && time <= 0)
        {
            Source.PlayOneShot(Clip);
            time = 0.1f;
        }
    }
}
