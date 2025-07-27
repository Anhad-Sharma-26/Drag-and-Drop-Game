using UnityEngine;
using System.Collections;

public class Bin : MonoBehaviour
{
    public ParticleSystem celebrationParticles;
    public Color binColor;                  
    public GameManager gameManager;         
    public Renderer binRenderer; 
    public Color glowColor = Color.yellow;
    public float glowDuration = 0.2f;
    public Color pulseColor = Color.yellow; 
    public float pulseDuration = 0.2f;     
    public int pulseCount = 1; 

    void Awake()
    {
        if (gameManager == null)
            gameManager = FindObjectOfType<GameManager>();
    }

    public bool CheckMatch(Color objectColor)
{
    float threshold = 0.1f; 
    return Mathf.Abs(objectColor.r - binColor.r) < threshold &&
           Mathf.Abs(objectColor.g - binColor.g) < threshold &&
           Mathf.Abs(objectColor.b - binColor.b) < threshold;
}

   private void OnTriggerEnter(Collider other)
{
    ShapeIdentity shape = other.GetComponent<ShapeIdentity>();
    TimedDeath timedDeath = other.GetComponent<TimedDeath>();
    if (timedDeath != null)
        timedDeath.MarkCollected();

    if (shape != null)
    {
        if (CheckMatch(shape.assignedColor))
        {
            gameManager.IncreaseScore(1);
            if (celebrationParticles != null)
                celebrationParticles.Play();
            PlayPulse();

           
            Destroy(other.gameObject, 0.05f);
        }
        else
        {
            Destroy(other.gameObject, 0.05f);
        }
    }
}

    public void PlayGlow()
    {
    if (binRenderer != null)
        StartCoroutine(GlowCoroutine());
    }

    private IEnumerator GlowCoroutine()
    {
    Color originalColor = binRenderer.material.color;
    binRenderer.material.color = glowColor;
    yield return new WaitForSeconds(glowDuration);
    binRenderer.material.color = originalColor;
    }

    public void PlayPulse()
{
    if (binRenderer != null)
        StartCoroutine(PulseCoroutine());
}

private IEnumerator PulseCoroutine()
{
    Color originalColor = binRenderer.material.color;
    for (int i = 0; i < pulseCount; i++)
    {
        binRenderer.material.color = pulseColor;
        yield return new WaitForSeconds(pulseDuration * 0.5f);
        binRenderer.material.color = originalColor;
        yield return new WaitForSeconds(pulseDuration * 0.5f);
    }
}

}
