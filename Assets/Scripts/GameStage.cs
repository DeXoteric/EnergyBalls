using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameStage : MonoBehaviour
{
    private float timeUnit = 1f;
    private int gameStage = 0;
    private Text roundCount;

    private void Start()
    {
        gameStage++;
        roundCount = GetComponent<Text>();
        roundCount.enabled = true;
        roundCount.text = DisplayRound(gameStage);
        StartCoroutine(CheckGameStage());
    }

    private IEnumerator CheckGameStage()
    {
        WaitForSeconds delay = new WaitForSeconds(timeUnit);

        while (true)
        {
            yield return delay;
        }
    }

    private string DisplayRound(int gameStage)
    {
        string text;
        if (gameStage == 1)
        {
            text = "Round One";
        }
        else if (gameStage == 2)
        {
            text = "Round Two";
        }
        else
        {
            text = "Last Round";
        }
        return text;
    }

    public static bool CheckIfBallsAreMoving()
    {
        GameObject[] allEnergyBalls = GameObject.FindGameObjectsWithTag("Ball");
        bool moving = true;
        foreach (GameObject ball in allEnergyBalls)
        {
            if (ball.GetComponent<Rigidbody2D>().IsSleeping())
            {
                moving = false;
            }
            else
            {
                moving = true;
            }
        }
        return moving;
    }
}