using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private TextMeshPro _text;

    private int _hitsRemaining;

    private void Awake()
    {
        UpdateVisualState();
    }

    private void UpdateVisualState()
    {
        _text.SetText(_hitsRemaining.ToString());
        _spriteRenderer.color = Color.Lerp(Color.white, Color.red, _hitsRemaining / 10.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _hitsRemaining--;

        // TODO: Research Pooling, so that we're not constantly destroying and re-adding objects.
        if (_hitsRemaining > 0)
        {
            UpdateVisualState();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    internal void SetHits(int hits)
    {
        _hitsRemaining = hits;
        UpdateVisualState();
    }
}
