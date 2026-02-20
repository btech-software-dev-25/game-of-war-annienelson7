namespace GameOfWar
{
    public class Card
    {
        public string Suit { get; set; }
        public int Rank { get; set; }
        public Card(string suit, int rank)
        {
            Suit = suit;
            Rank = rank;
        }
        
        public static bool operator >(Card c1, Card c2)
        {
            return c1.Rank > c2.Rank;
        }
        public static bool operator <(Card c1, Card c2)
        {
            return c1.Rank < c2.Rank;
        }
        public string RankString()
        {
            return Rank switch
            {
                0 => "2",
                1 => "3",
                2 => "4",
                3 => "5",
                4 => "6",
                5 => "7",
                6 => "8",
                7 => "9",
                8 => "10",
                9 => "Jack",
                10 => "Queen",
                11 => "King",
                12 => "Ace",
                _ => "Unknown"
            };
        }

        
    }
}