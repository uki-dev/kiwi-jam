using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
  public static Game instance = null;

  [SerializeField]
  private GameObject gameOverCanvas;

  [HideInInspector]
  public Level level;

  [HideInInspector]
  public Player player;

  void Awake()
  {
    if (!instance)
    {
      instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else
      Destroy(gameObject);
  }

  public void GameOver()
  {
    gameOverCanvas.SetActive(true);
    Player player = FindObjectOfType<Player>();
    player.enabled = false;
    BadGuy[] badGuys = FindObjectsOfType<BadGuy>();
    foreach (BadGuy badGuy in badGuys)
      badGuy.enabled = false;
  }
}