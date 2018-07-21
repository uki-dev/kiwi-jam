//******************************************************
//*Date: 21/07/2018
//******************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Box : MonoBehaviour
{
  bool lodged;

  public bool Move(Vector2Int direction)
  {
    if (!lodged)
    {
      // Check first if there's a pit in the movement direction that the box can be lodged into
      RaycastHit2D pitRaycastHit = Physics2D.Raycast(transform.position, direction, 0.5f, 1 << LayerMask.NameToLayer("Pit"));
      if (pitRaycastHit)
      {
        // Remove collision on the tilemap and the box
        Tilemap tilemap = pitRaycastHit.collider.GetComponent<Tilemap>();
        // Flooring this doesn't work, guess we just - 0.5f?
        tilemap.SetTile(tilemap.layoutGrid.WorldToCell(pitRaycastHit.point - new Vector2(0.5f, 0.5f)), null);
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        transform.position += (Vector3)(Vector2)direction;
        lodged = true;
        return true;
      }

      bool blocked = false;
      RaycastHit2D[] raycastHits = Physics2D.RaycastAll(transform.position, direction, 0.5f);
      foreach (RaycastHit2D raycastHit in raycastHits)
      {
        if (raycastHit.collider.gameObject != gameObject)
          blocked = true;
      }
      if (!blocked)
      {
        transform.position += (Vector3)(Vector2)direction;
        return true;
      }
    }
    return false;
  }
}
