using System;
using UnityEngine;

public class LaunchPreview : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private Vector3 _dragStartPoint;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;
    }

    public void SetStartPoint(Vector3 worldPoint)
    {
        _dragStartPoint = worldPoint;
        _lineRenderer.enabled = true;
        _lineRenderer.SetPosition(0, _dragStartPoint);
    }

    public void SetEndPoint(Vector3 worldPoint)
    {
        Vector3 pointOffset = worldPoint - _dragStartPoint;
        Vector3 endPoint = transform.position + pointOffset;

        _lineRenderer.SetPosition(1, endPoint);
    }

    internal void DisableRenderer()
    {
        _lineRenderer.enabled = false;
    }
}
