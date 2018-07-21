using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongGuy : Character
{
  public override bool Move(Vector2Int direction)
  {
    if (canMove)
    {
      bool blocked = false;
      RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, direction, 0.5f, 1 << LayerMask.NameToLayer("Box"));
      if (raycastHit)
      {
        Box box = raycastHit.collider.GetComponent<Box>();
        if (box && !box.Move(direction))
          blocked = true;
      }
      if (!blocked)
        return base.Move(direction);
    }
    return false;
  }
}
