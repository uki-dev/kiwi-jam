//******************************************************
//*Date: 21/07/2018
//******************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
  public new string name;
  public int maximumSteps;
  public int stepLength;
  public float movementSpeed;
  public LayerMask collisionMask;

  [HideInInspector]
  public bool used;

  [HideInInspector]
  public Vector2Int direction;

  protected int steps;
  protected float nextMove;
  protected bool canMove
  {
    get
    {
      return Time.time >= nextMove && (maximumSteps == 0 || steps < maximumSteps);
    }
  }

  public virtual bool Move(Vector2Int direction)
  {
    // Stop diagonal movement
    if (Mathf.Abs(direction.x) == Mathf.Abs(direction.y))
      return false;


    //If its time to move and we have steps left
    if (canMove)
    {
      bool blocked = false;
      RaycastHit2D[] raycastHits = Physics2D.RaycastAll(transform.position, direction, stepLength, collisionMask);
      foreach (RaycastHit2D raycastHit in raycastHits)
      {
        //if the raycast hits nothing. (end and return false)
        if (raycastHit.collider.gameObject != gameObject)
          blocked = true;
      }

      // Move character if it isn't blocked
      if (!blocked)
      {
        steps++;
        this.direction = direction;
        transform.position += (Vector3)(Vector2)direction * stepLength;
        nextMove = Time.time + 1f / movementSpeed;
        return true;
      }
    }
    return false;
  }
}
