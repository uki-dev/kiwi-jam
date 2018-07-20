using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
  public int maximumSteps;
  public float movementSpeed;

  bool moving;
  int steps;
  float delta;

  public void Move(Vector2Int direction)
  {
    if (!moving && steps < maximumSteps)
    {
      if (!Physics2D.Raycast(transform.position, direction, 0.5f))
        StartCoroutine(IMove(direction));

      steps++;
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
