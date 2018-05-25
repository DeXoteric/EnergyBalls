using UnityEngine;

public class DefaultBallController : MonoBehaviour
{
    protected int scorePerHit = 1;
    protected int scoreOverTime = 1;

    protected float startDrag = 0.4f;
    protected float stopDrag = 1f;

    protected const float DRAG_SPEED = 0.3f;
    protected const float STOP_SPEED = 0.1f;

    protected Rigidbody2D energyBall;

    protected virtual void Start()
    {
        energyBall = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        if (energyBall.velocity.magnitude <= DRAG_SPEED)
        {
            energyBall.drag = stopDrag;
        }

        if (energyBall.velocity.magnitude <= STOP_SPEED)
        {
            energyBall.Sleep();
        }

        if (!LevelController.CheckIfBallsAreMoving())
        {
            LevelController.isRoundActive = false;
        }
        else
        {
            int value = (int)(Mathf.CeilToInt(energyBall.velocity.magnitude));
            LevelController.AddScore(value);
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        energyBall.drag = startDrag;
    }
}