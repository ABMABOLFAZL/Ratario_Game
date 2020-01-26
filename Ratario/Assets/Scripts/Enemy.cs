using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject _pos2Object;
    private Vector3 _pos1;
    private Vector3 _pos2;
    [SerializeField]
    private float _patrolWaitTime = 3f;
    [SerializeField]
    private float _enemyMoveSpeed = 5f;
    private bool _isOnPos1 = true;
    private bool _isOnPos2 = false;
    // Start is called before the first frame update
    void Start()
    {
        _pos1 = transform.position;  
        _pos2 = _pos2Object.transform.position;
        
    }   

    // Update is called once per frame
    void Update()
    {
        EnemyPatrol();
    }

    private void EnemyPatrol()
    {  
        if(transform.position == _pos1)
        {
            _isOnPos1 = true;
        }
        else if (transform.position == _pos2){
            _isOnPos2 = true;
        }

        if(transform.position != _pos2 & _isOnPos2 == false || _isOnPos1)
        {
            transform.position = Vector3.MoveTowards(transform.position,_pos2,_enemyMoveSpeed * Time.deltaTime);
            if(transform.position != _pos2){
                _isOnPos2 = false;
            }
        }
        if(transform.position != _pos1 & _isOnPos1 == false|| _isOnPos2)
        {
            transform.position = Vector3.MoveTowards(transform.position , _pos1, _enemyMoveSpeed * Time.deltaTime);
            if (transform.position != _pos1){
                _isOnPos1 = false;
            }
        }
        if (_isOnPos1 || _isOnPos2)
        {
            StartCoroutine(PatrolWaitPos2BackPos1());
        }
    }
     IEnumerator PatrolWaitPos2BackPos1()
    {
        if (_isOnPos1)
        {
            if(_isOnPos1 || _isOnPos2)
            {
                yield return new WaitForSeconds(_patrolWaitTime);
                EnemyPatrol();      
            }
        }
    } 
}
