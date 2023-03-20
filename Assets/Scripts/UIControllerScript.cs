using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIControllerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coordinatesText;

    private void Start()
    {
        GameEvents.Current.OnPixel += ShowCoordinates;
    }
    private void ShowCoordinates(string text) {
        coordinatesText.text = text;    
    }
}
