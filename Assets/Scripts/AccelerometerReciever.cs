using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;

public class AccelerometerReciever : MonoBehaviour
{
    public OSCReceiver _receiver;
    public GameObject rotationObject;
    public float xRotVal = 0;
    public float yRotVal = 0;
    public float zRotVal = 0;
    public float wRotVal = 0;

    void Start()
    {
        _receiver.Bind("/pos/", MessageReceived);   
    }

    protected void MessageReceived(OSCMessage message)
    {
        xRotVal = message.Values[0].FloatValue;
        yRotVal = message.Values[1].FloatValue;
        zRotVal = message.Values[2].FloatValue;
        wRotVal = message.Values[3].FloatValue;

        Quaternion newRotation = new Quaternion(-xRotVal,-zRotVal,-yRotVal,wRotVal);


       rotationObject.GetComponent<RotateObject>().transform.localRotation= newRotation;
       
    }

}
