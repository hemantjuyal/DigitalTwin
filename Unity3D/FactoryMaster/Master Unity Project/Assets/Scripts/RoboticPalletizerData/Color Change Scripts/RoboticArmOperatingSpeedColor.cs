using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboticArmOperatingSpeedColor : MonoBehaviour
{
   public RoboticPalletizerScriptableObject roboticPalletizerScriptableObject;
    Renderer ren;
    private Color mycolor;
    // Start is called before the first frame update
    void Start()
    {
        ren=gameObject.GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
       if(roboticPalletizerScriptableObject.roboticPalletizerData.RoboticArmOperatingSpeed > 0 && roboticPalletizerScriptableObject.roboticPalletizerData.RoboticArmOperatingSpeed<=20){
        mycolor= new Color(1,0.64,0,1);
        ren.material.color=mycolor;
       }

       else if(roboticPalletizerScriptableObject.roboticPalletizerData.RoboticArmOperatingSpeed > 20 && roboticPalletizerScriptableObject.roboticPalletizerData.RoboticArmOperatingSpeed<=40){
        mycolor= new Color(0,1,0,1);
        ren.material.color=mycolor;
       }

       else{
        mycolor= new Color(1,0,0,1);
        ren.material.color=mycolor;
       } 
    }
}
