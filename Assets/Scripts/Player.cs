using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public Character character;

  public void Update()
  {
    if (character)
    {
      Vector2Int direction = Vector2Int.zero;

      if (Input.GetKey(KeyCode.W))
        direction.y += 1;
      if (Input.GetKey(KeyCode.A))
        direction.x -= 1;
      if (Input.GetKey(KeyCode.S))
        direction.y -= 1;
      if (Input.GetKey(KeyCode.D))
        direction.x += 1;
      
      character.Move(direction);
    }
  }
}
