using UnityEngine;
using System.Collections;

public class Rotating : MonoBehaviour {
    public float RotateSpeed;
    public bool IsRotating = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (IsRotating)
        {
            transform.Rotate(Vector3.up, RotateSpeed);
        }
	}
}
