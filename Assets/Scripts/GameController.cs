using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //������ ������� ���
    public static GameController instance;
    private void Awake()
    {
        if(instance == null) instance = this;
        else Destroy(instance);
    }
    public GameObject[] startObjects; //������� ��� ������ ������
    public GameObject[] gameObjects; //��� ����
    public GameObject[] endObjects; //��� ���������
    private void Start()
    {
        //���������� ���������
        foreach (GameObject i in gameObjects)
        {
            i.SetActive(false);
        }
        foreach (GameObject i in endObjects)
        {
            i.SetActive(false);
        }
        foreach (GameObject i in startObjects)
        {
            i.SetActive(true);
        }
        
    }
    public void Start2Game() //������� � �������� ����
    {
        //��������� ������ start
        foreach (GameObject i in startObjects)
        {
            i.SetActive(false);
        }
        //�������� game
        foreach(GameObject i in gameObjects)
        {
            i.SetActive(true);
        }
    }
    public void Game2End() //������� � ��������� ���������
    {
        //����������
        foreach (GameObject i in gameObjects)
        {
            i.SetActive(false);
        }
        foreach (GameObject i in endObjects)
        {
            i.SetActive(true);
        }
    }
}
