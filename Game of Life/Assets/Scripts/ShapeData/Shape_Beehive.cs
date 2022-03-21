
public class Shape_Beehive : Shape_Base
{
    public override bool[,] InitializeShape()
    {
        width = BlockTypeDimensions.beehive.x;
        height = BlockTypeDimensions.beehive.y;

        grid = base.InitializeShape();

        SetLivingSpaces();

        return grid;
    }

    public override void SetLivingSpaces()
    {
        grid[2, 1] = true;
        grid[3, 1] = true;
        grid[1, 2] = true;
        grid[4, 2] = true;
        grid[2, 3] = true;
        grid[3, 3] = true;
    }
}
