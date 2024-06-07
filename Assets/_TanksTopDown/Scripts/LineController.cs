using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tank_top_down
{
    public class LineController : MonoBehaviour
    {
        private LineRenderer lineRenderer;
        private List<Vector3> points = new List<Vector3>();
        private bool isDrawing = false;

        void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.positionCount = 0;
            lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.1f;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartDrawing();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                StopDrawing();
            }

            if (isDrawing)
            {
                Draw();
            }
        }

        private void StartDrawing()
        {
            isDrawing = true;
            points.Clear();
            lineRenderer.positionCount = 0;
        }

        private void StopDrawing()
        {
            isDrawing = false;
        }

        private void Draw()
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10f; // khoảng cách từ camera đến màn hình
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            if (points.Count == 0 || Vector3.Distance(points[points.Count - 1], worldPosition) > 0.1f)
            {
                points.Add(worldPosition);
                lineRenderer.positionCount = points.Count;
                lineRenderer.SetPositions(points.ToArray());
            }
        }
    }

}
