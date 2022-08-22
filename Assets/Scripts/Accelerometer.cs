using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using extOSC;

public class Accelerometer : MonoBehaviour
{
  
    public OSCTransmitter _transmitter;


    void Awake()
    {
        if(!Input.gyro.enabled)
        {
            Input.gyro.enabled = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
      //  transform.rotation = Input.gyro.attitude;
        GameObject roll_text = GameObject.FindWithTag("roll");
        GameObject pitch_text = GameObject.FindWithTag("pitch");
        GameObject yaw_text = GameObject.FindWithTag("yaw");
       
        roll_text.GetComponent<TMPro.TextMeshProUGUI>().text = Input.gyro.attitude.x.ToString("#.00");
        pitch_text.GetComponent<TMPro.TextMeshProUGUI>().text = Input.gyro.attitude.y.ToString("#.00");
        yaw_text.GetComponent<TMPro.TextMeshProUGUI>().text = Input.gyro.attitude.z.ToString("#.00");
        

        OSCMessage message = new OSCMessage("/pos/");
		message.AddValue(OSCValue.Float(Input.gyro.attitude.x));
        message.AddValue(OSCValue.Float(Input.gyro.attitude.y));
        message.AddValue(OSCValue.Float(Input.gyro.attitude.z));
        message.AddValue(OSCValue.Float(Input.gyro.attitude.w));

		_transmitter.Send(message);

    }

}
