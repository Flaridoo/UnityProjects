using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drections : MonoBehaviour
{
    public GameObject m_charater;
    public Vector3 m_init_pos;
    public float m_radius;
    public float m_rate_speed;

    private bool isStart = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Init pos : " + transform.localPosition);
    }

    private void Update()
    {
        if (!isStart)
        {
            return;
        }

        Vector3 dir = Input.mousePosition - new Vector3(150, 150, 0) - m_init_pos;
        if (Vector2.Distance(Input.mousePosition - new Vector3(150, 150, 0), m_init_pos) < m_radius)
        {
            transform.localPosition = Input.mousePosition - new Vector3(150, 150, 0);
        }
        else
        {
            transform.localPosition = m_init_pos + dir.normalized * m_radius * 1.1f;
        }
        
        float angle = Vector3.Angle(new Vector3(dir.x, 0, dir.y), Vector3.right);
        print("角度B：" + angle);


        Vector3 targetDir = target.position - transform.position;
        Vector3 playerForward = target.rotation * transform.forward;
        float angle = Mathf.Acos(Vector3.Dot(playerForward.normalized, targetDir.normalized)) * Mathf.Rad2Deg;
        print("角度C：" + angle);

        m_charater.transform.localPosition += m_charater.transform.forward * dir.magnitude * m_rate_speed;
        m_charater.transform.localEulerAngles = new Vector3(0, angle, 0);

        Debug.Log(dir.normalized);
    }

    public void DragStart()
    {
        isStart = true;
    }

    public void DragEnd()
    {
        isStart = false;
        transform.localPosition = m_init_pos;
    }
}
