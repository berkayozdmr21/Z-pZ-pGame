using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SahneGeçişi : MonoBehaviour
{
    private bool yananZeminTemasEdildi = false;

    private void Update()
    {
        // Eğer yanan zemine temas edildiyse sahneyi değiştir
        if (yananZeminTemasEdildi)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Çarpışmanın olduğu nesnenin etiketini kontrol et
        if (collision.gameObject.CompareTag("YananZemin"))
        {
            yananZeminTemasEdildi = true;
        }
    }
}
