using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Current;
    // Start is called before the first frame update
    public event Action <String> OnPixel;
    private void Awake()
    {
        Current = this;
    }
    

    public void MouseOnPixel(String coord) {
        if (OnPixel != null) {
            OnPixel(coord);
        }
    }
}
