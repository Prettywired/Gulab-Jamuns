using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public LineRenderer line;
    private Vector3 prevPosition;

    [SerializeField] private float minDistance = 0.1f;



    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 1;
        prevPosition = transform.position;

    }

    public void StartLine(Vector2 position)
    {
        line.positionCount = 1;
        line.SetPosition(0, position);
    }

    // Update is called once per frame
    public void UpdateLine()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPosition.z = 0f;
            if (Vector3.Distance(currentPosition, prevPosition) > minDistance)
            {
                if (prevPosition == transform.position)
                {
                    line.SetPosition(0, currentPosition);
                }

                else
                {
                    line.positionCount++;
                    line.SetPosition(line.positionCount - 1, currentPosition);
                }



                prevPosition = currentPosition;
            }

        }

    }
}
