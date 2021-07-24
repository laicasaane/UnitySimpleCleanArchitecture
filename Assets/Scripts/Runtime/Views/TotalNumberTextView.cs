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
    public class TotalNumberTextView : MonoBehaviour
    {
        [Inject]
        private readonly ICountPresenter presenter;

        private Text text;

        private void Start()
        {
            this.text = GetComponent<Text>();

            this.presenter.CountA.Subscribe(UpdateCount).AddTo(this);
            this.presenter.CountB.Subscribe(UpdateCount).AddTo(this);
        }

        private void UpdateCount(int value)
        {
            var a = this.presenter.CountA.Value;
            var b = this.presenter.CountB.Value;
            var total = a + b;
            this.text.text = string.Format("Total = {0}", total);
        }
    }
}