namespace tic_tac_toe
{
    class Player
    {
        public string Symbol { get; set; }
        public int Score { get; set; }
        public string Name { get; set; }

        public Player(string symbol, string name, int score = 0)
        {
            Symbol = symbol;
            Name = name;
            Score = score;
        }

    }
}
