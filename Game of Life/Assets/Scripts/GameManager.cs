using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text pauseButtonText;
    [SerializeField]
    private TMP_InputField widthInput;
    [SerializeField]
    private TMP_InputField heightInput;

    private GameOfLife game;

    private void Start()
    {
        game = FindObjectOfType<GameOfLife>();
    }

    public void TogglePause()
    {
        bool isPaused = game.TogglePause();

        if (isPaused)
        {
            pauseButtonText.text = "Resume";
        }
        else
        {
            pauseButtonText.text = "Pause";
        }
    }

    public void ResetGame()
    {
        game.Reset();
    }

    public void ClearGrid()
    {
        game.Clear();
    }

    public void ApplyDimensions()
    {
        int height = int.Parse(heightInput.text);
        int width = int.Parse(widthInput.text);

        game.ChangeDimensions(width, height);
    }
}
