using CardGame.DTO;

namespace CardGame.Facade.Contract
{
    public interface ICardSortFacade
    {
        DTOSortedCards GetCardsInSortedOrder(DTOUnsortedCards unsortedCards);
    }
}
