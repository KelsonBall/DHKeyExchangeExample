using System.Numerics;

namespace DH_KeyExchange
{
    public class ExchangeActor
    {
        public string Name { get; set; }
        public DHParams ExchangeParams { get; set; }

        private readonly BigInteger PrivateValue = Program.Random();
        public FinalKey Key { get; set; }

        private PartialKey _recievedPartialKey;
        public PartialKey RecievedPartialKey
        {
            get => _recievedPartialKey;
            set
            {
                _recievedPartialKey = value;
                Key = new FinalKey(PrivateValue)
                {
                    Partial = value,
                };
            }
        }

        private PartialKey _publicPartialKey;
        public PartialKey PublicPartialKey => _publicPartialKey ?? (_publicPartialKey = generatePublicPartialKey());

        private PartialKey generatePublicPartialKey()
        {
            return new PartialKey
            {
                ExchangeParams = ExchangeParams,
                AG = BigInteger.ModPow(ExchangeParams.G, PrivateValue, ExchangeParams.N),
            };
        }
    }
}
