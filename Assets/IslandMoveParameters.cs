using UnityEngine;

namespace FK.Core
{
    public class IslandMoveParameters : MonoBehaviour
    {
        [SerializeField] float minHeight;
        [SerializeField] float maxHeigth;

        public float MinHeight => minHeight;
        public float MaxHeight => maxHeigth;
    }
}