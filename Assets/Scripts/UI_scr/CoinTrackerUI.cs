using FK.Controls;
using TMPro;
using UnityEngine;

namespace FK.UI
{
    public class CoinTrackerUI : MonoBehaviour
    {
        [SerializeField] TMP_Text text;

        Controller controller;

        private void Awake() => controller = FindObjectOfType<Controller>();

        private void OnEnable() => controller.OnGrabCoin += UpdateText;
        private void OnDisable() => controller.OnGrabCoin -= UpdateText;

        private void UpdateText() => text.text = controller.CoinsGrabbed.ToString("00") + "/10";
    }
}