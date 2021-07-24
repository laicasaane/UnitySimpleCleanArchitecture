namespace SCA
{
    // Gateway
    // Gateway can't depend on View, Presenter, Usecase
    // Gateway can't inherit Monobehaviour
    public class GatewayCountDB : IGatewayCountDB
    {
        private readonly Count CountA;
        private readonly Count CountB;

        public GatewayCountDB()
        {
            this.CountA = new Count()
            {
                Type = CountType.A
            };

            this.CountB = new Count()
            {
                Type = CountType.B
            };
        }

        public void SetCount(CountType type, int value)
        {
            if (type == CountType.A)
            {
                this.CountA.Value = value;
            }
            else if (type == CountType.B)
            {
                this.CountB.Value = value;
            }
        }

        public int GetCount(CountType type)
        {
            if (type == CountType.A)
            {
                return this.CountA.Value;
            }
            else if (type == CountType.B)
            {
                return this.CountB.Value;
            }
            else
            {
                return -1;
            }
        }
    }
}
