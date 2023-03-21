using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Bresenham : MonoBehaviour
{
    private int Dy;
    private int Dx;

    public void algoritmo(int x0, int y0, int x1, int y1, List<List<GameObject>> MatrixScreen, Material materialOn)
    {
            Dx = Mathf.Abs(x1 - x0);
            Dy = Mathf.Abs(y1 - y0);

            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;

            int err = Dx - Dy;
            int e2;

            while (true)
            {
                MatrixScreen[x0][y0].GetComponent<PixelScript>().Switch(materialOn, true);
                if (x0 == x1 && y0 == y1) break;
                e2 = 2 * err;
                if (e2 > -Dy)
                {
                    err = err - Dy;
                    x0 = x0 + sx;
                }

                if (e2 < Dx)
                {
                    err = err + Dx;
                    y0 = y0 + sy;
                }
            }
    }
}