using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    public class Card 
    {
        private string stringVal; 
        private string suit;
        private int val;

        public Card(string stringVal, string suit, int val)
        {
            this.stringVal = stringVal;
            this.suit = suit;
            this.val = val;
        }

        public string StringVal
        {
            get { return this.stringVal; }
        }

        public string Suit
        {
            get { return this.suit; }
        }

        public int Val
        {
            get { return this.val; }
        }
    }

    public class Deck 
    {
        public List<Card> Cards;
        public Deck() 
        {
            
            this.reset();
        }
        public Card deal()
        {
            // Return the top card of the deck and removes it from the list
            Card topCard = this.Cards[this.Cards.Count-1];
            
            System.Console.WriteLine($"Dealing a {topCard.StringVal} of {topCard.Suit}");
            Cards.Remove(topCard);
            return topCard;
        }

        public void reset()
        {

            Cards = new List<Card>();
            string[] stringVals = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
            string[] suits = {"Spades", "Hearts", "Diamond", "Club"};

            foreach(string suit in suits)
            {
                for(int i=0; i<stringVals.Length; i++) 
                {
                    Card nameCard = new Card(stringVals[i], suit, i+1);
                    Cards.Add(nameCard);
                }
            }
        }

        public void shuffle()
        {
            Random rand = new Random();
           
            for(int i=0; i<this.Cards.Count; i++) 
            {
                int val = rand.Next(0, Cards.Count);
                Card selection = this.Cards[val];
                this.Cards[val] = this.Cards[i];
                this.Cards[i] = selection;
            }
        }

    }

    public class Player 
    {
        private string name;
        private List<Card> hand; 

        public Player(string name)
        {
            this.name = name;
            hand = new List<Card>();
        }

        public Card draw(Deck deck) 
        {
            Card newCard = deck.deal();
            hand.Add(newCard);
            System.Console.WriteLine($"{this.name} drew {newCard.StringVal} of {newCard.Suit}");
            return newCard;
        }

        public Card discard(int drop)        
        {
            Card discarded = this.hand[drop];
            System.Console.WriteLine($"Discarding {this.hand[drop].StringVal} of {this.hand[drop].Suit}");
            this.hand.RemoveAt(drop);
            return discarded;
        }

    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck1 = new Deck();
            deck1.reset();
            Player teng = new Player("Teng");
            
            System.Console.WriteLine("Shuffling...");
            deck1.shuffle();
            teng.draw(deck1);
            teng.draw(deck1);
            teng.discard(1);
            
        }
    }
}
