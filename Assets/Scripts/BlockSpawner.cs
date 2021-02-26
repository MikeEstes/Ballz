using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private Block _blockPrefab;

    private int _numRows = 1;
    private int _numColumns = 8;
    private float _blockSpace = 0.6f;
    private int _rowsSpawned;

    private List<Block> _blocksSpawned = new List<Block>();

    private void OnEnable()
    {
        for (int i = 0; i < _numRows; i++)
        {
            SpawnBlockRow();
        }
    }

    public void SpawnBlockRow()
    {
        foreach (var block in _blocksSpawned)
        {
            if (block != null)
            {
                block.transform.position += Vector3.down * _blockSpace;
            }
        }

        for (int i = 0; i < _numColumns; i++)
        {
            if (UnityEngine.Random.Range(0, 100) <= 30)
            {
                var block = Instantiate(_blockPrefab, GetPosition(i), Quaternion.identity);
                int hits = UnityEngine.Random.Range(1, 3) + _rowsSpawned;

                block.SetHits(hits);

                _blocksSpawned.Add(block);
            }
        }

        _rowsSpawned++;
    }

    private Vector3 GetPosition(int i)
    {
        Vector3 position = transform.position;
        position += Vector3.right * i * _blockSpace;

        return position;
    }
}
