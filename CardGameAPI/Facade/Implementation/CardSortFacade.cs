using CardGame.DTO;
using CardGame.DTO.Constants;
using CardGame.Facade.Contract;

namespace CardGame.Facade.Implementation
{
    public class CardSortFacade : ICardSortFacade
    {
        private readonly ILogger<CardSortFacade> _logger;       

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        public CardSortFacade(ILogger<CardSortFacade> logger)
        {
            _logger = logger;
        }

        public DTOSortedCards GetCardsInSortedOrder(DTOUnsortedCards unsortedCards)
        {
            DTOSortedCards sortedCards = new DTOSortedCards();
            try
            {
                sortedCards.SortedCards = new List<string>();
                var priortyCards = GetGroupedUnsortedCards(CardConstants.PriorityCard, unsortedCards.UnsortedCards);
                var diamondCards = GetGroupedUnsortedCards(CardConstants.DiamondCard, unsortedCards.UnsortedCards);
                var spadeCards = GetGroupedUnsortedCards(CardConstants.SpadeCard, unsortedCards.UnsortedCards);
                var clubCards = GetGroupedUnsortedCards(CardConstants.ClubCard, unsortedCards.UnsortedCards);
                var heartCards = GetGroupedUnsortedCards(CardConstants.HeartCard, unsortedCards.UnsortedCards);
                if (priortyCards.Count > 0)
                {
                    var sortedPriorityCards = SortPriorityCards(priortyCards);
                    sortedCards.SortedCards.AddRange(sortedPriorityCards);
                }
                if (diamondCards.Count > 0)
                {
                    var sortedDiamondCards = SortNormalCards(diamondCards, CardConstants.DiamondCard);
                    sortedCards.SortedCards.AddRange(sortedDiamondCards);
                }
                if (spadeCards.Count > 0)
                {
                    var sortedSpadeCards = SortNormalCards(spadeCards, CardConstants.SpadeCard);
                    sortedCards.SortedCards.AddRange(sortedSpadeCards);
                }
                if (clubCards.Count > 0)
                {
                    var sortedClubCards = SortNormalCards(clubCards, CardConstants.ClubCard);
                    sortedCards.SortedCards.AddRange(sortedClubCards);
                }
                if (heartCards.Count > 0)
                {
                    var sortedHeartCards = SortNormalCards(heartCards, CardConstants.HeartCard);
                    sortedCards.SortedCards.AddRange(sortedHeartCards);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError("Inner Exception: " + ex.InnerException?.ToString());
                _logger.LogError("Stacktrace Exception: " + ex.StackTrace?.ToString());
            }
            return sortedCards;

        }

        private List<string> GetGroupedUnsortedCards(string cardType, List<string> unsortedCards)
        {
            return unsortedCards.FindAll(x => x.EndsWith(cardType));
        }

        private List<string> SortPriorityCards(List<string> priorityCards)
        {
            List<string> response = new List<string>();
            if (priorityCards.Contains(CardConstants.DrawFour))
                response.Add(CardConstants.DrawFour);
            if (priorityCards.Contains(CardConstants.DrawTwo))
                response.Add(CardConstants.DrawTwo);
            if (priorityCards.Contains(CardConstants.Swap))
                response.Add(CardConstants.Swap);
            if (priorityCards.Contains(CardConstants.Pause))
                response.Add(CardConstants.Pause);
            if (priorityCards.Contains(CardConstants.Reverse))
                response.Add(CardConstants.Reverse);
            return response;
        }

        private List<string> SortNormalCards(List<string> normalCards, string cardType)
        {
            List<string> response = new List<string>();
            // seperate number cards from J, Q, K, A
            List<string> numbercards = normalCards.Where(x => x.Any(char.IsDigit)).OrderBy(x => x.Length).ThenBy(x => x).ToList();
            if (numbercards.Count > 0)
            {
                response.AddRange(numbercards);
            }
            List<string> specialCards = normalCards.Except(numbercards).ToList();
            if (specialCards.Count > 0)
            {
                if (specialCards.Any(x => x.StartsWith(CardConstants.Jack)))
                    response.Add(CardConstants.Jack + cardType);
                if (specialCards.Any(x => x.StartsWith(CardConstants.Queen)))
                    response.Add(CardConstants.Queen + cardType);
                if (specialCards.Any(x => x.StartsWith(CardConstants.King)))
                    response.Add(CardConstants.King + cardType);
                if (specialCards.Any(x => x.StartsWith(CardConstants.Ace)))
                    response.Add(CardConstants.Ace + cardType);
            }
            return response;
        }
    }
}
