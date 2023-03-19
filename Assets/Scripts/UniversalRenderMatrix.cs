using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class UniversalRenderMatrix : MonoBehaviour
{
    [SerializeField] List<List<GameObject>> MatrixScreen = new();
    [SerializeField] GameObject PixelPrefab;
    [SerializeField] GameObject PixelPrefab2;
    [SerializeField] Material IsOnMaterial;
    //[SerializeField] private float tweenTime;
    [SerializeField] Material ledMaterial;
    [SerializeField] private Color beginColor, endColor;
    [SerializeField] private PseudoCineMachine cam;
    private int x = 0;
    private int y = 0;

    private int auxX = 0;
    private int auxY = 0;
    void Start()
    {
        Application.targetFrameRate = 60;
        GenerateMatrix(30);
        InvokeRepeating("ChangeMaterialTest", 0, 0.01f);
        //Tween(); //Color change test
    }

    public void GenerateMatrix(int n) {
        ClearMatrixScreen();
        for (int i = 0; i < n; i++)
        {
            MatrixScreen.Add(new List<GameObject>());
            for (int j = 0; j < n; j++)
            {
                MatrixScreen[i].Add(Instantiate(PixelPrefab, new Vector3(x, y, 0), Quaternion.Euler(0, -90, 90)));
                MatrixScreen[i][j].GetComponent<PixelScript>().SetCoordinates(i, j);
                x++;
            }
            y--;
            x = 0;
        }   
    }

    public void ClearMatrixScreen() {
        for (int i = 0; i < MatrixScreen.Count; i++) {
            foreach (GameObject pixel in MatrixScreen[i]) {
                Destroy(pixel);
            }
        }
        MatrixScreen.Clear();
        CancelInvoke("ChangeMaterialTest");
        auxX = 0;
        auxY = 0;
        x = 0;
        y = 0;
    }


    private void ChangeMaterialTest() {
        if (auxX < MatrixScreen.Count)
        {
            if (auxY < MatrixScreen[0].Count)
            {
                MatrixScreen[auxX][auxY].GetComponent<PixelScript>().Switch(IsOnMaterial, true);
                auxY++;
            }
            else
            {
                auxY = 0;
                auxX++;
            }
        }
        else CancelInvoke("ChangeMaterial");
    }

    public void AddResolution() {
        //cam.MoveCamera(-0.2f);
        int x = MatrixScreen.Count;
        int y = 0;
        MatrixScreen.Add(new List<GameObject>());
        for (int i = 0; i < MatrixScreen.Count - 1; i++) {
            MatrixScreen[i].Add(Instantiate(PixelPrefab, new Vector3(x, y, 0), Quaternion.Euler(0, -90, 90)));
            y--;
            MatrixScreen[MatrixScreen.Count - 1].Add(Instantiate(PixelPrefab, new Vector3(i, (MatrixScreen.Count - 1) * -1, 0), Quaternion.Euler(0, -90, 90)));
        }
        MatrixScreen[MatrixScreen.Count - 1].Add(Instantiate(PixelPrefab, new Vector3(MatrixScreen.Count - 1, (MatrixScreen.Count - 1) * -1, 0), Quaternion.Euler(0, -90, 90)));
    }

    public void ReduceResolution()
    {
        //cam.MoveCamera(0.2f);
        int res = MatrixScreen.Count - 1;
        for (int i = 0; i < MatrixScreen.Count - 1; i++)
        {
            Destroy(MatrixScreen[i][res]);
            Destroy(MatrixScreen[res][i]);
            MatrixScreen[i].RemoveAt(res);
        }
        Destroy(MatrixScreen[res][res]);
        MatrixScreen.RemoveAt(MatrixScreen.Count -1);
    }

    public void Tween()
    {
        LeanTween.value(gameObject, 0.1f, 1, 2)
            .setLoopPingPong()
            .setOnUpdate((value) =>
            {
                ledMaterial.color = Color.Lerp(beginColor, endColor, value);
            });
    }
}