using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviourPunCallbacks
{
  // We will instantiate the prefab using the name
  // of the prefab.
  public string mPlayerPrefabName;

  // We keep a reference to the spawnpoints component.
  // This is required to spawn our player at runtime.
  public PlayerSpawnPoints mSpawnPoints;

  // This is the game object created from the prefab name.
  private GameObject mPlayerGameObject;

  // We will create out third-person camera from
  // this script and bind it to the camera at runtime.
  private ThirdPersonCamera mThirdPersonCamera;

   public AudioSource source;
   public AudioClip clip;

  private void Start()
  {
    CreatePlayer();
  }


  public void CreatePlayer()
  {
    mPlayerGameObject = PhotonNetwork.Instantiate(mPlayerPrefabName,
        mSpawnPoints.GetSpawnPoint().position,
        mSpawnPoints.GetSpawnPoint().rotation,
        0);

    mPlayerGameObject.GetComponent<PlayerMovement>().mFollowCameraForward = false;
    mThirdPersonCamera = Camera.main.gameObject.AddComponent<ThirdPersonCamera>();
    mThirdPersonCamera.mPlayer = mPlayerGameObject.transform;
    mThirdPersonCamera.mDamping = 5.0f;
    mThirdPersonCamera.mCameraType = CameraType.Follow_Track_Pos_Rot;
  }
  public void OnClick_LeaveRoom()
  {
    Debug.LogFormat("LeaveRoom");
    PhotonNetwork.LeaveRoom();
  }
  public async override void OnLeftRoom()
  {
    Debug.LogFormat("OnLeftRoom()");

    source.PlayOneShot(clip); // Play the audio

    while(source.isPlaying) // Wait for the audio to stop playing
    {
        await Task.Yield();
    }

    SceneManager.LoadScene("Menu"); // Load the scene
  }
}
