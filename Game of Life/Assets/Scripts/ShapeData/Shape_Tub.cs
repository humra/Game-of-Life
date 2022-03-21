
public class Shape_Tub : Shape_Base
{
    public override bool[,] InitializeShape()
    {
        width = BlockTypeDimensions.tub.x;
        height = BlockTypeDimensions.tub.y;

        grid = base.InitializeShape();

        SetLivingSpaces();

        return grid;
    }

    public override void SetLivingSpaces()
    {
        grid[2, 1] = true;
        grid[1, 2] = true;
        grid[3, 2] = true;
        grid[2, 3] = true;
    }
}
