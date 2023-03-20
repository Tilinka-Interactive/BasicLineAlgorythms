using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AlgoritmoBasico : MonoBehaviour
{
    private Material materialOn;
    public void algortimo(int x0, int y0, int x1, int y1, List<List<GameObject>> MatrixScreen, Material materialOn)
    {
        this.materialOn = materialOn;
        // Calcular la pendiente
        float m = (float)(y1 - y0) / (float)(x1 - x0);

        // Calcular el punto de corte
        float b = y0 - m * x0;

        // Calcular el ancho y la altura del área de dibujo
        int ancho = Mathf.Abs(x1 - x0);
        int altura = Mathf.Abs(y1 - y0);

        //int[][] matriz = new int[ancho][altura];
        int[][] matriz = new int[ancho][];

        // Iterarción
        for (int x = x0; x <= x1; x++)
        {
            // Calcular el valor correspondiente de y utilizando la ecuación:
            float y = m * x + b;
            // Calculamos las coordenadas
            int redondeoY = (int)Mathf.Round(y);
            int matrixX = x - x0;
            int matrixY = redondeoY - y0;
            // se dibuja el pixel en la matriz
            MatrixScreen[matrixX][matrixY].GetComponent<PixelScript>().Switch(materialOn, true);
            /*
            if (matrixX >= 0 && matrixX < ancho && matrixY >= 0 && matrixY < altura)
            {
                matriz[matrixX][matrixY] = 1;
            }
            */
        }

        /*para imprimir
        for (int y = altura - 1; y >= 0; y--)
        {
            for (int x = 0; x < matriz.Length; x++)
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
