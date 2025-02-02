using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    public float speed;

    public float minX, minY, maxX, maxY;

    Vector3 currentTarget;

    public GameObject blood;

    private Animator camAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camAnim = Camera.main.GetComponent<Animator>();

        currentTarget = GetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, currentTarget) > 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }
        else
        {
            currentTarget = GetRandomPosition();
        }
        
    }

    Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        return randomPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Altar"))
        {
            // Trigger camera shake animation
            if (camAnim != null)
            {
                camAnim.SetTrigger("Shake");
            }
            else
            {
                Debug.LogWarning("Camera Animator is not assigned.");
            }

            // Trigger Game Over using the Singleton pattern
            if (GameOver.Instance != null)
            {
                GameOver.Instance.GameEnd();
            }
            else
            {
                Debug.LogError("GameOver singleton not found.");
            }
        }

        if (collision.CompareTag("Trap"))
        {
            // Trigger camera shake and handle trap logic
            if (camAnim != null)
            {
                camAnim.SetTrigger("Shake");
            }

            // Destroy trap object and spawn blood
            Destroy(collision.gameObject);
            Instantiate(blood, transform.position, Quaternion.identity);

            // Destroy the enemy itself
            Destroy(gameObject);
        }

        if (collision.CompareTag("Human"))
        {
            // Destroy human object and spawn blood
            Destroy(collision.gameObject);
            Instantiate(blood, transform.position, Quaternion.identity);
        }
    }
}
