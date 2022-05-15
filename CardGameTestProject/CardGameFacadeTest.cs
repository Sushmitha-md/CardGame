using CardGame.DTO;
using CardGame.Facade.Implementation;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CardGameTestProject
{
    [TestClass]
    public class CardGameFacadeTest
    {
        private readonly ILogger<CardSortFacade> _logger;
        [TestMethod]
        public void GetCardsInSortedOrder_WithValidInput_ReturnsSortedList()
        {
            CardSortFacade facade = new CardSortFacade(_logger);
            var cards = MockDataSet.MockData.MockInputData();
            var sortedcards = MockDataSet.MockData.ExpectedOutput();
            DTOUnsortedCards unsortedCards = new DTOUnsortedCards();
            unsortedCards.UnsortedCards = cards;
            var response = facade.GetCardsInSortedOrder(unsortedCards);
            Assert.IsTrue(response.SortedCards.Count == cards.Count, "Card count matched");
            for (int i = 0; i < sortedcards.Count; i++)
            {
                Assert.IsTrue(response.SortedCards[i].Equals(sortedcards[i]), "Sorted sequence matches the expected sorted sequence");
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetCardsInSortedOrder_WithNoInput_ReturnsSortedList()
        {
            CardSortFacade facade = new CardSortFacade(_logger);
            var response = facade.GetCardsInSortedOrder(null);
        }

    }
}