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
            case BlockType.Beehive:
                game.AddNewBlock(new Shape_Beehive(), roundedPos);
                break;
            case BlockType.Toad:
                game.AddNewBlock(new Shape_Toad(), roundedPos);
                break;
            case BlockType.Loaf:
                game.AddNewBlock(new Shape_Loaf(), roundedPos);
                break;
            case BlockType.Boat:
                game.AddNewBlock(new Shape_Boat(), roundedPos);
                break;
            case BlockType.Beacon:
                game.AddNewBlock(new Shape_Beacon(), roundedPos);
                break;
            case BlockType.Pulsar:
                game.AddNewBlock(new Shape_Pulsar(), roundedPos);
                break;
            case BlockType.Pentadecathlon:
                game.AddNewBlock(new Shape_Pentadecathlon(), roundedPos);
                break;
            case BlockType.LWSS:
                game.AddNewBlock(new Shape_LWSS(), roundedPos);
                break;
            case BlockType.MWSS:
                game.AddNewBlock(new Shape_MWSS(), roundedPos);
                break;
            case BlockType.HWSS:
                game.AddNewBlock(new Shape_HWSS(), roundedPos);
                break;
            default:
                break;
        }
    }

    private bool CheckIfFits(BlockType blockType, Vector2Int position)
    {
        int width = 0;
        int height = 0;

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
            case BlockType.Beehive:
                width = BlockTypeDimensions.beehive.x;
                height = BlockTypeDimensions.beehive.y;
                break;
            case BlockType.Toad:
                width = BlockTypeDimensions.toad.x;
                height = BlockTypeDimensions.toad.y;
                break;
            case BlockType.Loaf:
                width = BlockTypeDimensions.loaf.x;
                height = BlockTypeDimensions.loaf.y;
                break;
            case BlockType.Boat:
                width = BlockTypeDimensions.boat.x;
                height = BlockTypeDimensions.boat.y;
                break;
            case BlockType.Beacon:
                width = BlockTypeDimensions.beacon.x;
                height = BlockTypeDimensions.beacon.y;
                break;
            case BlockType.Pulsar:
                width = BlockTypeDimensions.pulsar.x;
                height = BlockTypeDimensions.pulsar.y;
                break;
            case BlockType.Pentadecathlon:
                width = BlockTypeDimensions.pentadecathlon.x;
                height = BlockTypeDimensions.pentadecathlon.y;
                break;
            case BlockType.LWSS:
                width = BlockTypeDimensions.LWSS.x;
                height = BlockTypeDimensions.LWSS.y;
                break;
            case BlockType.MWSS:
                width = BlockTypeDimensions.MWSS.x;
                height = BlockTypeDimensions.MWSS.y;
                break;
            case BlockType.HWSS:
                width = BlockTypeDimensions.HWSS.x;
                height = BlockTypeDimensions.HWSS.y;
                break;
            default:
                return false;
        }

        if(position.x + width >= game.GetWidth() || position.y + height >= game.GetHeight())
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
