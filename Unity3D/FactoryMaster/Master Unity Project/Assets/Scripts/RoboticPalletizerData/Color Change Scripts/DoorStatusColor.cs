using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStatusColor : MonoBehaviour
{
   public RoboticPalletizerScriptableObject roboticPalletizerScriptableObject;
    Renderer ren;
    private Color mycolor;
    private Color orgcolor;
 void Start()
    {
        ren=gameObject.GetComponent<Renderer>();
        orgcolor=ren.material.color;
    }
    void Update()
    {
        if(roboticPalletizerScriptableObject.roboticPalletizerData.DoorStatus == true){
        mycolor= new Color(1,0,0,1);
        ren.material.color= mycolor;
       }

       else{
        ren.material.color=orgcolor;
       }
    }
}
