using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    private Animator animator;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnTransform;
    [SerializeField] private GameObject buy1;
    [SerializeField] private GameObject buy2;
    [SerializeField] private GameObject gun;
    [SerializeField] private AudioSource shootSound;
    private void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
        if (PlayerPrefs.HasKey("Buy1"))
        {
            gun.SetActive(false);
            buy1.SetActive(true);
        }
        if (PlayerPrefs.HasKey("Buy2"))
        {
            gun.SetActive(false);
            buy1.SetActive(false);
            buy2.SetActive(true);
        }
        animator.SetBool("idle",true);
    }
    public void Shoot()
    {
        if (GameManager.instance.IsGameStarted())
        {
            GameObject newBullet=Instantiate(bulletPrefab);
            newBullet.transform.position = bulletSpawnTransform.position;
            shootSound.Play();
        }
    }
    public void SetAimAnim()
    {
        animator.SetBool("aim", true);
    }

}
