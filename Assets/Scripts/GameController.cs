using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Первый паттерн ООП
    public static GameController instance;
    private void Awake()
    {
        if(instance == null) instance = this;
        else Destroy(instance);
    }
    public GameObject[] startObjects; //Объекты для показа старта
    public GameObject[] gameObjects; //для игры
    public GameObject[] endObjects; //для окончания
    private void Start()
    {
        //Выключение остальных
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
    public void Start2Game() //Перевод в состяние игры
    {
        //Выключаем объеты start
        foreach (GameObject i in startObjects)
        {
            i.SetActive(false);
        }
        //Включаем game
        foreach(GameObject i in gameObjects)
        {
            i.SetActive(true);
        }
    }
    public void Game2End() //Перевод в состояние окончания
    {
        //Аналогично
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
