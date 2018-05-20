using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundController : MonoBehaviour
{
    [SerializeField] private GameObject roundPanel;
    [SerializeField] private Text roundText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject nextLevelButton;
    private int finalScore;
    
    

    private void Update()
    {
        

        if (LevelController.GetMove() == LevelController.GetRound())
        {
            if (!LevelController.isRoundActive && !LevelController.CheckIfBallsAreMoving())
            {
                roundPanel.SetActive(true);
            }
        }

        if (roundPanel.activeSelf)
        {
            
            UpdateRoundPanel();
        }
    }

    private void UpdateRoundPanel()
    {
        if (LevelController.GetRound() == 0)
        {
            roundText.text = "Round One";
        }
        else if (LevelController.GetRound() == 1)
        {
            roundText.text = "Round Two";
        }
        else if (LevelController.GetRound() == 2)
        {
            roundText.text = "Last Round";
        }
        else
        {
            finalScore = LevelController.GetScore() * LevelController.GetMultiplier();
            roundText.text = "Final Score: " + finalScore;

            restartButton.SetActive(true);
            nextLevelButton.SetActive(true);
            playButton.SetActive(false);
            
            
            
        }
    }
}