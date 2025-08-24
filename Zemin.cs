using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zemin: MonoBehaviour
{
    // Zıplama kuvveti değişkeni
    public float ZıplamaKuvveti;
    
    // Zeminin temas edildiği kontrolü
    private bool zeminetemasledildi;

    // Etkisiz hale getirilecek zemin nesnesinin referansını tutacak değişken
    public GameObject etkisizZeminPrefab;

    // Zemin nesnesinin temas edildiğinde çalışacak fonksiyon
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Eğer çarpışma yönü aşağı doğru ise
        if (collision.relativeVelocity.y < 0)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                // Zıplama kuvvetini uygula
                Vector2 zıplamaVelocity = rb.velocity;
                zıplamaVelocity.y = ZıplamaKuvveti;
                rb.velocity = zıplamaVelocity;
            
                // Eğer zemin daha önce temas edilmediyse
                if (!zeminetemasledildi)
                {
                    // Skoru arttır
                    Yönetici.skorsayısı++;
                    // Temas edildi olarak işaretle
                    zeminetemasledildi = true;

                    // Zemin nesnesini etkisiz hale getir (kaybet)
                    gameObject.SetActive(false);

                    // Etkisiz hale getirilen zemin nesnesini yeniden oluştur
                    OluşturEtkisizZemin();
                }
            }
        }
    }

    // Etkisiz hale getirilen zemin nesnesini yeniden oluşturacak fonksiyon
    private void OluşturEtkisizZemin()
    {
        // Yeni zemin nesnesi oluştur
        GameObject yeniZemin = Instantiate(etkisizZeminPrefab, transform.position, Quaternion.identity);
        yeniZemin.SetActive(true); // Oluşturulan zemin nesnesini aktifleştir
    }
}










  //if (Time.time - zaman < 10f)
/* yukardaki sistem eğer karekter 10 saniye boyunca bir yere temas etmezse oyunu durdur
eğer temas sonrası aşağı düşerse if(i<=10f olduğunda)
10 kere temastan sonra puanı 1.5 kat say
else{
her 10 temasta(i>15)
oldukça 1.5!= ++
değilse 
3*i i++

tamamında geldiğinde sistem kazandı yap
aşağı düşmede tammamen say 





}














/*{
    public float ZıplamaKuvveti;
    private bool zeminetemasledildi;

    // Etkisiz hale getirilecek zemin nesnesinin referansını tutacak değişken
    public GameObject etkisizZeminPrefab;

    // Zemin nesnesinin temas edildiğinde çalışacak fonksiyon
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 zıplamaVelocity = rb.velocity;
                zıplamaVelocity.y = ZıplamaKuvveti;
                rb.velocity = zıplamaVelocity;
            
             if (!zeminetemasledildi)
            {
                Yönetici.skorsayısı++;
                zeminetemasledildi = true;

                // Zemin nesnesini etkisiz hale getir (kaybet)
                gameObject.SetActive(false);

                // Etkisiz hale getirilen zemin nesnesini yeniden oluştur
                OluşturEtkisizZemin();
            }
            
            
            }

            // Eğer zemin daha önce temastan geçmediyse, skoru arttır
           
        }
    }

    // Etkisiz hale getirilen zemin nesnesini yeniden oluşturacak fonksiyon
    private void OluşturEtkisizZemin()
    {
        // Yeni zemin nesnesi oluştur
        GameObject yeniZemin = Instantiate(etkisizZeminPrefab, transform.position, Quaternion.identity);
        yeniZemin.SetActive(true); // Oluşturulan zemin nesnesini aktifleştir
    }
}
*/

/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zemin : MonoBehaviour
{
    public float ZıplamaKuvveti;
    private bool zeminetemasledildi;
    private float karakterTemasZamanı; // Karakterin zemindeki temas süresini tutmak için zaman sayacı
    private float[] klonZeminTemasZamanları; // Klon zeminlerin temas sürelerini tutacak dizi
    public GameObject etkisizZeminPrefab;
    private List<GameObject> klonZeminler; // Klon zeminleri tutmak için bir liste oluşturuyoruz

    void Start()
    {
        karakterTemasZamanı = Time.time;
        klonZeminTemasZamanları = new float[3]; // 3 klon zemin olduğunu varsayalım, dizinin boyutunu klon zemin sayısına göre ayarlayın
        klonZeminler = new List<GameObject>(); // Klon zemin listesini boş bir liste olarak oluşturuyoruz
        OluşturEtkisizZemin();
    }

    private void OluşturEtkisizZemin()
    {
        // Yeni zemin nesnesi oluştur
        GameObject yeniZemin = Instantiate(etkisizZeminPrefab, transform.position, Quaternion.identity);
        yeniZemin.SetActive(true);
        klonZeminler.Add(yeniZemin); // Yeni zemin nesnesini klon zemin listesine ekle
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y < 0)
        {
            if (collision.collider.gameObject.CompareTag("KlonZemin"))
            {
                // Klon zeminle temas edildiğinde ana karakterin temas zamanını sıfırla
                karakterTemasZamanı = Time.time;

                // Klon zeminin temas zamanını güncelle
                int klonIndex = klonZeminler.IndexOf(collision.collider.gameObject);
                klonZeminTemasZamanları[klonIndex] = Time.time;

                // Diğer klon zeminlerin temas zamanlarını sıfırla
                for (int i = 0; i < klonZeminTemasZamanları.Length; i++)
                {
                    if (i != klonIndex)
                    {
                        klonZeminTemasZamanları[i] = 0f;
                    }
                }
            }
            else if (collision.collider.gameObject.CompareTag("AnaZemin"))
            {
                // Ana zeminle temas edildiğinde ana karakterin temas zamanını sıfırla
                karakterTemasZamanı = Time.time;
            }

            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 zıplamaVelocity = rb.velocity;
                zıplamaVelocity.y = ZıplamaKuvveti;
                rb.velocity = zıplamaVelocity;
            }

            if (!zeminetemasledildi)
            {
                Yönetici.skorsayısı++;
                zeminetemasledildi = true;

                gameObject.SetActive(false);

                // Rastgele bir klon zemin seç ve aktifleştir
                int randomIndex = Random.Range(0, klonZeminler.Count);
                klonZeminler[randomIndex].SetActive(true);
            }
        }
    }

    void Update()
    {
        // Ana karakter veya klon zeminlerden herhangi biriyle temas edildiğinde, 10 saniye süreyi sıfırla
        if (zeminetemasledildi || KlonZemineTemasEdildi())
        {
            karakterTemasZamanı = Time.time;
            zeminetemasledildi = false;
        }

        // Karakter 10 saniye boyunca zeminle temas etmezse sahneyi değiştir
        if (Time.time - karakterTemasZamanı > 10f)
        {
            SceneManager.LoadScene(2);
            Yönetici.skorsayısı = 0;
        }
    }

    // Klon zeminlere temas edilip edilmediğini kontrol eden bir fonksiyon
    private bool KlonZemineTemasEdildi()
    {
        foreach (var zaman in klonZeminTemasZamanları)
        {
            if (Time.time - zaman < 10f)
            {
                return true;
            }
        }
        return false;
    }
}

*/