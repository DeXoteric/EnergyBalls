using UnityEngine;

public class DefaultBallController : MonoBehaviour
{
    [SerializeField] private float startDrag = 0.4f;
    [SerializeField] private float stopDrag = 1f;

    private const float STOP_SPEED = 0.1f;

    private Rigidbody2D energyBall;

    private void Start()
    {
        energyBall = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (energyBall.velocity.magnitude <= STOP_SPEED)
        {
            energyBall.drag = stopDrag;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        energyBall.drag = startDrag;
    }
}