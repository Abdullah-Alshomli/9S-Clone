using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource Source;
    [SerializeField] private List<AudioClip> Clips;
    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, Clips.Count);
        Source.loop = true;
        Source.clip = Clips[index];
        Source.Play();
        //Source.PlayOneShot(Clips[index]);
        
    }
}
