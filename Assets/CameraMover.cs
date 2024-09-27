using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] float moveToIslandSpeed;

    bool moving;

    // Update is called once per frame
    void Update()
    {
        if (moving) { return; }

        if (Input.GetButton("Horizontal"))
        {
            transform.Rotate(Vector3.up * Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetButton("Vertical"))
        {
            transform.position += Vector3.up * Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                StartCoroutine(MoveToIsland(hit.transform.position));
            }
        }
    }

    private IEnumerator MoveToIsland(Vector3 islandPosition)
    {
        moving = true;

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

        moving = false;
    }
}
