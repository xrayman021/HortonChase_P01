using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    [SerializeField] int _maxHealth = 10;
    [SerializeField] Text _displayHealth; 
    public static int _currentHealth;
    int _treasureAmount;
    int SetHealth;
    [SerializeField] AudioClip _playerDamageSound = null;
    [SerializeField] ParticleSystem _playerDamageParticles;
    [SerializeField] FlashImage _flashImage;
    [SerializeField] Color _flashColor;
    public HealthBar healthBar;
    [SerializeField] private Text loseText;
    

    TankController _tankController;

    private void Awake() 
    {
        _tankController = GetComponent<TankController>();
        
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        healthBar.SetMaxHealth(_maxHealth);
        loseText.enabled = false;
    }

    public void IncreaseHealth(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        _currentHealth += amount;
        healthBar.SetHealth(_currentHealth);
        Debug.Log("Player's health: " + _currentHealth);
    }

    public void DecreaseHealth(int amount)
    {
        _currentHealth -= amount;
        healthBar.SetHealth(_currentHealth);
        _flashImage.StartFlash(.25f, .5f, _flashColor);
        Debug.Log("Player's health: " + _currentHealth);
        if(_currentHealth <= 0)
        {
            
            Kill();
        }
    }

    public void Kill()
    {
        this.gameObject.SetActive(false);
        AudioHelper.PlayClip2D(_playerDamageSound, 1f);
        _playerDamageParticles = Instantiate(_playerDamageParticles, transform.position, Quaternion.identity);
        loseText.enabled = true;
    }

    public void IncreaseTreasure(int treasureIncrease)
    {
        _treasureAmount += treasureIncrease;
        //_currentTreasureAmount.text = "Treasure: " + _treasureAmount.ToString();
        Debug.Log("Player's treasure: " + _treasureAmount);
    }

    public void Update()
    {
        _displayHealth.text = ""+_currentHealth;
        
    }


}
