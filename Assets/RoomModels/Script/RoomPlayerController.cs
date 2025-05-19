using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPlayerController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 40f;
    private Animator _animator;
    private readonly float _updateTime = 5f;
    private readonly float _startTime = 5f;
    private static readonly int IsHit = Animator.StringToHash("isHit");
    
    /// <summary>
    /// Method Start
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        _animator = GetComponent<Animator>();
        InvokeRepeating("ChangeAnimation",_startTime,_updateTime);
    }

    /// <summary>
    /// Method FixedUpdate
    /// </summary>
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up,-rotationSpeed * Time.fixedDeltaTime);
    }
    
    /// <summary>
    /// Method ChangeAnimation
    /// This method call the corrutine to load an example player attack
    /// </summary>
    private void ChangeAnimation()
    {
        StartCoroutine(HandleAnimation());
    }
    
    /// <summary>
    ///  IEnumerator HandleAnimation
    /// Activate and desactivate the player attack
    /// </summary>
    /// <returns></returns>
    IEnumerator HandleAnimation()
    {
        _animator.SetBool(IsHit,true);
        yield return new WaitForSeconds(1.5f);
        _animator.SetBool(IsHit,false);
    }
}
