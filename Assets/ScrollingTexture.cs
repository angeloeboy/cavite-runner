using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ScrollTexture : MonoBehaviour
{
    public float scrollSpeed = 0.2f;
    private Renderer rend;
    private Vector2 savedOffset;
    private Vector2 currentOffset;
    public float scrollFactor = 0.0000001f;
    void Start()
    {
        rend = GetComponent<Renderer>();
        savedOffset = rend.material.GetTextureOffset("_MainTex");
        currentOffset = savedOffset;
    }

    void Update()
    {
        float y = Mathf.Repeat(-Time.time * 0.2f, 1);
        Vector2 offset = new Vector2(savedOffset.x, savedOffset.y + y);
        rend.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    void OnDisable()
    {
        rend.material.SetTextureOffset("_MainTex", savedOffset);
    }
}
