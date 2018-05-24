using UnityEngine;
using UnityEngine.UI;

public class RedBallController : DefaultBallController
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private int scorePerHit = 1;
    [SerializeField] private Text hitsText;
    

    private int hits = 30;

    private void LateUpdate()
    {
        var ballPosition = new Vector3(transform.position.x, transform.position.y - 0.6f, transform.position.z);
        hitsText.transform.position = Camera.main.WorldToScreenPoint(ballPosition);
        hitsText.text = hits.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        energyBall.drag = startDrag;
        LevelController.AddScore(scorePerHit);

        // todo make it better
        hits--;
        
        if (hits <= 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            hits = 30;
            
        }
    }
}