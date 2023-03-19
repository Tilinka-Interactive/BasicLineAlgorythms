using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PseudoCineMachine : MonoBehaviour
{
    [SerializeField] private GameObject Camera;
    [SerializeField] private Transform[] positions;
    private int pos;

    public void MoveCamera(Transform position) {
        LeanTween.move(Camera, position.position, 1f).setEaseLinear();
    }
    public void MoreRes() {
        if (pos + 1 < positions.Length)
        {
            Camera.transform.position = positions[pos + 1].position;
            pos++;
        } 
    }
    public void LessRes()
    {
        if (pos + 1 < positions.Length)
        {
            Camera.transform.position = positions[pos + 1].position;
            pos++;
        }
    }
}
