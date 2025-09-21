using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //������������ �������� ������
    public void SceneStart(int n) => StartCoroutine(Load(n));
    IEnumerator Load(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        while (!operation.isDone)
        {
            yield return null;
        }
    }

    //����� �� ����������

    public void Quit()
    {
        Application.Quit();
    }

}
