using UnityEngine;

public class StarExplosion : MonoBehaviour
{
    public float duration = 1f;
    public Vector2 scaleMultiplierRange = new Vector2(1.5f, 2.5f);

    private float timer = 0f;
    private Vector3 initialScale;
    private SpriteRenderer spriteRenderer;
    private float targetScaleMultiplier;
    private AudioSource audioSource;

    void Awake()
    {
        // Save initial scale
        initialScale = transform.localScale;

        // Add random rotation
        float randomAngle = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0f, 0f, randomAngle);

        // Random scale multiplier
        targetScaleMultiplier = Random.Range(scaleMultiplierRange.x, scaleMultiplierRange.y);

        spriteRenderer = GetComponent<SpriteRenderer>();

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    void Update()
    {
        timer += Time.deltaTime;
        float t = timer / duration;

        // Interpolate scale
        transform.localScale = Vector3.Lerp(initialScale, initialScale * targetScaleMultiplier, t);

        // Fade out
        if (spriteRenderer)
        {
            Color color = spriteRenderer.color;
            color.a = Mathf.Lerp(1f, 0f, t);
            spriteRenderer.color = color;
        }

        // Destroy
        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }
}