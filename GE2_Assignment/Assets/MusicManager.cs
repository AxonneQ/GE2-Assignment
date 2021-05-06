using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public List<AudioClip> tracks;
    
    private AudioSource source;
    private int currentTrack = -1;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        tracks = new List<AudioClip>();

        for(int i = 0; i < transform.childCount; i++) {
            tracks.Add(transform.GetChild(i).GetComponent<Track>().audioFile);
        }

        if(tracks.Count > 0) {
            source.clip = tracks[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
    

        if(tracks.Count - 1 > currentTrack && !source.isPlaying) {
            currentTrack++;
            source.clip = tracks[currentTrack];
            source.Play();
        }
    }
}
