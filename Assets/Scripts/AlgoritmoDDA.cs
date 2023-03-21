using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlgoritmoDDA : MonoBehaviour
{
    public void algoritmo(int x0, int y0, int x1, int y1, List<List<GameObject>> MatrixScreen, Material materialOn)
    {
        float ax, ay, x, y, res;
        int i;
        if (Mathf.Abs(x1 - x0) >= Mathf.Abs(y1 - y0)) res = Mathf.Abs(x1 - x0);
        else res = Mathf.Abs(y1 - y0);

        ax = (x1 - x0) / res;//el valor a aumentar en x
        ay = (y1 - y0) / res;//el valor a aumentar en y

        x = (float)x0;
        y = (float)y0;

        i = 0;
        while (i <= res)
        {
            MatrixScreen[(int)Mathf.Round(x)][(int)Mathf.Round(y)].GetComponent<PixelScript>().Switch(materialOn, true);
            x = x + ax;
            y = y + ay;
            i++;
        }
    }
}
