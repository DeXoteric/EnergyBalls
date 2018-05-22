using UnityEngine;

public static class LevelController
{
    private static int scoreTotal = 0;
    private static int scoreMultiplier = 1;
    private static int round = 0;
    private static int move = 0;

    public static bool isRoundActive = false;

    public static void AddScore(int score)
    {
        scoreTotal += score;
    }

    public static int GetScore()
    {
        return scoreTotal;
    }

    public static void AddMultiplier(int multiplier)
    {
        scoreMultiplier += multiplier;
    }

    public static int GetMultiplier()
    {
        return scoreMultiplier;
    }

    public static void NextRound()
    {
        round++;
    }

    public static int GetRound()
    {
        return round;
    }

    public static void NextMove()
    {
        move++;
    }

    public static int GetMove()
    {
        return move;
    }

    public static bool CheckIfBallsAreMoving()
    {
        
        GameObject[] allEnergyBalls = GameObject.FindGameObjectsWithTag("Ball"); 
        bool isMoving = false;
        foreach (GameObject ball in allEnergyBalls)
        {
            if (ball.GetComponent<Rigidbody2D>().velocity.magnitude > 0)
            {
                isMoving = true;
            }
        }
        return isMoving;
    }

    public static void ResetLevel()
    {
        scoreTotal = 0;
        scoreMultiplier = 1;
        round = 0;
        move = 0;
    }
}