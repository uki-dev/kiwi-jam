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
      RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, direction, stepLength * 0.5f, LayerMask.GetMask("Block"));
      if (raycastHit)
      {
        Block Block = raycastHit.collider.GetComponent<Block>();
        if (Block && !Block.Move(direction))
          blocked = true;
      }
      if (!blocked)
        return base.Move(direction);
    }
    return false;
  }
}
