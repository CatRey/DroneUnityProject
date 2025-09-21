using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Building : MonoBehaviour
{
    private Camera m_Camera;
    private BuildingPrefab nowPrefab; //Наш объект для премешентя
    private Vector3 pointPlace = Vector3.zero; //Точка для построения плоскостей (для мотров и винта Y!=0)
    private Material cashMaterial; //Материал объекта (удбство UI)
    private Vector3 target; //Нужная позиция объекта
    public BuildingPrefab[] myBP; //Для указывания
    private List<BuildingPrefab>[] parts = new List<BuildingPrefab>[4]; //Префабы
    private int[] counts = { 0, 0, 0, 0 };//Счетчик
    private int nowType = -1;//Наш type
    private List<BuildingPrefab> placedPrefabs = new List<BuildingPrefab>();
    public GameController gameController; // Контроллер игры
    void Start()
    {
        m_Camera = Camera.main; //Наша камера
        // Инициализируем каждый элемент массива списков
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i] = new List<BuildingPrefab>();
        }
        //Указываем в List
        parts[0].Add(myBP[0]);
        for(int i = 1; i < 4; i++)
        {
            for (int j = 0; j < 4; j++) parts[i].Add(myBP[(i-1)*4+j+1]);
        }
    }
    
    public void StartPlacing(int type) //Начало строительства
    {
        
        //Если объект существует - удаляем
        if (nowPrefab != null)
        {
            Destroy(nowPrefab.gameObject);

        }
        //Создаем 
        nowPrefab = Instantiate(parts[type][counts[type]]);
        target = nowPrefab.target;
        pointPlace.y = target.y;
        nowType = type;
        cashMaterial = new Material( nowPrefab.GetComponent<Renderer>().material);
        
    }
    private void Update()
    {
        //Если создан объект - перемещаем за мышкой
        if (nowPrefab != null)
        {
            var ground = new Plane(Vector3.up,pointPlace);//Создаем плоскость
            Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition); 
            if(ground.Raycast(ray, out float position))
            {
                Vector3 nowPosition = ray.GetPoint(position); //Наша позиция
                nowPrefab.transform.position = nowPosition; //Задаем для объекта
                bool inPlace = true; // Правильно ли расположено
                if(Mathf.Abs(nowPosition.x-target.x)>0.15f && Mathf.Abs(nowPosition.z - target.z) > 0.15f)
                {
                    inPlace = false; //Если не рядом с целевой точкой - выключаем
                }
                //Рисуем, если неправильно расположен красный, иначе наш
                if (inPlace)
                {
                    nowPrefab.GetComponent<Renderer>().material = cashMaterial;

                }
                else
                {
                    nowPrefab.GetComponent<Renderer>().material.color = Color.red;
                }
                //Если нажал кнопку - ставим
                if (Input.GetMouseButtonDown(0) && inPlace)
                {
                    placedPrefabs.Add(nowPrefab);
                    gameObject.GetComponent<AudioSource>().Play();//Проигрыш звука
                    //Увеличиваем счетчик; обnullываем
                    counts[nowType]++;
                    nowType = -1;
                    nowPrefab.transform.position = target;
                    nowPrefab = null;
                    cashMaterial = null;

                }
            }
        }
        if (counts[0] + counts[1] + counts[2] + counts[3] >= 13)
        {//Поставлены все объекты - удаляем, вызываем EndFunc
            gameController.GetComponent<GameController>().Game2End();
            foreach (BuildingPrefab i in placedPrefabs)
            {
                Destroy(i.gameObject);
            }
            
        }
    }
}
