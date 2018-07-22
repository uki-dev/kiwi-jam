using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
  public static Level current;

  public Character[] characters;
  public string next;

  void Awake()
  {
    current = this;
  }

  public void Complete()
  {
    if (next.Length > 0)
      SceneManager.LoadSceneAsync(next);
  }

  public void Fail()
  {
    Scene scene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(scene.name);
  }
}
