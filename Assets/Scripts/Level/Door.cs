//******************************************************
//*Date: 21/07/2018
//******************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
  public bool open
  {
    get
    {
      return _open;
    }
    set
    {
      _open = value;
      GetComponent<SpriteRenderer>().sprite = (value) ? doorOpened : doorClosed;
      gameObject.layer = LayerMask.NameToLayer((value) ? "Ignore Raycast" : "Default");
    }
  }
  [SerializeField]
  private bool _open;

  public Sprite doorOpened;
  public Sprite doorClosed;

  void OnValidate()
  {
    open = open;
  }
}
