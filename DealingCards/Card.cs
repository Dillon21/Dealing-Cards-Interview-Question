using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealingCards {
    public class Card {

        private string value;
        private string suit;

        public Card(string value, string suit) {
            this.value = value;
            this.suit = suit;
        }

        public string Value { get => value; set => this.value = value; }
        public string Suit { get => suit; set => suit = value; }
    }
}
