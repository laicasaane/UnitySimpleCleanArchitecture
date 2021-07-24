using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace SCA
{
    // View
    // View can depend on the Presenter through its interface
    // View can't depend on another View.
    // View can't depend on Use Case, Gateway
    // View can inherit Monobehaviour
    public class CountButtonView : MonoBehaviour
    {
        public CountType Type;

        [Inject]
        private readonly IPresenterCount presenter;

        private Button button;

        private void Start()
        {
            this.button = GetComponent<Button>();
            this.button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            this.presenter.IncrementCount(this.Type);
        }
    }
}