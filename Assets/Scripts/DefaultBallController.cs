using UnityEngine;

public class DefaultBallController : MonoBehaviour
{
    protected float startDrag = 0.4f;
    protected float stopDrag = 1f;

    protected const float STOP_SPEED = 0.2f;

    protected Rigidbody2D energyBall;

    protected virtual void Start()
    {
        energyBall = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        if (energyBall.velocity.magnitude <= STOP_SPEED)
        {
            energyBall.drag = stopDrag;
        }
    }
}