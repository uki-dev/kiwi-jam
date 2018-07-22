using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
  public string level;

  void Update()
  {
    if (Input.anyKeyDown)
    {
      SceneManager.LoadScene(level);
    }
  }
}
