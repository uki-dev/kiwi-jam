using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongGuy : Character
{
  protected override bool CanMove(Vector2Int direction)
  {
    bool canMove = base.CanMove(direction);
    if (!canMove && Time.time >= nextMove && steps < maximumSteps)
    {
      RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, direction, 0.5f, 1 << LayerMask.NameToLayer("Box"));
      if (raycastHit)
      {
        Box box = raycastHit.collider.GetComponent<Box>();
        if (box && box.Move(direction))
          return true;
      }
    }
    return canMove;
  }
}
