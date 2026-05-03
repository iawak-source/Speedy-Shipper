using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float delay = 0.5f;

    void Start()
    {
        GetComponent<ParticleSystem>().Stop();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.CompareTag("Package") && !hasPackage)
            {
                Debug.Log("Pick up Package");
                hasPackage = true;
                GetComponent<ParticleSystem>().Play();
                Destroy(collision.gameObject, delay);

            }
            else if (collision.CompareTag("Boost"))
            {
                GetComponent<ParticleSystem>().Play();
            }
        }
        if (collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Delivered Package");
            hasPackage = false;
            GetComponent<ParticleSystem>().Stop();
            Destroy(collision.gameObject, delay);
        }
    }

}
