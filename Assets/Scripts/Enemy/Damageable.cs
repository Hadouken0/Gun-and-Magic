using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Damageable : MonoBehaviour
{
    [Serializable]
    public class UiSliderEvent : UnityEvent<float, float>
    { }


    [SerializeField]private float startingHealth;
    [SerializeField]private float _currentHealth;

    public float CurrentHealth
    {
        get { return _currentHealth; }
    }

    [Header("Element effects")]
    [Range(0, 100)]
    [SerializeField] private float _currentWetness;
    [SerializeField] private float _burnDamage;
    private float _burnTimer;

    [Header("Events")]
    [SerializeField] private UiSliderEvent OnHealthSet;
    [SerializeField] private UiSliderEvent OnWetSet;

    [Header("For effects")]
    [SerializeField] private Material _material;
    [SerializeField] private Color _redColor;
    [SerializeField] private Color _blueColor;
    [SerializeField] private Color _defaultColor;
   
    private void Start()
    {
        StartCoroutine(Burning());
        Restore();
    }


    public void TakeDamage(float damage, bool consideEffects=false)
    {
        if (consideEffects){
            if (_currentWetness > 0)
                damage -= 10;
            if (_burnTimer > 0)
                damage += 10;
        }

        _currentHealth -= damage;
        OnHealthSet.Invoke(_currentHealth,startingHealth);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void ChangeWet(float wet)
    {
        _currentWetness += wet;
        _burnTimer = 0;

        ChangeMaterialColor(_blueColor, _currentWetness / 100f);

        if (_currentWetness > 100){
            _currentWetness = 100;
        }
        if (_currentWetness <= 0){
            _currentWetness = 0;
            _burnTimer = 10;
            ChangeMaterialColor(_redColor, 1f);
        }
           

        OnWetSet.Invoke(_currentWetness,100);
    }

    IEnumerator Burning()
    {
        yield return new WaitUntil(() => {return _burnTimer>0;});

        _burnTimer -= 1f;
        TakeDamage(_burnDamage,false);

        if (_burnTimer < 1)
            ChangeMaterialColor(_defaultColor, 1f);

        yield return new WaitForSeconds(1f);
        StartCoroutine(Burning());
    }

    public void Restore()
    {
        gameObject.SetActive(true);
        _currentHealth = startingHealth;
        _currentWetness = 0;
        _burnTimer = 0;
        OnHealthSet.Invoke(_currentHealth,startingHealth);
        OnWetSet.Invoke(_currentWetness,100);
        _material.color = _defaultColor;
    }
    private void Die()
    {
        gameObject.SetActive(false);
    }
    private void ChangeMaterialColor(Color color, float power)
    {
       _material.color = Color.Lerp(_defaultColor, color, power);
    }

}
