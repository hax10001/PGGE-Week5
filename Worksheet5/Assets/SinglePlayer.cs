using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SinglePlayer : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    public async void Leave()
    {
        source.PlayOneShot(clip); // Play the audio

        while (source.isPlaying) // Wait for the audio to finish playing
        {
            await Task.Yield();
        }

        SceneManager.LoadScene("Menu"); // Load the scene
    }
}
