using UnityEngine;

namespace Naninovel.UI
{
    public class MyInitializationUI : ScriptableUIBehaviour
    {
        [Tooltip("Event invoked when engine initialization progress is changed.")]
        [SerializeField] private FloatUnityEvent onInitializationProgress;
        
        private CanvasGroup canvasGroup;

        protected override void OnEnable()
        {
            base.OnEnable();
            Engine.OnInitializationProgress += NotifyProgressChanged;
            Engine.OnInitializationFinished += HideUI;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            Engine.OnInitializationProgress -= NotifyProgressChanged;
            Engine.OnInitializationFinished -= HideUI;
        }

        protected virtual void NotifyProgressChanged(float value)
        {
            onInitializationProgress?.Invoke(value);
        }

        private void HideUI()
        {
            // Находим Canvas Group
            canvasGroup = GetComponentInChildren<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.alpha = 0;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
            }
            
            // Или скрываем объект
            gameObject.SetActive(false);
        }
    }
}
