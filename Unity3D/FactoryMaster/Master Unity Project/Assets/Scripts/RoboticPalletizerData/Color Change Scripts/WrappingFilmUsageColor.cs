using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrappingFilmUsageColor : MonoBehaviour
{
     public RoboticPalletizerScriptableObject roboticPalletizerScriptableObject;
    Renderer ren;
    private Color mycolor;
 void Start()
    {
        ren=gameObject.GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
       if(roboticPalletizerScriptableObject.roboticPalletizerData.PalletStretchMachineWrappingFilmUsage > 0 && roboticPalletizerScriptableObject.roboticPalletizerData.PalletStretchMachineWrappingFilmUsage<=3.9){
        mycolor= new Color(1,0.64,0,1);
        ren.material.color=mycolor;
       }

       else if(roboticPalletizerScriptableObject.roboticPalletizerData.PalletStretchMachineWrappingFilmUsage > 3.9 && roboticPalletizerScriptableObject.roboticPalletizerData.PalletStretchMachineWrappingFilmUsage<=4.5){
        mycolor= new Color(0,1,0,1);
        ren.material.color=mycolor;
       }

       else{
        mycolor= new Color(1,0,0,1);
        ren.material.color=mycolor;
       } 
    }
}
