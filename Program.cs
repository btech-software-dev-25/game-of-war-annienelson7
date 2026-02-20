using GameOfWar;

GameState state = new GameState();
state.CardDeck.Shuffle();
state.PlayerDeck.PushCards(state.CardDeck.Deal(26));
state.ComputerDeck.PushCards(state.CardDeck.Deal(26));

static bool PlayCards(GameState state, int playerCardIndex)
{
    Card playerCard = state.PlayerDeck.PullCardAtIndex(playerCardIndex);
    Card computerCard = state.ComputerDeck.PullCardAtIndex(0);

    List<Card> cardsToAdd = new List<Card> { playerCard, computerCard };
    cardsToAdd.AddRange(state.TableDeck.PullAllCards());

    if (playerCard > computerCard)
    {
        state.PlayerDeck.PushCards(cardsToAdd);
    }
    else if (computerCard > playerCard)
    {
        state.ComputerDeck.PushCards(cardsToAdd);
    }
    else
    {
        state.TableDeck.PushCards(cardsToAdd);
    }

    if (state.ComputerDeck.Count == 0)
    {
        state.Winner = "Player";
    }
    else if (state.PlayerDeck.Count == 0)
    {
        state.Winner = "Computer";
    }

    return true;
}

Lib.RunGame(state, PlayCards);

namespace GameOfWar
{
    public class GameState
    {
        public Deck CardDeck { get; set; }
        public Deck PlayerDeck { get; set; }
        public Deck ComputerDeck { get; set; }
        public Deck TableDeck { get; set; }
        public string Winner { get; set; }

        public GameState()
        {
            Winner = string.Empty;
            CardDeck = new Deck(null, false);
            PlayerDeck = new Deck(null, true);
            ComputerDeck = new Deck(null, true);
            TableDeck = new Deck(null, true);
        }
    }
}