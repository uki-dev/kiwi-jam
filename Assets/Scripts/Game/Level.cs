using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
  public Character[] characters;
  public string nextLevel;

  void Awake()
  {
    Game.instance.level = this;
  }

  public void Complete()
  {
    if (nextLevel.Length > 0)
      SceneManager.LoadSceneAsync(nextLevel);
    else
    {
      // return to menu?
    }
  }
}
