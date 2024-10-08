using UnityEngine;

namespace FK.Core
{
    public class IslandMoveParameters : MonoBehaviour
    {
        [SerializeField] float minHeight;
        [SerializeField] float maxHeigth;

        public float MinHeight => minHeight;
        public float MaxHeight => maxHeigth;

        Collider col;

        public float MidHeight => minHeight + (maxHeigth - minHeight) * 0.5f;

        private void Awake() => col = GetComponent<Collider>();

        public void EnableCollider(bool enable) => col.enabled = enable;
    }
}