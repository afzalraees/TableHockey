using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckManager : MonoBehaviour
{
    public Rigidbody2D rb;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Goal")
        {
            GameManager.Instance.Goal();
        }
        if (collision.collider.tag == "GameOver")
        {
            GameManager.Instance.uiManager.GameOver();
        }
        if (collision.collider.tag == "Enemy")
        {
            
            Vector2 direction = collision.collider.transform.position - transform.position;
            rb.velocity = direction *5f;
        }
    }
}
