using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    internal static void SahneyiDegistir()
    {
        throw new NotImplementedException();
    }

    void Update()
    {

        if(Input.GetMouseButton(1)){
        SceneManager.LoadScene(1);
    }
}
}