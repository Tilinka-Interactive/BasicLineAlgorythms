using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bresenham : MonoBehaviour
{
    [SerializeField] private Material pixelOff;
    [SerializeField] private Material pixelOn;
    // Start is called before the first frame update
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
        matrixScreen[0] = matrix1;
        matrixScreen[1] = matrix2;
        matrixScreen[2] = matrix3;
        matrixScreen[3] = matrix4;
        matrixScreen[4] = matrix5;
        matrixScreen[5] = matrix6;
        matrixScreen[6] = matrix7;
        matrixScreen[7] = matrix8;
        matrixScreen[8] = matrix9;
        matrixScreen[9] = matrix10;
        matrixScreen[10] = matrix11;
        matrixScreen[11] = matrix12;
        matrixScreen[12] = matrix13;
        matrixScreen[13] = matrix14;
        matrixScreen[14] = matrix15;
        matrixScreen[15] = matrix16;
        matrixScreen[16] = matrix17;
        matrixScreen[17] = matrix18;
        matrixScreen[18] = matrix19;
        matrixScreen[19] = matrix20;
        matrixScreen[20] = matrix21;
        DrawFirstPoint();


    }

    public void DrawFirstPoint()
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
        InvokeRepeating("DrawAPoint", 0, 0.2f);
    }

    public void DrawAPoint2()
    {
        if (xa < 21)
        {
            if (ya < 21)
            {
                changeMatInst(matrixScreen[xa][ya]);
                ya++;
                k++;
                Debug.Log(xa);
            }
            else
            {
                xa++;
                ya = 0;
            }

        }
    }
    public void DrawAPoint()
    {
        if (p0 < 0)
        {
            //Debug.Log("<1point at: " + (int)(x0 + k + 1) + " " + (int)(y0 + k));
            changeMatInst(matrixScreen[x0 + k][y0 + k + 1]);
            p0 = p0 + (2 * Dy);
        }
        else
        {
            //Debug.Log(">1point at: " + (int)(x0 + k + 1) + " " + (int)(y0 + k + 1));
            changeMatInst(matrixScreen[x0 + k + 1][y0 + k + 1]);
            p0 = p0 + ((2 * Dy) - (2 * Dx));
        }
        k = k + 1;
    }

    private void changeMatInst(GameObject pixel)
    {
        pixel.GetComponent<MeshRenderer>().material = pixelOn;
    }

    public void ClearScreen()
    {
        for (int i = 0; i < matrixScreen.Length; i++)
        {
            for (int j = 0; j < matrixScreen[0].Length; j++)
            {
                changeMatInst(matrixScreen[i][j]);
            }
        }
    }
    private void Update()
    {
        if (x0 + k > 14) CancelInvoke("DrawAPoint");
    }
}