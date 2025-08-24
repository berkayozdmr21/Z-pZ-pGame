// KlonZemin.cs
// KlonZemin.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlonZemin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("AnaZemin"))
        {
            
        }
    }
}
