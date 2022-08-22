using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Rotate(Quaternion newRotation){

       // Quaternion current = Quaternion(yRotVal,zRotVal,xRotVal);

        transform.rotation = newRotation;

    }
}
