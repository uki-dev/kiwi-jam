using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
  public int maximumSteps;
  public float movementSpeed;

  [HideInInspector]
  public Vector2Int direction;

  bool moving;
  int steps;
  float nextMove;

  float delta;

  public void Move(Vector2Int direction)
  {
    if (Time.time >= nextMove && steps < maximumSteps)
    {
      bool canMove = true;
      RaycastHit2D[] raycastHits = Physics2D.RaycastAll(transform.position, direction, 0.5f);
      foreach (RaycastHit2D raycastHit in raycastHits)
      {
        if (raycastHit.collider.gameObject != gameObject)
        {
          canMove = false;
          Box box = raycastHit.collider.GetComponent<Box>();
          if (box && box.Move(direction))
          {
            canMove = true;
          }
        }
      }
      if (canMove)
      {
        this.direction = direction;
        transform.position += (Vector3)(Vector2)direction;
        nextMove = Time.time + 1f / movementSpeed;
      }
    }
  }

  IEnumerator IMove(Vector2Int direction)
  {
    float time = delta;
    Vector2 startPosition = transform.position;
    Vector2 endPosition = startPosition + direction;

    moving = true;
    while (time < 1f)
    {
      transform.position = Vector2.Lerp(startPosition, endPosition, time);
      time += Time.deltaTime * movementSpeed;
      yield return null;
    }
    transform.position = endPosition;
    delta = time - 1f;
    moving = false;
  }
}
