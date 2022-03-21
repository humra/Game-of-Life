
public class Shape_MWSS : Shape_Base
{
    public override bool[,] InitializeShape()
    {
        width = BlockTypeDimensions.MWSS.x;
        height = BlockTypeDimensions.MWSS.y;

        grid = base.InitializeShape();

        SetLivingSpaces();

        return grid;
    }

    public override void SetLivingSpaces()
    {
        grid[2, 4] = true;
        grid[2, 6] = true;
        grid[3, 3] = true;
        grid[4, 3] = true;
        grid[5, 3] = true;
        grid[6, 3] = true;
        grid[7, 3] = true;
        grid[4, 7] = true;
        grid[6, 6] = true;
        grid[7, 5] = true;
        grid[7, 4] = true;
    }
}
