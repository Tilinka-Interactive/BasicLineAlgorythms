using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelScript : MonoBehaviour
{
    [SerializeField] private MeshRenderer LedMesh;
    [SerializeField] private float time;
    private Material isOnMat;
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
        isOnMat = material;
        LedMesh.material = material;
    }
    public void SetCoordinates(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public void OnEnterPixel() {
        GameEvents.Current.MouseOnPixel(x.ToString() + "," + y.ToString());
        LedMesh.material.SetColor("_Color", Color.red);
        LedMesh.material.SetColor("_EmissionColor", new Vector4(255f, 0f, 0) * 1.0f);
        
    }
    public void OnExitPixel()
    {
        GameEvents.Current.MouseOnPixel("");
        if (isOn) LedMesh.material = isOnMat;
        else {
            LedMesh.material.SetColor("_Color", Color.white);
            LedMesh.material.SetColor("_EmissionColor", Color.white);
        }
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
