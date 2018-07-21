//******************************************************
//*Date: 21/07/2018
//******************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
  public bool Move(Vector2Int direction)
  {
    bool canMove = true;
    RaycastHit2D[] raycastHits = Physics2D.RaycastAll(transform.position, direction, 0.5f);
    foreach (RaycastHit2D raycastHit in raycastHits)
    {
      if (raycastHit.collider.gameObject != gameObject)
      {
        canMove = false;
      }
    }
    if (canMove)
    {
      transform.position += (Vector3)(Vector2)direction;
      return true;
    }
    return false;
  }
}
