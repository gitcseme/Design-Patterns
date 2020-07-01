using System;

namespace TemplateMethodPattern
{
    /**
     * There is an abstract class which has a high level algorithm, a template method which is going to be same for all subclasses.
     * The template method calls a bunch of abstruct methods.
     * The subclasses is going to implement them with some concrete implementations.
     */


    public abstract class Game
    {
        public Game(int numberOfPlayers)
        {
            this.numberOfPlayers = numberOfPlayers;
        }

        public void Run() // The template method.
        {
            Start();
            while (!HaveWinner)
            {
                TakeTurn();
            }
            Console.WriteLine($"Player {WinningPlayer} wins!");
        }

        protected int currentPlayer;
        protected readonly int numberOfPlayers;

        protected abstract void Start();
        protected abstract void TakeTurn();
        protected abstract bool HaveWinner { get; }
        protected abstract int WinningPlayer { get; }
    }

    public class Chess : Game
    {
        public Chess() : base(2)
        {
        }

        private int turn = 1;
        private int maxTurn = 10;

        protected override bool HaveWinner => turn == maxTurn;

        protected override int WinningPlayer => currentPlayer;

        protected override void Start()
        {
            Console.WriteLine($"Starting the chess game with {numberOfPlayers} players");
        }

        protected override void TakeTurn()
        {
            Console.WriteLine($"Turn {turn++} taken by player {currentPlayer}.");
            currentPlayer = (currentPlayer + 1) % numberOfPlayers;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var chess = new Chess();
            chess.Run();
        }
    }
}
