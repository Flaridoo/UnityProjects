using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject m_charater;
    public GameObject m_plane;
    public GameObject m_contral_panel;
    public GameObject m_cube_parent;
    public GameObject m_cube;

    private Vector3 offset = new Vector3(0, 5, 4);//相机相对于玩家的位置
    private Vector3 pos;
    public float speed = 2;

    public static Manager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        m_charater.SetActive(true);
        m_plane.SetActive(true);
    }   
    
    // Update is called once per frame
    void Update()
    {
        pos = m_charater.transform.position + offset;
        this.transform.position = Vector3.Lerp(this.transform.position, pos, speed * Time.deltaTime);//调整相机与玩家之间的距离
        Quaternion angel = Quaternion.LookRotation(m_charater.transform.position - this.transform.position);//获取旋转角度
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, angel, speed * Time.deltaTime);
        

    }


    public void ShowContralPanel()
    {
        m_contral_panel.SetActive(!m_contral_panel.activeSelf);
    }
    public void NewCube()
    {
        GameObject newcube = Instantiate(m_cube);
        newcube.transform.parent = m_cube_parent.transform;
        newcube.transform.localScale = Vector3.one;
        newcube.transform.localPosition = new Vector3(0, 2, 0);
    }
}
