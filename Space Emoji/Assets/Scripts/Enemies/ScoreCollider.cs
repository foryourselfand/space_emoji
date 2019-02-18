using UnityEngine;

public class ScoreCollider : MonoBehaviour
{
    public ScoreManager scoreManager;
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            scoreManager.IncreaseScore();
        }
    }
}