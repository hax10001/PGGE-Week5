using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class Menu : MonoBehaviour
{
  // We are going to add the button click 
  // from script instead of doing it from 
  // the Unity Editor.
  [SerializeField]
  Button ButtonSinglePlayer;
  [SerializeField]
  Button ButtonMultiPlayer;

   public AudioClip[] clips;
   public AudioSource source;

  private void Start()
  {
    ButtonSinglePlayer.onClick.AddListener(
      delegate ()
      {
        OnClick_SinglePlayer();
      });

    ButtonMultiPlayer.onClick.AddListener(
      delegate ()
      {
        OnClick_MultiPlayer();
      });
  }

  public async void OnClick_SinglePlayer()
  {
    Debug.Log("Loading Single Player");

    source.PlayOneShot(clips[0]); // Play the audio

    while (source.isPlaying) // Wait for the audio to stop playing
    {
        await Task.Yield();
    }

    SceneManager.LoadScene("SinglePlayer"); // Load the scene
  }
  public async void OnClick_MultiPlayer()
  {
    Debug.Log("Loading Multiplayer");

    source.PlayOneShot(clips[1]); // Play the audio

    while (source.isPlaying) // Wait for the audio to stop playing
    {
        await Task.Yield();
    }

    SceneManager.LoadScene("MultiPlayerLauncher"); // Load the scene
  }
}
