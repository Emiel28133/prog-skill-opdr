using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    private void OnEnable()
    {
        Pickup.OnPickupCollected += UpdateScore;
    }

    

    private void OnDisable()
    {
        Pickup.OnPickupCollected -= UpdateScore;
        Debug.Log("Scoreboard enabled");
    }

    private void UpdateScore()
    {
        score += 50;
        scoreText.text = "Score: " + score;
        Debug.Log("Scoreboard enabled");
    }
}
