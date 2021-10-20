public class ClearColorPiece : ClearablePiece
{
    private ColorType color;

    public ColorType Color
    {
        get => color;
        set => color = value;
    }

    public override void Clear()
    {
        base.Clear();

        piece.GridRef.ClearColor(color);
    }
}
