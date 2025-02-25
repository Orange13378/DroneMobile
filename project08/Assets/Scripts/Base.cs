﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    [SerializeField] protected GameObject DeadMenu, PauseMenu, Joy1, Joy2, But, nextwave, compl, startwave;
    public float health;
    private float healthUI;
    public GameObject base0, base1, base2, base3, base4, base5;
    public Image UIHPBase;
    void Start()
    {
        health = 100;
        PlayerPrefs.SetFloat("BaseHealth", health);
        base0.SetActive(true);
        healthUI = health;
    }
    void Update()
    {
        UIHPBase.fillAmount = health / healthUI;
        if (health == 80)
        {
            base0.SetActive(false);
            base1.SetActive(true);
        }
        if (health == 60)
        {
            base1.SetActive(false);
            base2.SetActive(true);
        }
        if (health == 40)
        {
            base2.SetActive(false);
            base3.SetActive(true);
        }
        if (health == 20)
        {
            base3.SetActive(false);
            base4.SetActive(true);
        }
        if (health == 10)
        {
            base4.SetActive(false);
            base5.SetActive(true);
        }
        health = PlayerPrefs.GetFloat("BaseHealth", health);
    }
    public void TakeDamage(float Damage)
    {
        health -= Damage;
        PlayerPrefs.SetFloat("BaseHealth", health);
        if (health <= 0)
        {
            StartCoroutine(Dead());
        }
    }
    public void Deady(GameObject a, GameObject b, GameObject c, GameObject d, GameObject e, GameObject f, GameObject g, GameObject k)
    {
        a.SetActive(false);
        b.SetActive(false);
        c.SetActive(false);
        d.SetActive(true);
        e.SetActive(false);
        f.SetActive(false);
        g.SetActive(false);
        k.SetActive(false);
        Time.timeScale = 0;
    }
    IEnumerator Dead()
    {
        yield return new WaitForSeconds(0.18f);
        Deady(Joy1, Joy2, PauseMenu, DeadMenu, But, nextwave, compl, startwave);
        DestroyImmediate(gameObject);
    }
}
