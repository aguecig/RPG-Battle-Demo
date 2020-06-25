using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip[] _audioClips;

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Home Town")
        {
            _audioSource.clip = _audioClips[0];
        }

        else if (scene.name == "Battle")
        {
            _audioSource.clip = _audioClips[1];
        }

        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopAudio()
    {
        _audioSource.Stop();
    }
}
