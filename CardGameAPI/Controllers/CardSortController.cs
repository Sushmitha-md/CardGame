using CardGame.DTO;
using CardGame.Facade.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardSortController : ControllerBase
    {
        private readonly ILogger<CardSortController> _logger;
        private readonly ICardSortFacade _cardSortFacade;
        public CardSortController(ILogger<CardSortController> logger, ICardSortFacade cardSortFacade)
        {
            _logger = logger;
            _cardSortFacade = cardSortFacade;
        }

        [HttpPost("sort",Name = "GetCardsInSortedOrder")]
        public IActionResult GetCardsInSortedOrder(List<string> cards)
        {
            DTOUnsortedCards unsortedCards = new DTOUnsortedCards();
            unsortedCards.UnsortedCards = cards;
            var sortedCards = _cardSortFacade.GetCardsInSortedOrder(unsortedCards);
            return Ok(sortedCards);
        }
    }
}
