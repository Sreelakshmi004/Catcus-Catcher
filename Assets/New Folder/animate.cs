using UnityEngine;

public class animate : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        index++;
        if (index >= sprites.Length)
        {
            index = 0;
        }
        spriteRenderer.sprite = sprites[index];
    }
}
