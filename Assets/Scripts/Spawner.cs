using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private Enemy _enemy;

    private Transform[] _spawnPoint;
    private float _timePause = 2f;
    private Coroutine _coroutine;

    private void Start()
    {
        _spawnPoint = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _spawnPoint[i] = _path.GetChild(i);
        }

        _coroutine = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {       
        while (true)
        {
            foreach (var point in _spawnPoint)
            {
                Instantiate(_enemy, point.position, Quaternion.identity);

                yield return new WaitForSeconds(_timePause);
            }                      
        }       
    }
}
