using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int _score;

    public Text scoreText;

    public void ResetScore()
    {
        _score = 0;
    }

    public void IncreaseScore()
    {
        _score++;
        scoreText.text = _score.ToString();
    }
}