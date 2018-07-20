using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
  public float speed;

  bool moving;
  float delta;

  public void Move(Vector2Int direction)
  {
    if (!moving)
      StartCoroutine(IMove(direction));
  }

  private IEnumerator IMove(Vector2Int direction)
  {
    float time = delta;
    Vector2 startPosition = transform.position;
    Vector2 endPosition = startPosition + direction;

    moving = true;
    while (time < 1f)
    {
      transform.position = Vector2.Lerp(startPosition, endPosition, time);
      time += Time.deltaTime * speed;
      yield return null;
    }
    transform.position = endPosition;
    delta = time - 1f;
    moving = false;
  }
}
