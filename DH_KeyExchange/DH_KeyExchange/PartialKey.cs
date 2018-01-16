using System.Numerics;

namespace DH_KeyExchange
{
    // Represents a combination of public 'N' and 'G' values with a private 'A' value
    public class PartialKey
    {
        public DHParams ExchangeParams { get; set; }
        public BigInteger AG { get; set; }
    }
}
