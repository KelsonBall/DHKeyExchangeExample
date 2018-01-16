using System.Numerics;

namespace DH_KeyExchange
{
    // combines a private 'B' value with public 'N' and 'AG' values
    public class FinalKey
    {
        private readonly BigInteger _privateValue;
        public FinalKey(BigInteger privateKey)
        {
            _privateValue = privateKey;
        }

        private PartialKey _partial;
        public PartialKey Partial
        {
            get => _partial;
            set
            {
                _partial = value;
                // calculates the 'Result' value when a Partial key is set
                Result = BigInteger.ModPow(value.AG, _privateValue, value.ExchangeParams.N);
            }
        }

        public BigInteger Result { get; private set; }
    }
}
