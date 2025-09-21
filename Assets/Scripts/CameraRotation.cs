using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotSpeed = 1f; //�������� ��������
    public float distance = 7f; //���������� �� �������
    public float scaleSpeed = 1f;//�������� �������
    private Camera m_Camera;
    private int nowView = 60; //��� �������
    private void Start()
    {
        m_Camera = GetComponent<Camera>();
    }
    void Update()
    {
        //���� ������ ������
        if (Input.GetMouseButton(0))
        {
            //��������
            float horizontInput = Input.GetAxis("Mouse X") * rotSpeed; //��������� ��������
            transform.RotateAround(new Vector3(0, 0, 0), Vector3.up,horizontInput);//��������
            transform.position = new Vector3(0, 5.4f, 0) - Vector3.forward * distance; //�������
        }
        //������
        float vertInput = Input.GetAxis("Mouse ScrollWheel") * scaleSpeed;
        nowView += (int)(vertInput); // ���� ������ View
        nowView = Mathf.Min(Mathf.Max(nowView, 30), 80); //�����������
        m_Camera.fieldOfView = nowView;

    }
}
