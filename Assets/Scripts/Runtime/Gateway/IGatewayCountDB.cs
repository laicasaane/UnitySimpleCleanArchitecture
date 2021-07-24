namespace SCA
{
    // IGateway
    // Interface for Gateway
    public interface IGatewayCountDB
    {
        void SetCount(CountType type, int value);

        int GetCount(CountType type);
    }
}
