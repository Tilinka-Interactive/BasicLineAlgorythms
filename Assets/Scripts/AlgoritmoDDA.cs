using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgoritmoDDA : MonoBehaviour
{
    public void algoritmo(int x0, int y0, int x1, int y1, List<List<GameObject>> MatrixScreen, Material materialOn)
    {
        int dx = x1 - x0;
        int dy = y1 - y0;
        //int[][] matriz = new int[Mathf.Abs(dx)][Mathf.Abs(dy)];
        float m = 0f;
        if (dx != 0)
        {
            m = (float)dy / (float)dx;
        }


        if (Mathf.Abs(dx) > Mathf.Abs(dy))
        {
            float b = y0 - m * x0; // punto de corte
            int incX = dx > 0 ? 1 : -1;
            for (int x = x0; x != x1; x += incX)
            {
                int y = (int)Mathf.Round(m * x + b);
                int matrizX = x - x0;
                int matrizY = y - y0;
                // dibuja el pixel en la matriz
                if (matrizX >= 0 && matrizX < Mathf.Abs(dx) && matrizY >= 0 && matrizY < Mathf.Abs(dy))
                {
                    MatrixScreen[matrizX][matrizY].GetComponent<PixelScript>().Switch(materialOn, true);
                }
            }
        }
        else
        {
            if (dy != 0)
            {
                float b = x0 - m * y0; // punto de corte
                int incY = dy > 0 ? 1 : -1;
                for (int y = y0; y != y1; y += incY)
                {
                    int x = (int)Mathf.Round(m * y + b);
                    int matrizX = x - x0;
                    int matrizY = y - y0;
                    // dibuja el pixel en la matriz
                    if (matrizX >= 0 && matrizX < Mathf.Abs(dx) && matrizY >= 0 && matrizY < Mathf.Abs(dy))
                    {
                        MatrixScreen[matrizX][matrizY].GetComponent<PixelScript>().Switch(materialOn, true);
                    }
                }
            }
        }

        /* para imprimir
        for (int y = Mathf.Abs(dy) - 1; y >= 0; y--)
        {
            for (int x = 0; x < Mathf.Abs(dx); x++)
            {
                if (matriz[x][y] == 1)
                {
                    //System.out.print("X ");
                }
                else
                {
                    //System.out.print(". ");
                }
            }
            //System.out.println();
        }
        */
    }
}
