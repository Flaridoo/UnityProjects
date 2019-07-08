using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            transform.localPosition +=new Vector3(0, 0.1f,0);
        }
        
        if(transform.parent && transform.parent.name == "Charater")
        {
            if(transform.localPosition.y < 1.4)
            {
                transform.parent = Manager.instance.m_cube_parent.transform;
            }
        }
    }

    
}
