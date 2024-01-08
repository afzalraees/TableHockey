using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public bool isActive;
    public float speed;
    public Vector3 centrePos;
    public Transform hitPoint;

    bool reachedPuck;
    bool reachedCentre;

    private void Start()
    {

    }
    private void FixedUpdate()
    {
        if(isActive && !reachedPuck)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.puck.transform.position, step);
        }
        else if(isActive && reachedPuck)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, centrePos, step);
            reachedCentre = Vector2.Distance(transform.position, centrePos) <= 0;
            if(reachedCentre)
            {
                reachedPuck = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.tag == "Puck")
        {
            //reachedPuck = true;
            StartCoroutine(pushDelay());
        }
    }

    IEnumerator pushDelay()
    {
        yield return new WaitForSeconds(0.5f);
        reachedPuck = true;
    }
}
