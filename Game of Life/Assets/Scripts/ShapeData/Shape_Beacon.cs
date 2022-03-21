
public class Shape_Beacon : Shape_Base
{
    public override bool[,] InitializeShape()
    {
        width = BlockTypeDimensions.beacon.x;
        height = BlockTypeDimensions.beacon.y;

        grid = base.InitializeShape();

        SetLivingSpaces();

        return grid;
    }

    public override void SetLivingSpaces()
    {
        grid[1, 3] = true;
        grid[1, 4] = true;
        grid[2, 4] = true;
        grid[3, 1] = true;
        grid[4, 1] = true;
        grid[4, 2] = true;
    }
}
