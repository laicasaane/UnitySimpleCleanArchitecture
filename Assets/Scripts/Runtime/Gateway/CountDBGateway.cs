namespace SCA
{
    // Gateway
    // Gateway can't depend on View, Presenter, Usecase
    // Gateway can't inherit Monobehaviour
    public class CountDBGateway : ICountDBGateway
    {
        private readonly Count CountA;
        private readonly Count CountB;

        public CountDBGateway()
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

        public void SetCount(CountType type, int new_value)
        {
            if (type == CountType.A)
            {
                this.CountA.Num = new_value;
            }
            else if (type == CountType.B)
            {
                this.CountB.Num = new_value;
            }
        }

        public int GetCount(CountType type)
        {
            if (type == CountType.A)
            {
                return this.CountA.Num;
            }
            else if (type == CountType.B)
            {
                return this.CountB.Num;
            }
            else
            {
                return -1;
            }
        }
    }
}
