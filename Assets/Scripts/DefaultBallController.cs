using UnityEngine;

public class DefaultBallController : MonoBehaviour
{
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
    }

    
}