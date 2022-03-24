using UnityEngine;

public class FindPlayer : MonoBehaviour
{
    private Transform _playerPos;
    public Transform FindPlayeAtScener()
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        return _playerPos;
    }
}
