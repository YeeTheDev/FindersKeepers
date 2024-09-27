using UnityEngine;
using System.Collections;
using FK.Core;

namespace FK.Movement
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] float rotationSpeed;
        [SerializeField] float moveSpeed;
        [SerializeField] IslandMoveParameters currentParameters;
        //[SerializeField] float moveToIslandSpeed;

        //bool moving;

        // Update is called once per frame
        //void Update()
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
        //        {
        //            StartCoroutine(MoveToIsland(hit.transform.position));
        //        }
        //    }
        //}

        public void Rotate(float axis) => transform.Rotate(Vector3.up * axis * rotationSpeed * Time.deltaTime);

        public void MoveVertically(float axis)
        {
            Vector3 heightPosition = transform.position + Vector3.up * axis * moveSpeed * Time.deltaTime;
            heightPosition.y = Mathf.Clamp(heightPosition.y, currentParameters.MinHeight, currentParameters.MaxHeight);

            transform.position = heightPosition;
        }

        //private IEnumerator MoveToIsland(Vector3 islandPosition)
        //{
        //    moving = true;

        //    float timer = 0;
        //    Vector3 lastPosition = transform.position;

        //    while (timer < moveToIslandSpeed)
        //    {
        //        yield return new WaitForEndOfFrame();

        //        Vector3 lerpPoint = Vector3.Lerp(lastPosition, islandPosition, timer / moveToIslandSpeed);
        //        transform.position = lerpPoint;

        //        timer += Time.deltaTime;
        //    }

        //    transform.position = islandPosition;

        //    moving = false;
        //}
    }
}