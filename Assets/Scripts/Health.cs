using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        JohnMovement controller = other.GetComponent<JohnMovement>();

        if (controller != null)
        {
            if (controller.Health < controller.vidaMaxima)
            {
                controller.ChangeHealth(2);
                Destroy(gameObject);
            }
        }
    }
}