﻿using UnityEngine;
using System.Collections;

public class AstroidFadeOut : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 8f);
    }
}