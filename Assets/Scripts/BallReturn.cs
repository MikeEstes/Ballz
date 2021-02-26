using UnityEngine;

public class BallReturn : MonoBehaviour
{
    [SerializeField] private BallLauncher _ballLauncher;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _ballLauncher.ReturnBall();
        collision.collider.gameObject.SetActive(false);
    }
}
