using UnityEngine;
using UnityEngine.EventSystems;

public class WhiteBallController : DefaultBallController
{
    [SerializeField] private float forceMultiplier = 10f;

    [SerializeField] private int scorePerHit = 1;

    private Vector2 currentMousePosition, currentWhiteBallPosition, direction;

    protected override void FixedUpdate()
    {
        if (energyBall.velocity.magnitude <= STOP_SPEED)
        {
            energyBall.drag = stopDrag;
        }
        if (!LevelController.CheckIfBallsAreMoving())
        {
            LevelController.isRoundActive = false;
        }
    }

    private void OnMouseDrag()
    {
        Vector3 currentScreenMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentMousePosition = new Vector2(currentScreenMousePosition.x, currentScreenMousePosition.y);
        currentWhiteBallPosition = new Vector2(energyBall.position.x, energyBall.position.y);

        float directionX = currentWhiteBallPosition.x - currentMousePosition.x;
        float directionY = currentWhiteBallPosition.y - currentMousePosition.y;

        direction = new Vector2(directionX, directionY);

        direction.Normalize();
    }

    private void OnMouseUp()
    {
        if (!LevelController.CheckIfBallsAreMoving())
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                LaunchBall();

                LevelController.NextMove();
            }
        }
    }

    private void LaunchBall()
    {
        energyBall.drag = startDrag;
        LevelController.isRoundActive = true;

        energyBall.AddForce(direction * forceMultiplier, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        LevelController.AddScore(scorePerHit);
    }
}