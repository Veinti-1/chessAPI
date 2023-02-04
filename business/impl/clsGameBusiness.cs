using chessAPI.business.interfaces;
using chessAPI.dataAccess.repositores;
using chessAPI.models.player;

namespace chessAPI.business.impl;

public sealed class clsGameBusiness<TI, TC> : IGameBusiness<TI> 
    where TI : struct, IEquatable<TI>
    where TC : struct
{
   internal readonly IGameRepository<TI, TC> gameRepository;

    public clsGameBusiness(IGameRepository<TI, TC> gameRepository)
    {
        this.gameRepository = gameRepository;
    }

    public async Task<clsGame<TI>> addGame(clsNewGame newGame)
    {
        var x = await gameRepository.addGame(newGame).ConfigureAwait(false);
        return new clsGame<TI>(x, newGame.whites, newGame.blacks, newGame.turn, newGame.winner);
    }

    public async Task<clsGame<TI>> getGame(TI id)
    {
        var x = await gameRepository.getGame(id).ConfigureAwait(false);
        return new clsGame<TI>(x.id, x.whites, x.blacks, x.turn, x.winner);
    }

    public async Task<clsGame<TI>> updateGame(clsGame<TI> updatedGame)
    {
        await gameRepository.updateGame(updatedGame).ConfigureAwait(false);
        return updatedGame;
    }
}