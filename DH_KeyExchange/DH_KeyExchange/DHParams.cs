using System.Numerics;

namespace DH_KeyExchange
{
    // Represents public DH parameters
    public class DHParams
    {
        // modulus (must be a large prime or 2*prime)
        public BigInteger N { get; set; }

        // exponential root
        public BigInteger G { get; set; }
    }
}
