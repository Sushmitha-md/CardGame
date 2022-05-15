Consider that you are playing an imaginary Cards game among your friends. In that game whatever the deck of cards you have got in your hand you have to sort that card in the Given Order & to win the game you have to finish the cards of your hand at first among your friends by reducing 1 card in each turn.
 At the time of playing, you thought to create an API in C# (.NET CORE or your most proficient language) that you will simulate the sorting of the deck of card that you have received.  
The cards will be given to you in a random order, and you are to sort the cards through first in Special Cards Given Priority Order then remaining normal cards through ace within the suit and then the suits in specialCards(T), diamond(D), spades(S), clubs(C), hearts(H) order.
Given Priority order -> 4T, 2T, ST, PT, RT
The cards are represented as a string in the following format
2D - two of diamonds
3D - three of diamonds
...
10D - ten of diamonds
JD - jack of diamonds
QD - queen of diamonds
KD - king of diamonds
AD - ace of diamonds
Special Cards are mentioned below
4T – Take four cards from deck
2T – Take two cards from deck
ST – Swap your hands
PT – Pause your turn for 1 time
RT – Reverse turn

The cards will be given to you as a list of strings, e.g. in C# it would be List<String> cards = new List<String>(new string[] {​​​ "3C", "JS", "2D", “PT”, "10H", "KH", "8S", “4T”, "AC", "4H", “RT” }​​​​​​​​​​)
In the end, the output of the sorted cards will be 4T, PT, RT, 2D, 8S, JS, 3C, AC, 4H, 10H, KH.

  
Repository created to address the particular problem.
Using .Net 6, angular 13;
