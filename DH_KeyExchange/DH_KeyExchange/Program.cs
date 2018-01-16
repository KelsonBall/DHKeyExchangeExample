using System;
using System.Numerics;
using static System.Console;

namespace DH_KeyExchange
{
    public class Program
    {
        static void Main(string[] args)
        {
            // These values are public
            var dhParams = new DHParams
            {
                N = 32416187719, // a largish prime
                G = Random(), // a big enough number
            };

            // Each actor has their own 'Private Value' which is combined with G and N to create a Public Partial Key
            var Alice = new ExchangeActor
            {
                Name = "Alice",
                ExchangeParams = dhParams,
                // private value A
                // key value AGB
            };

            var Bob = new ExchangeActor
            {
                Name = "Bob",
                ExchangeParams = dhParams
                // private value B
                // key value BGA
            };

            // eavesdropper
            var Eve = new ExchangeActor
            {
                Name = "Eve",
                ExchangeParams = dhParams
                // private value C
                // key value CGA or CGB
            };
            // value combination operation is communicative, so BGA = AGB, but BGA != CGA

            // exchange keys
            Alice.RecievedPartialKey = Bob.PublicPartialKey;
            Bob.RecievedPartialKey = Alice.PublicPartialKey;
            Eve.RecievedPartialKey = Alice.PublicPartialKey;

            WriteLine($"Alice Key: {Alice.Key.Result}");
            WriteLine($"  Bob Key: {Bob.Key.Result}");
            WriteLine($"  Eve Key: {Eve.Key.Result}");
            ReadKey();
        }

        public static readonly Random rng = new Random();
        public static BigInteger Random() => rng.Next(1000000, 1000000000);
    }
}
