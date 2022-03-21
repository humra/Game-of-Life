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
    [SerializeField]
    private Transform gameBoard;

    private GameOfLife game;
    private LayerMask gameBoardLayer;

    private void Start()
    {
        game = FindObjectOfType<GameOfLife>();
        Shape_Block temp = new Shape_Block();
        temp.InitializeShape();
        gameBoardLayer = LayerMask.GetMask("Board");
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

    public void AddElement(BlockType blockType)
    {
        Vector3 pos = IsOverGameBoard();
        if(pos == Vector3.zero)
        {
            return;
        }

        Vector2Int roundedPos = new Vector2Int(Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y));

        if(!CheckIfFits(blockType, roundedPos))
        {
            Debug.Log("The given shape will not fit there!");
            return;
        }

        switch(blockType)
        {
            case BlockType.Block:
                game.AddNewBlock(new Shape_Block(), roundedPos);
                break;
            case BlockType.Tub:
                game.AddNewBlock(new Shape_Tub(), roundedPos);
                break;
            case BlockType.Blinker:
                game.AddNewBlock(new Shape_Blinker(), roundedPos);
                break;
            case BlockType.Glider:
                game.AddNewBlock(new Shape_Glider(), roundedPos);
                break;
            default:
                break;
        }
    }

    private bool CheckIfFits(BlockType blockType, Vector2Int position)
    {
        int width;
        int height;

        switch(blockType)
        {
            case BlockType.Block:
                width = BlockTypeDimensions.block.x;
                height = BlockTypeDimensions.block.y;
                break;
            case BlockType.Tub:
                width = BlockTypeDimensions.tub.x;
                height = BlockTypeDimensions.tub.y;
                break;
            case BlockType.Blinker:
                width = BlockTypeDimensions.blinker.x;
                height = BlockTypeDimensions.blinker.y;
                break;
            case BlockType.Glider:
                width = BlockTypeDimensions.glider.x;
                height= BlockTypeDimensions.glider.y;
                break;
            default:
                return false;
        }

        if(position.x - width < 0 || position.y - height < 0 
            || position.x + width >= game.GetWidth() || position.y + height >= game.GetHeight())
        {
            return false;
        }

        return true;
    }

    private Vector3 IsOverGameBoard()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, gameBoardLayer))
        {
            return hit.point;
        }

        return Vector3.zero;
    }
}
