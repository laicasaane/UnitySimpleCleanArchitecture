namespace SCA
{
    public class UsecaseTotalCounter : IUsecaseTotalCounter
    {
        private readonly IGatewayCountDB gateway;

        public UsecaseTotalCounter(IGatewayCountDB gateway)
        {
            this.gateway = gateway;
        }

        public int GetTotalCount()
        {
            return this.gateway.GetCount(CountType.A) +
                   this.gateway.GetCount(CountType.B);
        }
    }
}