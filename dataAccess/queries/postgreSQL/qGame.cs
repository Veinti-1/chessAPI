namespace chessAPI.dataAccess.queries.postgreSQL;

public sealed class qGame : IQGame
{
    private const string _selectAll = @"
    SELECT id, whites, blacks, turn, winner
    FROM public.game";
    private const string _selectOne = @"
    SELECT id, whites, blacks, turn, winner
    FROM public.game
    WHERE id=@ID";
    private const string _add = @"
    INSERT INTO public.game(whites, blacks, turn,winner)
    VALUES (@WHITES, @BLACKS, @TURN,@WINNER) RETURNING id";
    private const string _delete = @"
    DELETE FROM public.game 
    WHERE id = @ID";
    private const string _update = @"
    UPDATE public.game
    SET whites=@WHITES, blacks=@BLACKS, turn=@TURN, winner=@WINNER
    WHERE id=@ID";

    public string SQLGetAll => _selectAll;

    public string SQLDataEntity => _selectOne;

    public string NewDataEntity => _add;

    public string DeleteDataEntity => _delete;

    public string UpdateWholeEntity => _update;
}