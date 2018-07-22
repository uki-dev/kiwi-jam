//******************************************************
//*Date: 21/07/2018
//******************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuy : Character
{
  public Vector2Int[] path;

  Vector2Int pathDirection;
  int step, stepCount, pathIndex;
  bool started, reversing;

  void Start()
  {
    transform.position += (Vector3)(Vector2)path[0];
  }

  void Update()
  {
    if (!started)
    {
      Vector2Int start = path[pathIndex];
      Vector2Int end = path[(reversing) ? pathIndex - 1 : pathIndex + 1];
      Vector2Int offset = end - start;
      pathDirection = new Vector2Int(Mathf.Clamp(offset.x, -1, 1), Mathf.Clamp(offset.y, -1, 1));
      stepCount = (int)offset.magnitude;
      started = true;
    }

    if (canMove)
    {
      if (Move(pathDirection))
      {
        step++;
        if (step == stepCount)
        {
          step = 0;
          started = false;

          pathIndex = (reversing) ? pathIndex - 1 : pathIndex + 1;
          if (reversing && pathIndex == 0)
            reversing = false;
          if (!reversing && pathIndex + 1 == path.Length)
            reversing = true;
        }
      }
      else
      {
        // Adjust current path index and switch directions and store the current step for the new path
        pathIndex = (reversing) ? pathIndex - 1 : pathIndex + 1;
        reversing = !reversing;
        step = stepCount - step;
        started = false;
      }
    }

    int layer = gameObject.layer;
    gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, pathDirection, Mathf.Infinity, ~LayerMask.GetMask("Gone Guy", "Ignore Raycast"));
    if (raycastHit && raycastHit.collider.CompareTag("Player"))
      Level.current.Fail();

    gameObject.layer = layer;
  }
}
