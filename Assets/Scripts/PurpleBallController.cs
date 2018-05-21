using UnityEngine;

public class PurpleBallController : DefaultBallController
{
    [SerializeField] private int multiplierPerHit = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        energyBall.drag = startDrag;
        if (collision.gameObject.tag == "Ball")
        {
            LevelController.AddMultiplier(multiplierPerHit);
        }
    }
}