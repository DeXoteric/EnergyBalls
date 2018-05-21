using UnityEngine;

public class CyanBallController : DefaultBallController
{
    [SerializeField] private int scorePerHit = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        energyBall.drag = startDrag;
        LevelController.AddScore(scorePerHit);
    }
}