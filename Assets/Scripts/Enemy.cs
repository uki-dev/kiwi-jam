using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
  public Vector2Int[] path;

  void Start()
  {
    transform.position += (Vector3)(Vector2)path[0];
    StartCoroutine(Patrol());
  }

  void Update()
  {
    if (Physics2D.Raycast(transform.position, direction, Mathf.Infinity, 1 << LayerMask.NameToLayer("Character")))
    {
      Debug.Log("Game Over");
    }
  }

  IEnumerator Patrol()
  {
    int step = 0;
    int pathIndex = 0;
    bool reversing = false;
    while (true)
    {
      Vector2Int start = path[pathIndex];
      Vector2Int end = path[(reversing) ? pathIndex - 1 : pathIndex + 1];
      Vector2Int direction = end - start;
      Vector2Int normal = new Vector2Int(Mathf.Clamp(direction.x, -1, 1), Mathf.Clamp(direction.y, -1, 1));

      bool blocked = false;
      int steps = (int)direction.magnitude;
      for (int i = step; i < steps; i++)
      {
        if (Move(normal))
          yield return new WaitForSeconds(1f / movementSpeed);
        else
        {
          // Adjust current path index and switch directions and store the current step for the new path
          pathIndex = (reversing) ? pathIndex - 1 : pathIndex + 1;
          reversing = !reversing;
          step = steps - i;
          blocked = true;
          break;
        }
      }

      if (blocked)
        continue;

      step = 0;
      pathIndex = (reversing) ? pathIndex - 1 : pathIndex + 1;
      if (reversing && pathIndex == 0)
        reversing = false;
      if (!reversing && pathIndex + 1 == path.Length)
        reversing = true;

      yield return null;
    }
  }
}
