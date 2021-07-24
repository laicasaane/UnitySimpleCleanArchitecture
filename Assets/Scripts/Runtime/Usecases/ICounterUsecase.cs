namespace SCA
{
    public delegate void ReadEventHandler<TEventArgs>(object sender, in TEventArgs e) where TEventArgs : struct;

    // IUsecase
    // Interface for Usecase
    public interface ICounterUsecase
    {
        void IncrementCount(CountType type);
        int GetCount(CountType type);
        ReadEventHandler<CounterEventArgs> OnCountChanged { get; set; }
    }

    public readonly struct CounterEventArgs
    {
        public readonly CountType Type;
        public readonly int Count;

        public CounterEventArgs(CountType type, int count_number)
        {
            this.Type = type;
            this.Count = count_number;
        }
    }
}
