using System.Collections.Generic;
using UnityEngine;

public class MovePath : MonoBehaviour
{
    private int _moveDirection = 1;
    private int _movingTo = 0;
    public Transform[] PathElements;

    private void OnDrawGizmos() 
    {
        if(PathElements == null || PathElements.Length< 2)
        {
            return;
        }

        for(var i = 1; i < PathElements.Length; i++)
        {
            Gizmos.DrawLine(PathElements[i - 1].position, PathElements[i].position);
        }
    }

    public IEnumerator<Transform> GetNextPathPoint()
    {
        if (PathElements == null || PathElements.Length < 1)
        {
            yield break;
        }
        while (true)
        {
            yield return PathElements[_movingTo];
            if(PathElements.Length == 1)
            {
                continue;
            }
            if (_movingTo <= 0)
            {
                _moveDirection = 1;
            }
            else if (_movingTo >= PathElements.Length - 1)
            {
                yield break;
               // moveDirection = -1;
            }
            _movingTo = _movingTo + _moveDirection;


        }
    }
}
