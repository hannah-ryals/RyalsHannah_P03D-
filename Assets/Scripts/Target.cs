using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 10f;
    public AudioSource death;
    
   public GameObject other;


    public void TakeDamage (float amount)
    {
        health -= amount;
        gameObject.transform.localScale -= new Vector3(transform.localScale.x * 0.3f, transform.localScale.y * 0.3f, transform.localScale.z * 0.3f);
        if (health <= 0f)
        {
            other.GetComponent<Level01Controller>().IncreaseScore(5);

            Die();
        }
    }

    void Die()
    {
        death.Play();
        Destroy(gameObject);
    }
}
