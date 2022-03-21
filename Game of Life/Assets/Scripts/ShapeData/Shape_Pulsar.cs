
public class Shape_Pulsar : Shape_Base
{
    public override bool[,] InitializeShape()
    {
        width = BlockTypeDimensions.pulsar.x;
        height = BlockTypeDimensions.pulsar.y;

        grid = base.InitializeShape();

        SetLivingSpaces();

        return grid;
    }

    public override void SetLivingSpaces()
    {
        grid[2, 4] = true;
        grid[2, 5] = true;
        grid[2, 6] = true;
        grid[2, 10] = true;
        grid[2, 11] = true;
        grid[2, 12] = true;
        grid[7, 4] = true;
        grid[7, 5] = true;
        grid[7, 6] = true;
        grid[7, 10] = true;
        grid[7, 11] = true;
        grid[7, 12] = true;
        grid[9, 4] = true;
        grid[9, 5] = true;
        grid[9, 6] = true;
        grid[9, 10] = true;
        grid[9, 11] = true;
        grid[9, 12] = true;
        grid[14, 4] = true;
        grid[14, 5] = true;
        grid[14, 6] = true;
        grid[14, 10] = true;
        grid[14, 11] = true;
        grid[14, 12] = true;

        grid[4, 2] = true;
        grid[5, 2] = true;
        grid[6, 2] = true;
        grid[10, 2] = true;
        grid[11, 2] = true;
        grid[12, 2] = true;
        grid[4, 7] = true;
        grid[5, 7] = true;
        grid[6, 7] = true;
        grid[10, 7] = true;
        grid[11, 7] = true;
        grid[12, 7] = true;
        grid[4, 9] = true;
        grid[5, 9] = true;
        grid[6, 9] = true;
        grid[10, 9] = true;
        grid[11, 9] = true;
        grid[12, 9] = true;
        grid[4, 14] = true;
        grid[5, 14] = true;
        grid[6, 14] = true;
        grid[10, 14] = true;
        grid[11, 14] = true;
        grid[12, 14] = true;
    }
}
