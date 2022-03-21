
public class Shape_Loaf : Shape_Base
{
    public override bool[,] InitializeShape()
    {
        width = BlockTypeDimensions.loaf.x;
        height = BlockTypeDimensions.loaf.y;

        grid = base.InitializeShape();

        SetLivingSpaces();

        return grid;
    }

    public override void SetLivingSpaces()
    {
        grid[1, 3] = true;
        grid[2, 2] = true;
        grid[3, 1] = true;
        grid[4, 2] = true;
        grid[4, 3] = true;
        grid[2, 4] = true;
        grid[3, 4] = true;
    }
}
