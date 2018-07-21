//******************************************************
//*Date: 21/07/2018
//******************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Block : MonoBehaviour
{
  [HideInInspector]
  public Tile lodgedTile;

  public bool Move(Vector2Int direction)
  {
    // Check first if there's a pit in the movement direction that the block can be lodged into
    RaycastHit2D pitRaycastHit = Physics2D.Raycast(transform.position, direction, 0.5f, 1 << LayerMask.NameToLayer("Pit"));
    if (pitRaycastHit)
    {
      // Change the pit tile to the lodged one and destroy block game object
      Tilemap tilemap = pitRaycastHit.collider.GetComponent<Tilemap>();
      tilemap.SetTile(tilemap.layoutGrid.WorldToCell(pitRaycastHit.point - new Vector2(0.5f, 0.5f)), lodgedTile);
      GameObject.Destroy(gameObject);
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

    return false;
  }
}
