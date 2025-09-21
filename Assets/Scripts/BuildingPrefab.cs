using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPrefab : MonoBehaviour
{
    public Vector3 target;// Наша цель (место установки)
    public int type; //Тип нашего объект (например 0 - корпус)
    private void Awake()
    {
        target = transform.position;
    }

}
