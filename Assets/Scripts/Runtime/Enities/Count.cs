namespace SCA
{
    public enum CountType : int
    {
        A, B
    }

    // Entity
    // Entity can't depend on View, Presenter, Usecase, Gateway
    // Entity can't inherit Monobehaviour
    public class Count
    {
        public CountType Type { get; set; }

        public int Value { get; set; }
    }
}
