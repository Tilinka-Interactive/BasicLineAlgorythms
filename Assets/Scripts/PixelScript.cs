using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelScript : MonoBehaviour
{
    [SerializeField] private MeshRenderer LedMesh;
    [SerializeField] private float time;
    
    private bool isOn;
    private int id;
    private int x;
    private int y;
    
    void Start()
    {
        isOn = false;       
    }

    public void Switch(Material material, bool isOn) {
        this.isOn = isOn;
        LedMesh.material = material;
    }

    public void SetCoordinates(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public string OnClickPixel() {
        return x.ToString() + "," + y.ToString();
    }

    public int GetX()
    {
        return x;            
    }

    public int GetY()
    {
        return y;
    }
}
