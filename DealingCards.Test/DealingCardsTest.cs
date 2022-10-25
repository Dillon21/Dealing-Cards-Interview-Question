using NUnit.Framework;
using System.Security.Cryptography;

namespace DealingCards.Tests{

    [TestFixture]

    public class DealingCardsTest {

        private Deal sut;

        [SetUp] public void SetUp() { 
            sut = new Deal();
        }

        [Test]
        public void AddPlayers_GetPlayersFromInput_ReturnPlayers(int input, int ExpectedResult){
            ;
        }

        [Test]
        public void AddPlayers_GetPlayersFromInput_ReturnException(){

        }

        public List<int> AddPlayers(int players) {
            var playerList = new List<int>();
            do {
                Console.WriteLine("How many players?");
                playerList = Enumerable.Range(1,players).ToList();
                if (playerList.Count > 8 | playerList.Count == 0) {
                    throw new Exception("Player count must be between 1 and 8");
                }
            } while (playerList.Count > 8 | playerList.Count == 0);

            return playerList;
        }

        [Test]
        public void ReadTxt_GetTextLineByLine_ReturnTextInTxtFile() {
            var line = File.ReadAllLines("cards.txt");

            Assert.NotNull(line);
            Assert.Greater(line.Length, 0);

        }

    }
}