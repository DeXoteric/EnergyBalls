using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private void Start()
    {
    }

    private void Update()
    {
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
        //todo add proper collision to bounce balls
    }
}