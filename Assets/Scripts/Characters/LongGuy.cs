using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongGuy : Character
{
  public override bool Move(Vector2Int direction)
  {
    if (canMove)
    {
      // Check if there is a pit in the direction of movement, otherwise move normally
      if (Physics2D.Raycast(transform.position, direction, 0.5f, 1 << LayerMask.NameToLayer("Pit")))
      {
        // There is a pit, now check if there is an empty space on the other side
        Vector3 position = transform.position + (Vector3)(Vector2)direction * 2;
				Debug.Log(Physics2D.OverlapBox(position, Vector2.one * 0.5f, 0f));
        if (!Physics2D.OverlapBox(position, Vector2.one * 0.5f, 0f))
        {
          //There is empty space on the other side so let's move the character
          this.direction = direction;
          transform.position = position;
          nextMove = Time.time + 1f / movementSpeed;
          return true;
        }
      }
      else
      {
        return base.Move(direction);
      }
    }
    return false;
  }
}
