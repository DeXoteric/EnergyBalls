using UnityEngine;

public class NextRoundOnClick : MonoBehaviour
{
    public void NextRound()
    {
        LevelController.NextRound();
        LevelController.isRoundActive = false;

       
    }
}