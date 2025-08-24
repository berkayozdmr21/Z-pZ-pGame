using UnityEngine;
using UnityEngine.SceneManagement;

public class YananZemin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Yanan zeminin içinden geçildiğinde sahneyi değiştir
        if (other.CompareTag("GeçişAlanı"))
        {
            SceneManager.LoadScene(2);
        }
    }
}


