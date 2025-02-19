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
        // Сохраняем исходный масштаб
        initialScale = transform.localScale;

        // Добавляем случайный поворот
        float randomAngle = Random.Range(0f, 360f);
        transform.rotation = Quaternion.Euler(0f, 0f, randomAngle);

        // Определяем случайный множитель масштабирования
        targetScaleMultiplier = Random.Range(scaleMultiplierRange.x, scaleMultiplierRange.y);

        spriteRenderer = GetComponent<SpriteRenderer>();
        
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    void Update()
    {
        timer += Time.deltaTime;
        float t = timer / duration;

        // Интерполяция масштаба с учетом случайного множителя
        transform.localScale = Vector3.Lerp(initialScale, initialScale * targetScaleMultiplier, t);

        // Постепенное исчезновение (если есть спрайт)
        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            color.a = Mathf.Lerp(1f, 0f, t);
            spriteRenderer.color = color;
        }

        // Уничтожение объекта по окончании анимации
        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }
}