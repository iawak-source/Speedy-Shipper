using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("you are hit");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("What was that?");
    }
}
