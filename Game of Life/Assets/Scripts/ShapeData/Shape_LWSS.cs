
public class Shape_LWSS : Shape_Base
{
    public override bool[,] InitializeShape()
    {
        width = BlockTypeDimensions.LWSS.x;
        height = BlockTypeDimensions.LWSS.y;

        grid = base.InitializeShape();

        SetLivingSpaces();

        return grid;
    }

    public override void SetLivingSpaces()
    {
        grid[2, 3] = true;
        grid[2, 5] = true;
        grid[3, 2] = true;
        grid[4, 2] = true;
        grid[5, 2] = true;
        grid[6, 2] = true;
        grid[6, 3] = true;
        grid[6, 4] = true;
        grid[5, 5] = true;
    }
}
