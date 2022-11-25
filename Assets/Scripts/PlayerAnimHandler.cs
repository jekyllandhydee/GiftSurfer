using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimHandler : MonoBehaviour
{
    public static PlayerAnimHandler Instance;

    [SerializeField] Animator _animator;
    [SerializeField] string _damageTrigger;
    [SerializeField] string _deathTrigger;

    //duvar üstünden geçerken animasyon zýplama
    private void OnEnable()
    {
        GameManager.OnDeath += OnFail;
    }
     
    private void OnDisable()
    {
        GameManager.OnDeath -= OnFail;
    }

    void Awake()
    {
        if (Instance != null)
            Destroy(this);

        Instance = this;
    }
    //küp düþürme durumu
    public void OnDamage() => _animator.SetTrigger(_damageTrigger);
    //fail durumunda
    void OnFail() => _animator.SetTrigger(_deathTrigger);

}
