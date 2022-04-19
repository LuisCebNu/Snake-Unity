using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D GridArea;
    public SpriteRenderer _color;
    private void Start()
    {
        RandomizePosition();
    }
    private void RandomizePosition()
    {
        Bounds bounds = this.GridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
       
        this.transform.position = new Vector3(Mathf.Round (x),Mathf.Round (y), 0.0f);
        _color.color = new Color(Mathf.Round(x+1), Mathf.Round(y+1), 3, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            RandomizePosition();
        }
        
    }
}
