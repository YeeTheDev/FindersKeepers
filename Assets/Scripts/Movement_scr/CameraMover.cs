using UnityEngine;
using System.Collections;
using FK.Core;

namespace FK.Movement
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] float rotationSpeed;
        [SerializeField] float moveSpeed;
        [SerializeField] float moveToIslandSpeed;

        public void Rotate(float axis) => transform.Rotate(Vector3.up * axis * rotationSpeed * Time.deltaTime);

        public void MoveVertically(float axis, IslandMoveParameters limits)
        {
            Vector3 heightPosition = transform.position + Vector3.up * axis * moveSpeed * Time.deltaTime;
            heightPosition.y = Mathf.Clamp(heightPosition.y, limits.MinHeight, limits.MaxHeight);

            transform.position = heightPosition;
        }

        public IEnumerator MoveToIsland(Vector3 islandPosition)
        {
            float timer = 0;
            Vector3 lastPosition = transform.position;

            while (timer < moveToIslandSpeed)
            {
                yield return new WaitForEndOfFrame();

                Vector3 lerpPoint = Vector3.Lerp(lastPosition, islandPosition, timer / moveToIslandSpeed);
                transform.position = lerpPoint;

                timer += Time.deltaTime;
            }

            transform.position = islandPosition;
        }
    }
}