using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Building : MonoBehaviour
{
    private Camera m_Camera;
    private BuildingPrefab nowPrefab; //��� ������ ��� ����������
    private Vector3 pointPlace = Vector3.zero; //����� ��� ���������� ���������� (��� ������ � ����� Y!=0)
    private Material cashMaterial; //�������� ������� (������� UI)
    private Vector3 target; //������ ������� �������
    public BuildingPrefab[] myBP; //��� ����������
    private List<BuildingPrefab>[] parts = new List<BuildingPrefab>[4]; //�������
    private int[] counts = { 0, 0, 0, 0 };//�������
    private int nowType = -1;//��� type
    private List<BuildingPrefab> placedPrefabs = new List<BuildingPrefab>();
    public GameController gameController; // ���������� ����
    void Start()
    {
        m_Camera = Camera.main; //���� ������
        // �������������� ������ ������� ������� �������
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i] = new List<BuildingPrefab>();
        }
        //��������� � List
        parts[0].Add(myBP[0]);
        for(int i = 1; i < 4; i++)
        {
            for (int j = 0; j < 4; j++) parts[i].Add(myBP[(i-1)*4+j+1]);
        }
    }
    
    public void StartPlacing(int type) //������ �������������
    {
        
        //���� ������ ���������� - �������
        if (nowPrefab != null)
        {
            Destroy(nowPrefab.gameObject);

        }
        //������� 
        nowPrefab = Instantiate(parts[type][counts[type]]);
        target = nowPrefab.target;
        pointPlace.y = target.y;
        nowType = type;
        cashMaterial = new Material( nowPrefab.GetComponent<Renderer>().material);
        
    }
    private void Update()
    {
        //���� ������ ������ - ���������� �� ������
        if (nowPrefab != null)
        {
            var ground = new Plane(Vector3.up,pointPlace);//������� ���������
            Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition); 
            if(ground.Raycast(ray, out float position))
            {
                Vector3 nowPosition = ray.GetPoint(position); //���� �������
                nowPrefab.transform.position = nowPosition; //������ ��� �������
                bool inPlace = true; // ��������� �� �����������
                if(Mathf.Abs(nowPosition.x-target.x)>0.15f && Mathf.Abs(nowPosition.z - target.z) > 0.15f)
                {
                    inPlace = false; //���� �� ����� � ������� ������ - ���������
                }
                //������, ���� ����������� ���������� �������, ����� ���
                if (inPlace)
                {
                    nowPrefab.GetComponent<Renderer>().material = cashMaterial;

                }
                else
                {
                    nowPrefab.GetComponent<Renderer>().material.color = Color.red;
                }
                //���� ����� ������ - ������
                if (Input.GetMouseButtonDown(0) && inPlace)
                {
                    placedPrefabs.Add(nowPrefab);
                    gameObject.GetComponent<AudioSource>().Play();//�������� �����
                    //����������� �������; ��null�����
                    counts[nowType]++;
                    nowType = -1;
                    nowPrefab.transform.position = target;
                    nowPrefab = null;
                    cashMaterial = null;

                }
            }
        }
        if (counts[0] + counts[1] + counts[2] + counts[3] >= 13)
        {//���������� ��� ������� - �������, �������� EndFunc
            gameController.GetComponent<GameController>().Game2End();
            foreach (BuildingPrefab i in placedPrefabs)
            {
                Destroy(i.gameObject);
            }
            
        }
    }
}
