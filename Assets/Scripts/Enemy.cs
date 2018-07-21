using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
  public Vector2Int[] path;

  public int step = 0;
  public int pathIndex = 0;
  public bool reversing = false;

  void Start()
  {
    transform.position += (Vector3)(Vector2)path[0];
    StartCoroutine(Patrol());
  }

  void Update()
  {
    if (Physics2D.Raycast(transform.position, direction, Mathf.Infinity, LayerMask.NameToLayer("Player")))
    {
      Debug.Log("Game Over");
      // game over ?
    }
  }

  IEnumerator Patrol()
  {

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
          Debug.Log("Blocked");
          reversing = !reversing;
          step = steps - 1 - i;
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


    }
  }
}
