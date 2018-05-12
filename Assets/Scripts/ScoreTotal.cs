public static class ScoreTotal
{
    private static int scoreTotal = 0;

    public static void AddScore(int score)
    {
        scoreTotal += score;
    }

    public static int GetScore()
    {
        return scoreTotal;
    }
}