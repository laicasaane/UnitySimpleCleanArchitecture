using UnityEngine;
using UnityEngine.UI;
using UniRx;
using VContainer;

namespace SCA
{
    // View
    // View can depend on the Presenter through its interface
    // View can't depend on another View.
    // View can't depend on Use Case, Gateway
    // View can inherit Monobehaviour
    public class CountTextView : MonoBehaviour
    {
        public CountType Type;

        [Inject]
        private readonly ICountPresenter presenter;

        private Text text;

        private void Start()
        {
            this.text = GetComponent<Text>();

            var reactive_property = this.Type == CountType.A ? this.presenter.CountA : this.presenter.CountB;

            reactive_property.Subscribe(UpdateText).AddTo(this);

            UpdateText(0); // Initialize
        }

        private void UpdateText(int count)
        {
            this.text.text = string.Format("Count {0} = {1}", this.Type.ToString(), count);
        }
    }
}