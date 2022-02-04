using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PGGE.Patterns;
using UnityEngine.SceneManagement;

public class GameApp : Singleton<GameApp>
{
  // Start is called before the first frame update
  void Start()
  {
    SceneManager.LoadScene("Menu");
  }

  // Update is called once per frame
  void Update()
  {

  }
}
