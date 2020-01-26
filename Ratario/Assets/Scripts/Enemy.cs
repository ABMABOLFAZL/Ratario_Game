using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject _pos2Object;
    private Vector3 _pos1;
    private Transform _pos2;
    [SerializeField]
    private float _patrolWaitTime = 3f;
    private bool _isOnPos1 = true;
    // Start is called before the first frame update
    void Start()
    {
        _pos1 = gameObject.transform.position;  
    }

    // Update is called once per frame
    void Update()
    {
        EnemyPatrol();
    }

    private void EnemyPatrol()
    {
        if (transform.position == _pos1)
        {
            /* StartCoroutine (PatrolWaitPos2BackPos1()); */
        }
    }
    /* IEnumerator PatrolWaitPos2BackPos1()
    {
        if (_isOnPos1)
        {
            transform.position = _pos2;
            yield return new WaitForSeconds(_patrolWaitTime);
            if (transform.position == _pos2)
            {
                transform.position = _pos1;
                _isOnPos1 = false;
            }     
        }
    } */
}
