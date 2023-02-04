using chessAPI.dataAccess.models;
using chessAPI.models.player;

namespace chessAPI.dataAccess.repositores;

public interface IGameRepository<TI, TC>
        where TI : struct, IEquatable<TI>
        where TC : struct
{
    Task<TI> addGame(clsNewGame player);
    Task<clsGameEntityModel<TI, TC>> getGame(TI id);
    Task updateGame(clsGame<TI> updatedGame);
    Task deleteGame(TI id);
}