public class LevelObstacles : Level
{

    public int numMoves;
    public PieceType[] obstacleTypes;

    private const int ScorePerPieceCleared = 1000;
    
    private int movesUsed = 0;
    private int numObstaclesLeft;

    private void Start ()
	{
	    type = LevelType.OBSTACLE;

	    for (int i = 0; i < obstacleTypes.Length; i++)
	    {
	        numObstaclesLeft += grid.GetPiecesOfType(obstacleTypes[i]).Count;
	    }

        hud.SetLevelType(type);
        hud.SetScore(currentScore);
        hud.SetTarget(numObstaclesLeft);
        hud.SetRemaining(numMoves);
	}

    public override void OnMove()
    {
        movesUsed++;

        hud.SetRemaining(numMoves - movesUsed);

        if (numMoves - movesUsed == 0 && numObstaclesLeft > 0)
        {
            GameLose();
        }
    }

    public override void OnPieceCleared(GamePiece piece)
    {
        base.OnPieceCleared(piece);

        for (int i = 0; i < obstacleTypes.Length; i++)
        {
            if (obstacleTypes[i] != piece.Type) continue;
            
            numObstaclesLeft--;
            hud.SetTarget(numObstaclesLeft);
            if (numObstaclesLeft != 0) continue;
            
            currentScore += ScorePerPieceCleared * (numMoves - movesUsed);
            hud.SetScore(currentScore);
            GameWin();
        }
    }
}
