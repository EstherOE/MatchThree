using UnityEngine;

public class GamePiece : MonoBehaviour
{
    public int score;

    private int  x;
    private int  y;

    public int X
    {
        get =>  x;
        set { if (IsMovable()) {  x = value; } }
    }

    public int Y
    {
        get =>  y;
        set { if (IsMovable()) {  y = value; } }
    }
    
    private PieceType  type;

    public PieceType Type => type;

    private Grid  grid;

    public Grid GridRef =>  grid;

    private MovablePiece  movableComponent;

    public MovablePiece MovableComponent =>  movableComponent;

    private ColorPiece  colorComponent;

    public ColorPiece ColorComponent =>  colorComponent;

    private ClearablePiece  clearableComponent;

    public ClearablePiece ClearableComponent =>  clearableComponent;

    private void Awake()
    {
         movableComponent = GetComponent<MovablePiece>();
         colorComponent = GetComponent<ColorPiece>();
         clearableComponent = GetComponent<ClearablePiece>();
    }

    public void Init(int x, int y, Grid grid, PieceType type)
    {
        this.x = x;
        this.y = y;
        this.grid = grid;
        this.type = type;
    }

    private void OnMouseEnter()
    {
         grid.EnterPiece(this);
    }

    private void OnMouseDown()
    {
         grid.PressPiece(this);
    }

    private void OnMouseUp()
    {
         grid.ReleasePiece();
    }

    public bool IsMovable()
    {
        return  movableComponent != null;
    }

    public bool IsColored()
    {
        return  colorComponent != null;
    }

    public bool IsClearable()
    {
        return  clearableComponent != null;
    }

}
