using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float delay = 1f;

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
            else
            {
                GetComponent<ParticleSystem>().Stop();
            }
        }
        if (collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Delivered Package");
            hasPackage = false;
            GetComponent<ParticleSystem>().Stop();
        }
    }

}
