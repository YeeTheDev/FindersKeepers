using FK.Controls;
using TMPro;
using UnityEngine;

namespace FK.UI
{
    public class CoinTrackerUI : MonoBehaviour
    {
        [SerializeField] TMP_Text text;
        [SerializeField] GameObject congratulations;

        Controller controller;

        private void Awake() => controller = FindObjectOfType<Controller>();

        private void OnEnable() => controller.OnGrabCoin += UpdateText;
        private void OnDisable() => controller.OnGrabCoin -= UpdateText;

        public void ResetText() => text.text = "0/10";

        private void UpdateText()
        {
            text.text = controller.CoinsGrabbed.ToString("00") + "/10";
            congratulations.SetActive(controller.CoinsGrabbed >= 10);
        }
    }
}