using FK.Core;
using FK.Movement;
using UnityEngine;

namespace FK.Controls
{
    [RequireComponent(typeof(CameraMover))]
    public class Controller : MonoBehaviour
    {
        CameraMover mover;
        ControlEnabler controlEnabler;

        private void Awake()
        {
            mover = GetComponent<CameraMover>();

            controlEnabler = FindObjectOfType<ControlEnabler>();
        }

        private void Update()
        {
            if (!controlEnabler.ControlEnabled) { return; }

            mover.Rotate(Input.GetAxisRaw("Horizontal"));
            mover.MoveVertically(Input.GetAxisRaw("Vertical"));
        }
    }
}