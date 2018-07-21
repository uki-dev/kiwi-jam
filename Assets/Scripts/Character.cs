﻿//******************************************************
//*Date: 21/07/2018
//******************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
  public new string name;
  public int maximumSteps;
  public float movementSpeed;
  public LayerMask collisionMask;

  [HideInInspector]
  public Vector2Int direction;

  protected int steps;
  protected float nextMove;

  protected bool canMove
  {
    get
    {
      return Time.time >= nextMove && (steps == 0 || steps < maximumSteps);
    }
  }

  //bool moving;
  //float delta;

  public virtual bool Move(Vector2Int direction)
  {
    // stop diagonal movement
    if (Mathf.Abs(direction.x) == Mathf.Abs(direction.y))
      return false;


    //If its time to move and we have steps left
    if (canMove)
    {
      bool blocked = false;
      RaycastHit2D[] raycastHits = Physics2D.RaycastAll(transform.position, direction, 0.5f, collisionMask);
      foreach (RaycastHit2D raycastHit in raycastHits)
      {
        //if the raycast hits nothing. (end and return false)
        if (raycastHit.collider.gameObject != gameObject)
          blocked = true;
      }

      if (!blocked)
      {
        this.direction = direction;
        transform.position += (Vector3)(Vector2)direction;
        nextMove = Time.time + 1f / movementSpeed;
        return true;
      }
    }
    return false;
  }

  /*
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
  */
}
