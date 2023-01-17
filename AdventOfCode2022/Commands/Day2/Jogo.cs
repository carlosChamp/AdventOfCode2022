namespace AdventOfCode2022.Commands.Day2
{
    enum opcoes
    {
        Rock = 0,
        Paper = 1,
        Scissors = 2,
    }

    enum gameResults
    {
        Lose = 0,
        Draw = 3,
        Win = 6
    }

    internal class Jogo
    {
        public opcoes enemyChoice { get; set; }
        public opcoes myChoice { get; set; }
        public opcoes myChoiceByElfSuggestion { get; set; }
        public gameResults NeedTo { get; set; }

        public Jogo(string line)
        {
            var arrOpcoes = line.Split(" ");
            enemyChoice = InterpretCryptToEnum(arrOpcoes[0]);
            myChoice = InterpretCryptToEnum(arrOpcoes[1]);
            NeedTo = InterpretNeededResult(arrOpcoes[1]);
            myChoiceByElfSuggestion = CalculateElvesSuggestion();
        }

        private opcoes CalculateElvesSuggestion()
        {
            if (NeedTo == gameResults.Draw)
                return enemyChoice;

            if (NeedTo == gameResults.Win)
                return (opcoes)(((int)enemyChoice + 1) % 3);

            if (NeedTo == gameResults.Lose)
                return (opcoes)(((int)enemyChoice + 2) % 3);

            throw new ArgumentException("Parametros incorretos.");
        }

        internal int EvaluateWithMyChoice()
        {
            return (int)Calculate(myChoice, enemyChoice) + (int)myChoice + 1;
        }
        internal int EvaluateWithElvesChoice()
        {
            return (int)Calculate(myChoiceByElfSuggestion, enemyChoice) + (int)myChoiceByElfSuggestion + 1;
        }

        internal static gameResults Calculate(opcoes myChoice, opcoes enemyChoice)
        {
            if (enemyChoice == myChoice)
                return gameResults.Draw;

            if (myChoice == opcoes.Rock && enemyChoice == opcoes.Scissors)
                return gameResults.Win;

            if (enemyChoice == opcoes.Rock && myChoice == opcoes.Scissors)
                return gameResults.Lose;


            return (int)myChoice > (int)enemyChoice ? gameResults.Win : gameResults.Lose;
        }

        static opcoes InterpretCryptToEnum(string encryptedChar)
        {
            switch (encryptedChar)
            {
                case "A":
                case "X":
                    return opcoes.Rock;
                case "B":
                case "Y":
                    return opcoes.Paper;
                case "C":
                case "Z":
                    return opcoes.Scissors;
                default:
                    throw new ArgumentException("Formato da string incorreto");
            }
        }

        static gameResults InterpretNeededResult(string encryptedChar)
        {
            switch (encryptedChar)
            {
                case "X":
                    return gameResults.Lose;
                case "Y":
                    return gameResults.Draw;
                case "Z":
                    return gameResults.Win;
                default:
                    throw new ArgumentException("Formato da string incorreto");
            }
        }
    }

}
