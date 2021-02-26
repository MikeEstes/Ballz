using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10.0f;

    //[SerializeField] private BallLauncher _ballLauncher;
    private Rigidbody2D _rigidbody2d;
    private float _lifeTimer = 0.5f;

    //private Camera _cameraMain;
    //private float _screenLeft;
    //private float _screenRight;
    //private float _screenTop;

    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        //_cameraMain = Camera.main;

        //_screenLeft = _cameraMain.ScreenToWorldPoint(new Vector2(0, 0)).x;
        //_screenRight = _cameraMain.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        //_screenTop = _cameraMain.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;

        //Debug.Log("Left: " + _screenLeft + " | Right: " + _screenRight + " | Top: " + _screenTop);
        //Debug.Log("Screen Width: " + Screen.width + " | Screen Height: " + Screen.height);
    }
    private void OnEnable()
    {
        //_lifeTimer = 10.0f;
    }

    private void Update()
    {
        _rigidbody2d.velocity = _rigidbody2d.velocity.normalized * _moveSpeed;

        _lifeTimer -= Time.deltaTime;

        if (_lifeTimer <= 0)
        {
            gameObject.SetActive(false);
            //_ballLauncher.ReturnBall();
        }
    }

    private void CheckCollisions()
    {
        /**
         * This could be used to detect bounds so the walls don't need to be placed.
         * 
        // Left edge detection                                                            //Right edge detection
        //if (transform.position.x <= _cameraMain.ScreenToViewportPoint(new Vector2(0, 0)).x || transform.position.x >= _cameraMain.ScreenToViewportPoint(new Vector2(Screen.width, Screen.height)).x)
        if (transform.position.x < _screenLeft || transform.position.x > _screenRight)
        {
            Vector2 oldVel = _rigidbody2d.velocity;
            _rigidbody2d.velocity = Vector2.zero;
            _rigidbody2d.velocity = oldVel * new Vector2(-1, 1);
        }

        //Top detection
        //if (transform.position.y >= _cameraMain.ScreenToViewportPoint(new Vector2(Screen.width, Screen.height)).y)
        if (transform.position.y > _screenTop)
        {
            Vector2 oldVel = _rigidbody2d.velocity;
            _rigidbody2d.velocity = Vector2.zero;
            _rigidbody2d.velocity = oldVel * new Vector2(1, -1);
        }*/
    }
}