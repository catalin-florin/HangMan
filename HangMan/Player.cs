using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Player
    {
        public string Name { get; private set; } 
        public List<string> GuessedLetters { get; } = new List<string>();

        private int score;
        public int Score
        {
            get { return score; }
            set {
                if(value > 0)
                score = value;
                }
        }

        public Player(string name)
        {
            this.Name = name;
        }
    }
}
