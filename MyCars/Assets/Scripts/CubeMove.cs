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
        
        if(transform.parent && transform.parent.name == "Charater")
        {
            float distance = Vector2.Distance(transform.localPosition, transform.parent.localPosition);
            if (transform.localPosition.y < 1.4 && distance > 0.8f)
            {
                transform.parent = Manager.instance.m_cube_parent.transform;
            }
        }
    }

    
}
