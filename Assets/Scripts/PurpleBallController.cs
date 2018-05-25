using UnityEngine;
using UnityEngine.UI;

public class PurpleBallController : DefaultBallController
{
    [SerializeField] private int multiplierPerHit = 1;
    [SerializeField] private Text multiplierText;

    private void LateUpdate()
    {
        var ballPosition = new Vector3(transform.position.x, transform.position.y - 0.6f, transform.position.z);
        multiplierText.transform.position = Camera.main.WorldToScreenPoint(ballPosition);
        multiplierText.text = "x" + LevelController.GetMultiplier().ToString();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        if (collision.gameObject.tag == "Ball")
        {
            LevelController.AddMultiplier(multiplierPerHit);
        }
    }
}