﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
  void Awake()
  {
    DontDestroyOnLoad(this);
  }
}
