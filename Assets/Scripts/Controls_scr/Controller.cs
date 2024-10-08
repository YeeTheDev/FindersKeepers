using FK.Core;
using FK.Movement;
using UnityEngine;
using System.Collections;
using System;

namespace FK.Controls
{
    [RequireComponent(typeof(CameraMover))]
    public class Controller : MonoBehaviour
    {
        public Action OnGrabCoin;

        [SerializeField] LayerMask interactMask;
        [SerializeField] IslandMoveParameters currentLimits;
        [SerializeField] AudioClip pickCoinClip;

        int coinsGrabbed;
        CameraMover mover;
        AudioSource audioSource;
        ControlEnabler controlEnabler;

        public int CoinsGrabbed => coinsGrabbed;

        private void Awake()
        {
            mover = GetComponent<CameraMover>();
            audioSource = GetComponent<AudioSource>();

            controlEnabler = FindObjectOfType<ControlEnabler>();
        }

        private void Update()
        {
            if (!controlEnabler.ControlEnabled) { return; }

            ReadMovementInput();
            TryInteract();
        }

        private void ReadMovementInput()
        {
            mover.Rotate(Input.GetAxisRaw("Horizontal"));
            mover.MoveVertically(Input.GetAxisRaw("Vertical"), currentLimits);
        }

        private void TryInteract()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, interactMask);

                if (hit.collider != null)
                {
                    if (hit.transform.CompareTag("Island")) { MoveToIsland(hit.transform); }
                    else if (hit.transform.CompareTag("Coin")) { GrabCoin(hit.transform.gameObject); }
                }
            }
        }

        private void MoveToIsland(Transform hit)
        {
            controlEnabler.SetControlActive(false);

            currentLimits.EnableCollider(true);

            currentLimits = hit.transform.GetComponent<IslandMoveParameters>();
            currentLimits.EnableCollider(false);

            StartCoroutine(TransitionToIsland(hit.transform.position));
        }

        private void GrabCoin(GameObject hit)
        {
            coinsGrabbed++;
            hit.SetActive(false);
            audioSource.PlayOneShot(pickCoinClip);

            OnGrabCoin?.Invoke();

            if (coinsGrabbed >= 10)
            {
                coinsGrabbed = 0;
                controlEnabler.SetControlActive(false);
            }
        }

        private IEnumerator TransitionToIsland(Vector3 point)
        {
            point.y = currentLimits.MidHeight;

            yield return mover.MoveToIsland(point);

            controlEnabler.SetControlActive(true);
        }
    }
}