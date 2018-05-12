using UnityEngine;

public class WhiteBallController : MonoBehaviour
{
    [Range(10f, 100f)] [SerializeField] private float forceMultiplier = 100f;
    [SerializeField] float startDrag = 0.4f;
    [SerializeField] float stopDrag = 1f;
    [SerializeField] private int scorePerHit = 1;

    private const float STOP_SPEED = 0.1f;

    private Rigidbody2D energyBall;
    private Vector2 currentMousePosition, currentWhiteBallPosition;

    private void Start()
    {
        energyBall = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        print(energyBall.velocity.magnitude);
        if (energyBall.velocity.magnitude <= STOP_SPEED)
        {
            energyBall.drag = stopDrag;
        }
    }

    private void OnMouseDrag()
    {
        
        Vector3 currentScreenMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentMousePosition = new Vector2(currentScreenMousePosition.x, currentScreenMousePosition.y);
    }

    private void OnMouseUp()
    {
        energyBall.drag = startDrag;
        currentWhiteBallPosition = new Vector2(energyBall.position.x, energyBall.position.y);

        float directionX = currentWhiteBallPosition.x - currentMousePosition.x;
        float directionY = currentWhiteBallPosition.y - currentMousePosition.y;

        Vector2 direction = new Vector2(directionX, directionY);

        direction.Normalize();

        energyBall.AddForce(direction * forceMultiplier, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ScoreTotal.AddScore(scorePerHit);
    }
}