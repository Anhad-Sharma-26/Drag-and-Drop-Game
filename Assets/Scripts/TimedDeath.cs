using UnityEngine;
using System.Collections;

public class TimedDeath : MonoBehaviour
{
    public float lifeTime = 5f;
    private bool collected = false;
    private GameManager gameManager;
    private Coroutine deathCoroutine;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        deathCoroutine = StartCoroutine(DeathCountdown());
    }

    // Call this on object collection to prevent penalty 
    public void MarkCollected()
    {
        if (!collected)
        {
            collected = true;
            if (deathCoroutine != null)
            {
                StopCoroutine(deathCoroutine);
                Debug.Log($"{gameObject.name} timer stopped at {Time.time}");
            }
        }
    }

    private IEnumerator DeathCountdown()
    {
        yield return new WaitForSeconds(lifeTime);

        if (!collected && gameManager != null)
        {
            Debug.Log($"{gameObject.name} timed out! Decreasing score at {Time.time}.");
            gameManager.DecreaseScore(1);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log($"{gameObject.name} timer ended but already collected.");
        }
    }
}
