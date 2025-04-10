using UnityEngine;

public class Ground1 : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.mainTextureOffset +=  Vector2.right*speed * Time.deltaTime;
    }
}
