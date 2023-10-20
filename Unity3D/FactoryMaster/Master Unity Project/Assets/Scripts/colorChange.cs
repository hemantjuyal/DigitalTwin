using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChange : MonoBehaviour
{
    Renderer ren;
    public int weight = 10;
    public Color mycolor;
    
    // Start is called before the first frame update
    void Start()
    {
        ren=gameObject.GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (weight > 10 && weight<30)
        {
            mycolor = new Color(0, 1, 0, 1);
            ren.material.color = mycolor;
        }

        else if (weight > 30)
        {
            mycolor = new Color(1,0,0,1);
            ren.material.color = mycolor;
        }
    }
}
