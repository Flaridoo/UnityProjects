using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterMove : MonoBehaviour
{
    public GameObject m_cube_parent;
    public float m_back_time;

    public GameObject m_mouth;
    private int m_mouth_move;
    private GameObject m_temp_cube;

    public Vector3 m_jump_distance;
    public float m_jump_time;
    public Vector3 m_position;
    private bool is_jump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.localEulerAngles += new Vector3(0, 1f, 0);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localEulerAngles -= new Vector3(0, 1f, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.localPosition += transform.forward * 0.1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.localPosition -= transform.forward * 0.1f;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_position = transform.localPosition + m_jump_distance;
            is_jump = true;
        }

        if(is_jump)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, m_position, m_jump_time);
            if(Mathf.Abs( m_position.x - transform.localPosition.x )< 0.01f)
            {
                is_jump = false;
            }
        }

        if(m_mouth_move == 1)
        {
            BackCubeGo();
        }
    }

    void OnCollisionEnter(Collision co)
    {
        Debug.Log(co.gameObject.name);

        if(co.gameObject.tag == "cube" && co.gameObject.GetComponent<MeshRenderer>())
        {
            if(m_temp_cube != null)
            {
                m_temp_cube.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            m_temp_cube = co.gameObject;
            co.gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
        }
        
    }
    

    void BackCubeGo()
    {
        m_temp_cube.transform.localPosition = Vector3.Lerp(m_temp_cube.transform.localPosition, new Vector3(0, 2.5f, 0), m_back_time);

        float distance = Vector3.Distance(m_temp_cube.transform.localPosition, new Vector3(0, 2.5f, 0));
        if(distance < 0.1f)
        {
            m_mouth_move = 0;
        }
    }

    public void BackOn()
    {
        if(m_temp_cube)
        {
            float distance = Vector3.Distance(m_temp_cube.transform.position, transform.position);
            Transform tran = transform.Find("Cube(Clone)");
            if (!tran)
            {
                if (distance < 1.5f)
                {
                    m_temp_cube.transform.parent = transform;

                    //m_mouth_move = 1;
                    m_temp_cube.transform.localPosition = new Vector3(0, 2.5f, 0);
                }
                else
                {
                    Debug.Log("Distance is too far: " + distance);
                }
            }
            else if (tran.localPosition.y < 1.4f)
            {
                tran.parent = m_cube_parent.transform;
            }
            else
            {
                Debug.Log("Charater already has cube!");

            }
        }
    }

    public void BackDown()
    {
        if(m_temp_cube)
        {
            Transform tran = transform.Find("Cube(Clone)");
            if (tran)
            {
                tran.localPosition += new Vector3(0, 0, -1.2f);
            }
            else
            {
                Debug.Log("tran is null");
            }
        }
    }
}
