using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Yönetici : MonoBehaviour
{
    public Text skor;
    public static float skorsayısı;

    void Update()
    {
        skor.text = skorsayısı.ToString();

        
    }

    
}
