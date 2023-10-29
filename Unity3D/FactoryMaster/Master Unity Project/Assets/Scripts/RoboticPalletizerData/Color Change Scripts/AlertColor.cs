using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertColor : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
       if(roboticPalletizerScriptableObject.roboticPalletizerMetaData.Alert == true){
        mycolor= new Color(1,0,0,1);
        ren.material.color= mycolor;
       }

       else{
        ren.material.color=orgcolor;
       }
    }
}
