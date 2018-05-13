public static class ScoreTotal
{
    private static int scoreTotal = 0;
    private static int scoreMultiplier = 1;

    public static void AddScore(int score)
    {
        scoreTotal += score;
    }

    public static int GetScore()
    {
        return scoreTotal;
    }

    public static void ResetScore()
    {
        scoreTotal = 0;
    }

    public static void AddMultiplier(int multiplier)
    {
        scoreMultiplier += multiplier;
    }

    public static int GetMultiplier()
    {
        return scoreMultiplier;
    }

    public static void ResetMultiplier()
    {
        scoreMultiplier = 0;
    }
}