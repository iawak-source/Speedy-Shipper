using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Driver : MonoBehaviour
{
    [SerializeField] float currentSpeed = 8f;
    [SerializeField] float steerSpeed = 150f;
    [SerializeField] float boostSpeed = 10f;
    [SerializeField] float regularSpeed = 8f;
    [SerializeField] TMP_Text boostText;
    [SerializeField] float delay = 0.3f;

    void Start()
    {
        boostText.gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boost"))
        {
            currentSpeed = boostSpeed;
            boostText.gameObject.SetActive(true);
            Destroy(collision.gameObject, delay);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("WorldCollision"))
        {
            currentSpeed = regularSpeed;
            boostText.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        float move = 0f;
        float steer = 0f;

        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            move = -1f;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
        }

        float moveAmount = currentSpeed * move * Time.deltaTime;
        float steerAmount = steerSpeed * steer * Time.deltaTime;

        transform.Rotate(0, 0, steerAmount);
        transform.Translate(0, moveAmount, 0);

    }
}
