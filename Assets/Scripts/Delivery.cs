using System;
using NUnit.Framework;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float delay = 1f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Pick up Package");
            hasPackage = true;
            Destroy(collision.gameObject, delay);
        }
        if (collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Delivered Package");
            hasPackage = false;
            Destroy(collision.gameObject, delay);
        }
    }

}
