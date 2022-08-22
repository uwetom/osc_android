using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RotationAdjustment : MonoBehaviour
{
   
   public Slider slider;
   public GameObject canvas;
   private bool UIVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Mouse0)){

            //show ui
            canvas.SetActive(true);

            UIVisible = true;

        }


        if(UIVisible){
            transform.rotation = Quaternion.Euler(0.0f,slider.value, 0.0f);
        }

    }

    public void CloseCanvas(){
        //show ui
            canvas.SetActive(false);

            UIVisible = false;

    }
}
