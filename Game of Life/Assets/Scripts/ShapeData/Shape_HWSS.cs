
public class Shape_HWSS : Shape_Base
{
    public override bool[,] InitializeShape()
    {
        width = BlockTypeDimensions.HWSS.x;
        height = BlockTypeDimensions.HWSS.y;

        grid = base.InitializeShape();

        SetLivingSpaces();

        return grid;
    }

    public override void SetLivingSpaces()
    {
        grid[2, 2] = true;
        grid[2, 4] = true;
        grid[3, 5] = true;
        grid[4, 1] = true;
        grid[4, 5] = true;
        grid[5, 1] = true;
        grid[5, 5] = true;
        grid[6, 5] = true;
        grid[7, 5] = true;
        grid[7, 2] = true;
        grid[8, 3] = true;
        grid[8, 4] = true;
        grid[8, 5] = true;
    }
}
