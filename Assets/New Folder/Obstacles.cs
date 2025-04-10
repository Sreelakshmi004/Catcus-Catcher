using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private float ledge;
    public float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ledge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left *speed * Time.deltaTime;
        if (transform.position.x < ledge)
        {
            Destroy(gameObject);
        }
    }
}
