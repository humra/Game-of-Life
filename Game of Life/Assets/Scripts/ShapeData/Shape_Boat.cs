
public class Shape_Boat : Shape_Base
{
    public override bool[,] InitializeShape()
    {
        width = BlockTypeDimensions.boat.x;
        height = BlockTypeDimensions.boat.y;

        grid = base.InitializeShape();

        SetLivingSpaces();

        return grid;
    }

    public override void SetLivingSpaces()
    {
        grid[1, 2] = true;
        grid[1, 3] = true;
        grid[2, 1] = true;
        grid[2, 3] = true;
        grid[3, 2] = true;
    }
}
