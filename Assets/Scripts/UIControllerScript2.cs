using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIControllerScript2 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coordinatesText;
    [SerializeField] private UniversalRenderMatrix2 matrixRenderer;
    private int x0, y0, x1, y1;

    private void Start()
    {
        GameEvents.Current.OnPixel += ShowCoordinates;
    }
    private void ShowCoordinates(string text) {
        coordinatesText.text = text;    
    }

    public void SetInputX0(string inputX0) {
        x0 = int.Parse(inputX0);
        //Debug.Log("x0: "+ inputX0);  
    }
    public void SetInputY0(string inputY0)
    {
        y0 = int.Parse(inputY0);
        //Debug.Log("y0: "+ inputY0);
    }
    public void SetInputX1(string inputX1)
    {
        x1 = int.Parse(inputX1);
        //Debug.Log("x1: "+ inputX1);
    }
    public void SetInputY1(string inputY1)
    {
        y1 = int.Parse(inputY1);
        //Debug.Log("y1: " +inputY1);
    }

    public void DrawLine() {
        matrixRenderer.BasicAlgorythmEx(x0, y0, x1, y1);
    }
}
