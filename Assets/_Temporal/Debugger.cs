using FK.Core;
using UnityEngine;

namespace FK.Debugging
{
    public class Debugger : MonoBehaviour
    {
        [SerializeField] ControlEnabler controlEnabler;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.E)) { controlEnabler.SetControlActive(!controlEnabler.ControlEnabled); }
        }
    }
}