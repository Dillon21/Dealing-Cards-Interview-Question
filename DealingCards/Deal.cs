using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DealingCards {

    public class Deal{

        List<int> playerList;
        List<Card> cards = new List<Card>();
        Dictionary<int, List<Card>> playerCardPairs = new Dictionary<int, List<Card>>();



        public Dictionary<int, List<Card>> DealCards() {

            do {
                Console.WriteLine("How many players?");
                playerList = Enumerable.Range(1, int.Parse(Console.ReadLine())).ToList();
                if (playerList.Count > 8 | playerList.Count == 0) {
                    Console.WriteLine("Player count must be between 1 and 8");
                }
            } while (playerList.Count > 8 | playerList.Count == 0);

            foreach (var line in File.ReadAllLines("cards.txt")){
                if(!line.Equals("Joker")){
                var values = line.Split(' ');
                cards.Add(new Card(values[0], values[1]));
                }
            }

            Random rand = new Random();
            var shuffledCards = cards.OrderBy(_ => rand.Next()).ToList();

            var handSize = cards.Count() / playerList.Count;

            foreach(var player in playerList){
                var hand = shuffledCards.Skip(handSize * (player - 1))
                    .Take(handSize)
                    .ToList();
                playerCardPairs.Add(player, hand);  
            }

            foreach(var key in playerCardPairs.Keys) {
                Console.WriteLine("\nCards in player " + key + " Hand\nHand Size: " + playerCardPairs[key].Count);

                foreach (var card in playerCardPairs[key]) {
                    Console.WriteLine(card.Value + " " + card.Suit);
                    cards.Remove(card);
                }
            }

            if(cards.Count > 0){
            Console.WriteLine("\nLeft over cards");
            printPlayerCards(0, cards);
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

            try{
                deal.DealCards();
            }catch (Exception e){
                Console.WriteLine(e.Message);
                deal.DealCards();
            }
            
        }
    }
    }

