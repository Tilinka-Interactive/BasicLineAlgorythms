using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBresenhamScript : MonoBehaviour
{
    private int x, y, e;
    private void Circle(int radio)
    {
        x = radio;
        y = 0;
        e = 0;
        while (y <= x)
        {
            PutPixel(x, y);
            PutPixel(y, x);
            PutPixel(-x, y);
            PutPixel(-y, x);
            PutPixel(x, -y);
            PutPixel(y, -x);
            PutPixel(-x, -y);
            PutPixel(-y, -x);
            e = e + 2 * y + 1;
            y = y + 1;
            if (2 * e > (2 * x - 1))
            {
                x = x - 1;
                e = e - 2 * x + 1;
            }
        }
    }

    public void PutPixel(int x, int y)
    {

    }
}
