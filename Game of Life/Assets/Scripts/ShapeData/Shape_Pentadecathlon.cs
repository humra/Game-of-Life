
public class Shape_Pentadecathlon : Shape_Base
{
    public override bool[,] InitializeShape()
    {
        width = BlockTypeDimensions.pentadecathlon.x;
        height = BlockTypeDimensions.pentadecathlon.y;

        grid = base.InitializeShape();

        SetLivingSpaces();

        return grid;
    }

    public override void SetLivingSpaces()
    {
        grid[4, 6] = true;
        grid[4, 11] = true;
        grid[6, 6] = true;
        grid[6, 11] = true;
        grid[5, 4] = true;
        grid[5, 5] = true;
        grid[5, 7] = true;
        grid[5, 8] = true;
        grid[5, 9] = true;
        grid[5, 10] = true;
        grid[5, 12] = true;
        grid[5, 13] = true;
    }
}
