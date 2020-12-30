using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneAfterTime : MonoBehaviour
{
    void Start()
    {
        Invoke("ChangeScene", 34);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }
}
