using UnityEngine;

public class OrangeBallController : DefaultBallController
{
    
    [SerializeField] private float forceMultiplier = 0.2f;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if (collision.gameObject.tag == "Ball")
        {
            energyBall.AddForce(energyBall.velocity * forceMultiplier, ForceMode2D.Impulse);
        }
    }
}