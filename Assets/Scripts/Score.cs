using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private float timeUnit = 0.1f; // in SECONDS
    private Text scoreText;
    

    private void Start()
    {
        scoreText = GetComponent<Text>();
        StartCoroutine(UpdateDisplay());
    }

    private IEnumerator UpdateDisplay()
    {
        WaitForSeconds delay = new WaitForSeconds(timeUnit);

        while (true)
        {
            UpdateScore();
            yield return delay;
        }
    }

    // Call this method if you have to update the scoreText manually
    public void UpdateScore()
    {
        string score = ScoreTotal.GetScore().ToString();
        string multiplier = ScoreTotal.GetMultiplier().ToString();

        scoreText.text = "Score: " + score + " x" + multiplier;
    }
}