using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float timeUnit = 0.01f; // in SECONDS
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
        
        int scoreToDisplay = LevelController.GetScore() * LevelController.GetMultiplier();
        scoreText.text = "Score: " + scoreToDisplay;
    }
}