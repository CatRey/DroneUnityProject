using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPrefab : MonoBehaviour
{
    public Vector3 target;// ���� ���� (����� ���������)
    public int type; //��� ������ ������ (�������� 0 - ������)
    private void Awake()
    {
        target = transform.position;
    }

}
