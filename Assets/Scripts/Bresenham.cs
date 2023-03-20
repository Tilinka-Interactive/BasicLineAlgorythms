using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bresenham : MonoBehaviour
{
    [SerializeField] private Material pixelOff;
    [SerializeField] private Material pixelOn;
    /*
    [SerializeField] private GameObject[][] matrixScreen = new GameObject[21][];
    [SerializeField] private GameObject[] matrix1 = new GameObject[21];
    [SerializeField] private GameObject[] matrix2 = new GameObject[21];
    [SerializeField] private GameObject[] matrix3 = new GameObject[21];
    [SerializeField] private GameObject[] matrix4 = new GameObject[21];
    [SerializeField] private GameObject[] matrix5 = new GameObject[21];
    [SerializeField] private GameObject[] matrix6 = new GameObject[21];
    [SerializeField] private GameObject[] matrix7 = new GameObject[21];
    [SerializeField] private GameObject[] matrix8 = new GameObject[21];
    [SerializeField] private GameObject[] matrix9 = new GameObject[21];
    [SerializeField] private GameObject[] matrix10 = new GameObject[21];
    [SerializeField] private GameObject[] matrix11 = new GameObject[21];
    [SerializeField] private GameObject[] matrix12 = new GameObject[21];
    [SerializeField] private GameObject[] matrix13 = new GameObject[21];
    [SerializeField] private GameObject[] matrix14 = new GameObject[21];
    [SerializeField] private GameObject[] matrix15 = new GameObject[21];
    [SerializeField] private GameObject[] matrix16 = new GameObject[21];
    [SerializeField] private GameObject[] matrix17 = new GameObject[21];
    [SerializeField] private GameObject[] matrix18 = new GameObject[21];
    [SerializeField] private GameObject[] matrix19 = new GameObject[21];
    [SerializeField] private GameObject[] matrix20 = new GameObject[21];
    [SerializeField] private GameObject[] matrix21 = new GameObject[21];
    */
    private int k = 0;
    private int y0 = 7;
    private int x0 = 1;
    private int y1 = 5;
    private int x1 = 20;
    private int Dy;
    private int Dx;
    private int D2y;
    private int p0;


    int xa = 0;
    int ya = 0;
    void Start()
    {
        //DrawFirstPoint();
    }

    public void DrawFirstPoint(List<List<GameObject>>matrixScreen)
    {
        //algortimo(y0, x0, y1, x1);
        changeMatInst(matrixScreen[y0][x0]);
        Dy = Mathf.Abs(y1 - y0);
        Debug.Log(Dy);
        Dx = Mathf.Abs(x1 - x0);
        Debug.Log(Dx);
        p0 = (2 * Dy) - Dx;
        Debug.Log(p0);
        k = 0;
        for (int i = 0; i < Dx; i++) {
            if (p0 < 0)
            {
                changeMatInst(matrixScreen[x0 + k][y0 + k + 1]);
                p0 = p0 + (2 * Dy);
            }
            else
            {
                changeMatInst(matrixScreen[x0 + k + 1][y0 + k + 1]);
                p0 = p0 + ((2 * Dy) - (2 * Dx));
            }
            k = k + 1;

        }
    }

}