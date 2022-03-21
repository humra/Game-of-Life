
public class Shape_Blinker : Shape_Base
{
    public override bool[,] InitializeShape()
    {
        width = BlockTypeDimensions.blinker.x;
        height = BlockTypeDimensions.blinker.y;

        grid = base.InitializeShape();

        SetLivingSpaces();

        return grid;
    }

    public override void SetLivingSpaces()
    {
        grid[2, 1] = true;
        grid[2, 2] = true;
        grid[2, 3] = true;
    }
}
