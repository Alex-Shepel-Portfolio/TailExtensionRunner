using System.Collections.Generic;
using UnityEngine;

public class FollovPath : MonoBehaviour
{
    public float Speed { private get; set; } = 10;
    [SerializeField] private float _maxDistance = .1f;
    [SerializeField] private MovePath _myPath;
    public IEnumerator<Transform> _pointPath { private get;  set; }


    private void Start()
    {
        _pointPath = _myPath.GetNextPathPoint();
        _pointPath.MoveNext();
        if (_pointPath.Current == null)
        {
            return;
        }

        transform.position = _pointPath.Current.position;
    }


    private void Update()
    {
        if(_pointPath == null || _pointPath.Current == null)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, _pointPath.Current.position, Time.deltaTime * Speed);

        var distanceSqure = (transform.position - _pointPath.Current.position).sqrMagnitude;
        if (distanceSqure < _maxDistance * _maxDistance)
        {
            _pointPath.MoveNext();
        }

       
    }
   
   
}
