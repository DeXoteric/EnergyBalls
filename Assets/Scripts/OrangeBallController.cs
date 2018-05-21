using UnityEngine;

public class OrangeBallController : DefaultBallController
{
    [SerializeField] private int scorePerHit = 1;
    [SerializeField] private float forceMultiplier = 0.12f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        energyBall.drag = startDrag;
        LevelController.AddScore(scorePerHit);

        if (collision.gameObject.tag == "Ball")
        {
            energyBall.AddForce(energyBall.velocity * forceMultiplier, ForceMode2D.Impulse);
        }
    }
}