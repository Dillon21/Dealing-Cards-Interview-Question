using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DealingCards {

    public class Deal{

        public Dictionary<int, List<Card>> DealCards(){

        
            Console.WriteLine("How many players?");
            //string playerCount = Console.ReadLine();

            List<Card> cards = new List<Card>();
            Dictionary<int, List<Card>> playerCardPairs = new Dictionary<int, List<Card>>();

            foreach (var line in File.ReadAllLines("cards.txt")){
                if(!line.Equals("Joker")){
                var values = line.Split(' ');
                cards.Add(new Card(values[0], values[1]));
            }

            }

            

            return playerCardPairs;

        }



            
        public void printPlayerCards(int player, List<Card> cards){
            cards.ForEach(card => {
                Console.WriteLine(card.Value + " " + card.Suit);
            });
        }

        public static void Main(string[] args) {
            Deal deal = new Deal();
            deal.DealCards();
        }
    }

}