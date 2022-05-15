using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.EnemyWeapons;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundSystem : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        BaseEnemyWeapon.OnWeaponShot.AddListener(PlayEnemyAttackClip);
    }


    private void PlayEnemyAttackClip(BaseEnemyWeapon weapon)
    {
        if(weapon._shootingSound is null)
            return;
        
        _audioSource.clip = weapon._shootingSound;
        _audioSource.Play();
    }


}
