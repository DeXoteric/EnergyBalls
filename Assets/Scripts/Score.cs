using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    [SerializeField] private float timeUnit = 0.1f; // in SECONDS
    private Text scoreText;
    IEnumerator coroutine;

    private void Start()
    {
        scoreText = GetComponent<Text>();
        //coroutine = UpdateDisplay();
        StartCoroutine(UpdateDisplay());
    }

    IEnumerator UpdateDisplay()
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
        scoreText.text = "Score: " + ScoreTotal.GetScore().ToString();
    }
}