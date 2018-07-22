//******************************************************
//*Date: 21/07/2018
//******************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public Character character;

  void Update()
  {
    for (int i = 0; i < Game.instance.level.characters.Length; i++)
    {
      if (Input.GetKeyDown(KeyCode.Alpha1 + i))
      {
        character = Game.instance.level.characters[i];
      }
    }

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

      Vector3 position = character.transform.position;
      position.z = transform.position.z;
      transform.position = position;
    }
  }
}
