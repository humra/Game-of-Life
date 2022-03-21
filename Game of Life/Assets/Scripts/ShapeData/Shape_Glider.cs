
public class Shape_Glider : Shape_Base
{
    public override bool[,] InitializeShape()
    {
        width = BlockTypeDimensions.glider.x;
        height = BlockTypeDimensions.glider.y;

        grid = base.InitializeShape();

        SetLivingSpaces();

        return grid;
    }

    public override void SetLivingSpaces()
    {
        grid[1, 2] = true;
        grid[2, 1] = true;
        grid[3, 1] = true;
        grid[3, 2] = true;
        grid[3, 3] = true;
    }
}
