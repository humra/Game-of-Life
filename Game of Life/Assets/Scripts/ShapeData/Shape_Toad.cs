
public class Shape_Toad : Shape_Base
{
    public override bool[,] InitializeShape()
    {
        width = BlockTypeDimensions.toad.x;
        height = BlockTypeDimensions.toad.y;

        grid = base.InitializeShape();

        SetLivingSpaces();

        return grid;
    }

    public override void SetLivingSpaces()
    {
        grid[1, 2] = true;
        grid[2, 2] = true;
        grid[3, 2] = true;
        grid[2, 3] = true;
        grid[3, 3] = true;
        grid[4, 3] = true;
    }
}
