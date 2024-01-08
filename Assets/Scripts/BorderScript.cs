using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScript : MonoBehaviour
{
    public GameObject alternateBorder;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Puck")
        {
            if(GameManager.Instance.puck.transform.position.y > 0)
            {
                GameManager.Instance.enemy.isActive = true;
                gameObject.SetActive(false);
                alternateBorder.SetActive(true);
            }
            if(GameManager.Instance.puck.transform.position.y < 0)
            {
                GameManager.Instance.enemy.isActive = false;
                gameObject.SetActive(false);
                alternateBorder.SetActive(true);
            }
              
        }
    }
}
