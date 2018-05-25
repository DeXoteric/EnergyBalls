using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WhiteBallController : DefaultBallController
{
    [SerializeField] private float forceMultiplier = 10f;

    [SerializeField] private ParticleSystem pulse;
    [SerializeField] private GameObject aimingLine;
    [SerializeField] private Text hitsText;

    private int hits;
    private Vector2 currentMousePosition, currentWhiteBallPosition, direction;

    private void LateUpdate()
    {
        var ballPosition = new Vector3(transform.position.x, transform.position.y - 0.6f, transform.position.z);
        hitsText.transform.position = Camera.main.WorldToScreenPoint(ballPosition);
        hitsText.text = hits.ToString();
    }

    private void Update()
    {
        if (!LevelController.isRoundActive)
        {
            pulse.Play();
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

        

        if (!LevelController.isRoundActive)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                aimingLine.SetActive(true);
                aimingLine.transform.rotation = Quaternion.LookRotation(-direction);

                Cursor.visible = false;
            }
        }
    }

    private void OnMouseUp()
    {
        if (!LevelController.CheckIfBallsAreMoving())
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                LaunchBall();

                aimingLine.SetActive(false);
                

                LevelController.NextMove();
            }
            Cursor.visible = true;
        }
    }

    private void LaunchBall()
    {
        energyBall.drag = startDrag;
        LevelController.isRoundActive = true;

        energyBall.AddForce(-direction * forceMultiplier, ForceMode2D.Impulse);

        pulse.Stop();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        hits++;
    }
}