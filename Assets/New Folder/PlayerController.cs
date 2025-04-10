using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 direction;
    public float gravity = -20f;  
    public float jumpStrength = 8f;  
    public SpriteRenderer spriteRenderer;
    private int spriteIndex;
    public Sprite[] sprites;

    private bool isGrounded = true;   
    private Vector3 startPosition;  

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }
    void Start()
    { 
        startPosition = transform.position;  
    }

    void Update()
    {
        
        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            direction.y = jumpStrength; 
            isGrounded = false;  
        }

        
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        
        if (transform.position.y <= startPosition.y)
        {
            isGrounded = true; 
            transform.position = startPosition;  
            direction.y = 0;  
        }
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
    void AnimateSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }
    private void OnTriggerEnter2D(Collider2D collision)
   
    {
        if (collision.gameObject.tag == "obstacle")
        {
            FindFirstObjectByType<Game>().gameover();
        }
    }
}
