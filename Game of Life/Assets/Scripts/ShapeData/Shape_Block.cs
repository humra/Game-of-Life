
public class Shape_Block : Shape_Base
{
    public override bool[,] InitializeShape()
    {
        width = BlockTypeDimensions.block.x;
        height = BlockTypeDimensions.block.y;

        grid = base.InitializeShape();

        SetLivingSpaces();

        return grid;
    }

    public override void SetLivingSpaces()
    {
        grid[1, 1] = true;
        grid[1, 2] = true;
        grid[2, 1] = true;
        grid[2, 2] = true;
    }
}
