//******************************************************
//*Date: 21/07/2018
//******************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
  public new Camera camera;
  public Character character;

  void Update()
  {
    for (int i = 0; i < Level.current.characters.Length; i++)
    {
      if (Input.GetKeyDown(KeyCode.Alpha1 + i))
      {
        if (!Level.current.characters[i].used)
        {
          character = Level.current.characters[i];
          character.used = true;
        }
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

      // Move camera
      Vector3 position = character.transform.position;
      position.z = camera.transform.position.z;
      camera.transform.position = position;
    }

    if(Input.GetKeyDown(KeyCode.Escape)) {
      Level.current.Restart();
    }
  }
}
