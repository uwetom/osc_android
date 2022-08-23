using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    
    private Quaternion previousRotation;
    private List<float> previousAngleDifferences; 

    public Material stationaryMaterial;
    public Material movingMaterial;
    public GameObject rotatingObject;
    
  
    // Start is called before the first frame update
    void Start()
    {
       
       Debug.Log("hello");

        previousRotation = new Quaternion(0.0f,0.0f,0.0f,0.0f);
        previousAngleDifferences = new List<float>();
    }

    public void Rotate(Quaternion newRotation){

        transform.localRotation = newRotation;

        float angle = Quaternion.Angle(previousRotation, newRotation);

        
        
        previousAngleDifferences.Add(angle);
        
        if(previousAngleDifferences.Count >= 30){
			previousAngleDifferences.RemoveAt(0);
		}

        previousRotation = newRotation;



        float total = 0;

		for(int i = 0; i< previousAngleDifferences.Count; i++){
			total += previousAngleDifferences[i];
		}

		float average = total/previousAngleDifferences.Count;
        

       // Debug.Log(average);

        if(average <= 0.1f){
            rotatingObject.GetComponent<Renderer>().material = stationaryMaterial;
        }else{
            rotatingObject.GetComponent<Renderer>().material = movingMaterial;
        }




    }

   



}
