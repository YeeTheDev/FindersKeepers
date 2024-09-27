using FK.Core;
using FK.Movement;
using UnityEngine;
using System.Collections;

namespace FK.Controls
{
    [RequireComponent(typeof(CameraMover))]
    public class Controller : MonoBehaviour
    {
        [SerializeField] LayerMask islandMask;
        [SerializeField] IslandMoveParameters currentLimits;

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

            ReadMovementInput();
            CheckIfClickIsland();
        }

        private void ReadMovementInput()
        {
            mover.Rotate(Input.GetAxisRaw("Horizontal"));
            mover.MoveVertically(Input.GetAxisRaw("Vertical"), currentLimits);
        }

        private void CheckIfClickIsland()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out RaycastHit hit, Mathf.Infinity, islandMask))
                {
                    controlEnabler.SetControlActive(false);

                    currentLimits.EnableCollider(true);

                    currentLimits = hit.transform.GetComponent<IslandMoveParameters>();
                    currentLimits.EnableCollider(false);

                    StartCoroutine(TransitionToIsland(hit.transform.position));
                }
            }
        }

        private IEnumerator TransitionToIsland(Vector3 point)
        {
            yield return mover.MoveToIsland(point);

            controlEnabler.SetControlActive(true);
        }
    }
}