namespace GameOfWar
{
    public class Deck
    {
        public static string[] RankNames =
        {
            "2", "3", "4", "5", "6", "7", "8", "9", "10",
            "Jack", "Queen", "King", "Ace"
        };

        public static string[] Suits =
        {
            "Hearts", "Diamonds", "Clubs", "Spades"
        };

        public int Count => _cards.Count;

        private List<Card> _cards;

        public Deck(List<Card>? cards, bool isEmptyDeck)
        {
            if (cards != null && cards.Count > 0)
            {
                _cards = cards;
            }
            else
            {
                _cards = new List<Card>();
                if (!isEmptyDeck)
                {
                    InitializeDeck();
                }
            }
        }

        private void InitializeDeck()
        {
            for (int i = 0; i < RankNames.Length; i++)
            {
                for (int j = 0; j < Suits.Length; j++)
                {
                    _cards.Add(new Card(Suits[j], i));
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            for (int i = _cards.Count - 1; i > 0; i--)
            {
                int randomIndex = random.Next(i + 1);
                Card temp = _cards[i];
                _cards[i] = _cards[randomIndex];
                _cards[randomIndex] = temp;
            }
        }

        public Card CardAtIndex(int index)
        {
            if (index < 0 || index >= _cards.Count)
            {
                throw new IndexOutOfRangeException($"Index {index} is out of range for deck with {_cards.Count} cards");
            }
            return _cards[index];
        }

        public Card PullCardAtIndex(int index)
        {
            Card card = CardAtIndex(index);
            _cards.RemoveAt(index);
            return card;
        }

        public List<Card> PullAllCards()
        {
            List<Card> allCards = new List<Card>(_cards);
            _cards.Clear();
            return allCards;
        }

        public void PushCard(Card card)
        {
            _cards.Add(card);
        }

        public void PushCards(List<Card> cards)
        {
            _cards.AddRange(cards);
        }

        public List<Card> Deal(int numCards)
        {
            if (numCards > _cards.Count)
            {
                throw new IndexOutOfRangeException($"Cannot deal {numCards} cards from a deck with only {_cards.Count} cards");
            }

            List<Card> dealtCards = new List<Card>();
            for (int i = 0; i < numCards; i++)
            {
                dealtCards.Add(_cards[0]);
                _cards.RemoveAt(0);
            }
            return dealtCards;
        }
    }
}