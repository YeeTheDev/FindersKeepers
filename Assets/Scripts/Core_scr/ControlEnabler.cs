using UnityEngine;

namespace FK.Core
{
    public class ControlEnabler : MonoBehaviour
    {
        public bool ControlEnabled { get; private set; }

        public void SetControlActive(bool active) => ControlEnabled = active;
    }
}