using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private BlockSpawner _blockSpawner;
    [SerializeField] private Camera _cameraMain;

    private LaunchPreview _launchPreview;
    private Vector3 _startDragPosition;
    private Vector3 _endDragPosition;
    private List<Ball> _balls = new List<Ball>();
    private int _ballsReady;

    private void Awake()
    {
        _launchPreview = GetComponent<LaunchPreview>();
        CreateBall();
    }

    private void CreateBall()
    {
        var ball = Instantiate(_ballPrefab);
        ball.gameObject.SetActive(false);
        _balls.Add(ball);
        _ballsReady++;
    }

    internal void ReturnBall()
    {
        _ballsReady++;
        if (_ballsReady == _balls.Count)
        {
            _blockSpawner.SpawnBlockRow();
            // TODO: This could be triggered by a powerup instead.
            CreateBall();
        }
    }

    private void Update()
    {
        Vector3 worldPosition = _cameraMain.ScreenToViewportPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            StartDrag(worldPosition);
        }
        else if (Input.GetMouseButton(0))
        {
            ContinueDrag(worldPosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }
    }

    private void StartDrag(Vector3 worldPosition)
    {
        _startDragPosition = worldPosition;
        _launchPreview.SetStartPoint(transform.position);
    }

    private void ContinueDrag(Vector3 worldPosition)
    {
        _endDragPosition = worldPosition;

        Vector3 direction = _endDragPosition - _startDragPosition;
        _launchPreview.SetEndPoint(transform.position - direction * 5.0f);
    }

    private void EndDrag()
    {
        _launchPreview.DisableRenderer();
        StartCoroutine(LaunchBalls());
    }

    private IEnumerator LaunchBalls()
    {
        Vector3 direction = _endDragPosition - _startDragPosition;
        direction.Normalize();

        foreach (var ball in _balls)
        {
            ball.gameObject.SetActive(true);
            ball.transform.position = transform.position;
            ball.GetComponent<Rigidbody2D>().AddForce(-direction);

            yield return new WaitForSeconds(0.1f);

            _ballsReady--;
        }

        //_ballsReady = 0;
    }
}
