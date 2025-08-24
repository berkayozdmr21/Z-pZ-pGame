using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using static System.Net.Mime.MediaTypeNames;

public class MANAGER2 : MonoBehaviour
{
  


   void Update()
    {

        if(Input.GetMouseButton(0)){
        SceneManager.LoadScene(0);
    }
}
}
