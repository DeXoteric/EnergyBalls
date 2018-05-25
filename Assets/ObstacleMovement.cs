using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private Animator anim;

    Vector2 position;

    private void Update()
    {

        position = gameObject.transform.position;
        
        
        if (LevelController.GetMove() != LevelController.GetRound())
        {
            anim.enabled = true;
        }
        else if (LevelController.GetMove() == LevelController.GetRound() && !LevelController.CheckIfBallsAreMoving())
        {
            anim.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Rigidbody2D colObject = collision.gameObject.GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2((position.x - colObject.transform.position.x) * 10f, position.y - colObject.transform.position.y);
       colObject.AddRelativeForce(direction.normalized, ForceMode2D.Impulse);

        print(direction);
        print(direction.normalized);
        //todo add proper collision to bounce balls
    }
}