using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class NewBehaviourScript : MonoBehaviour {

    // Hareket hızı değişkeni
    public float harekethızı;

    private float yatayhareket;

    // RigidBody bileşeni
    Rigidbody2D rb;

    private void Start(){
        // RigidBody bileşenini al
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        // Yatay girişi al
        yatayhareket =  Input.GetAxis("Horizontal");
        // Hareketi uygula
        rb.velocity = new Vector2(yatayhareket*harekethızı*Time.deltaTime,rb.velocity.y);

        // Karakterin yönünü belirle
        Vector2 yeniscale = transform.localScale;
        if(yatayhareket >0){
            // Sağa doğru dön
            yeniscale.x = 0.5f;
        }

        if(yatayhareket < 0){
            // Sola doğru dön
            yeniscale.x = -0.5f;
        }
        // Yeni ölçekleri uygula
        transform.localScale = yeniscale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Eğer çarpışma bir "YananZemin" etiketine sahip ise
        if (collision.gameObject.tag == "YananZemin")
        {
            // İlgili sahneyi yükle
            SceneManager.LoadScene(2);
            // Skor sayısını sıfırla
            Yönetici.skorsayısı=0;   
        }
    }
}