using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Elementos vida")]
    public float health;
    public float maxHealth;
    public Image healthBar;
    [SerializeField] private GameObject muerte;
    [SerializeField] private GameObject deathpanel;

    public GameObject torretas;

    private void Start()
    {
        maxHealth = health;        
    }

    private void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        if (health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Instantiate(muerte, transform.position, Quaternion.identity);
        SceneManager.LoadScene("Lvl_2");
    }
}
