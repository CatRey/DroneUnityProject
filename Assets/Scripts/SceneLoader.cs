using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //Ассинхронная Загрузка уровня
    public void SceneStart(int n) => StartCoroutine(Load(n));
    IEnumerator Load(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        while (!operation.isDone)
        {
            yield return null;
        }
    }

    //Выход из приложения

    public void Quit()
    {
        Application.Quit();
    }

}
