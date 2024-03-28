using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed = 3f; 
    public float changeTargetTime = 2f; 
    public float minX, maxX, minY, maxY; 

    private Vector2 targetPosition;
    private float timer;

    void Start()
    {
        SetNewTarget(); 
    }

    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        
        if ((Vector2)transform.position == targetPosition || timer >= changeTargetTime)
        {
            SetNewTarget();
            timer = 0f;
        }

        timer += Time.deltaTime;
    }

    void SetNewTarget()
    {
        
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        targetPosition = new Vector2(randomX, randomY);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Boundary"))
        {
            SetNewTarget();
        }
    }

}
