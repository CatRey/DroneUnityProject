using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone_End : MonoBehaviour
{
    public GameObject[] vints;//�����
    public float RotSpeed = 1.0f;
    private void Start()
    {
        gameObject.GetComponent<AudioSource>().loop = true;
        gameObject.GetComponent<AudioSource>().Play();//�������� ����������� ���� ����� 
    }
    private void Update()
    {
        //���������� �����
        foreach (GameObject i in vints)
        {
            i.transform.Rotate(new Vector3(0,0,RotSpeed));
        }
    }
}
