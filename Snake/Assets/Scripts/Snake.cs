using System;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private List<Transform> segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initialSize = 3;

    private void Start()
    {
        ResetState();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (_direction != Vector2.down)
            {
                _direction = Vector2.up;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (_direction != Vector2.up)
            {
                _direction = Vector2.down;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (_direction != Vector2.right)
            {
                _direction = Vector2.left;
            }
           
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (_direction != Vector2.left)
            {
                _direction = Vector2.right;
            }
            
        }
    }

    private void FixedUpdate()
    {
        for (int i = segments.Count -1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }
        this.transform.position = new Vector3(Mathf.Round(this.transform.position.x + _direction.x), Mathf.Round(transform.position.y + _direction.y),0.0f);
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }


    private void ResetState()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(this.transform);
        for (int i = 1; i < this.initialSize; i++)
        {
            segments.Add(Instantiate(segmentPrefab));
        }
        transform.position = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Grow();
        }
        if (collision.tag == "Obstacle")
        {
            ResetState();
        }

    }

}
