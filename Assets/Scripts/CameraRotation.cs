using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotSpeed = 1f; //Скорость вращения
    public float distance = 7f; //Расстояние до объекта
    public float scaleSpeed = 1f;//Скорость маштаба
    private Camera m_Camera;
    private int nowView = 60; //Для маштаба
    private void Start()
    {
        m_Camera = GetComponent<Camera>();
    }
    void Update()
    {
        //Если кнопка зажата
        if (Input.GetMouseButton(0))
        {
            //Вращение
            float horizontInput = Input.GetAxis("Mouse X") * rotSpeed; //Получение вращения
            transform.RotateAround(new Vector3(0, 0, 0), Vector3.up,horizontInput);//Вращение
            transform.position = new Vector3(0, 5.4f, 0) - Vector3.forward * distance; //Позиция
        }
        //Маштаб
        float vertInput = Input.GetAxis("Mouse ScrollWheel") * scaleSpeed;
        nowView += (int)(vertInput); // Счет нашего View
        nowView = Mathf.Min(Mathf.Max(nowView, 30), 80); //Ограничение
        m_Camera.fieldOfView = nowView;

    }
}
