using UnityEngine;

public class RedBallController : DefaultBallController
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private int scorePerHit = 1;
    
    private int hits = 0;

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        energyBall.drag = startDrag;
        LevelController.AddScore(scorePerHit);

        // todo make it better
        hits++;
        print(hits);
        if (hits >= 30)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity, transform);
            hits = 0;
            
        }
    }
}