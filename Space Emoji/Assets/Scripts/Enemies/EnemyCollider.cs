using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Rocket"))
        {
            Debug.Log("Rocket Dead");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Score"))
        {
            Debug.Log("Score +1");
        }
    }
}