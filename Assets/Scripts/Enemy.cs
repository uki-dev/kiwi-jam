using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
  public Vector2Int[] path;

  int pathIndex;
  bool reversing;

  void Start()
  {
    transform.position += (Vector3)(Vector2)path[pathIndex];
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
      int steps = (int)direction.magnitude;
      for (int i = 0; i < steps; i++)
      {
        if (Move(normal))
          yield return new WaitForSeconds(1f / movementSpeed);
      }

      pathIndex = (reversing) ? pathIndex - 1 : pathIndex + 1;
      if (reversing && pathIndex == 0)
        reversing = false;
      if (!reversing && pathIndex + 1 == path.Length)
        reversing = true;
    }
  }
}
