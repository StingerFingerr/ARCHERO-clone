using DefaultNamespace.EnemyWeapons;
using DefaultNamespace.EnemyWeapons.EnemyBullets;
using DefaultNamespace.Player_weapon_system;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundSystem : MonoBehaviour
{
    [SerializeField] private AudioClip _portalEnterSound;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioSource _playerAudioSource;


    private void OnEnable()
    {
        BaseEnemyWeapon.OnWeaponShot.AddListener(PlayEnemyAttackClip);
        BaseEnemyBullet.OnBulletHit.AddListener(PlayBulletHitClip);
        PlayerHitBox.OnPlayerEntersPortal.AddListener(PlayEnterInPortalClip);
        BasePlayerArrow.OnArrowIsLaunched.AddListener(PlayArrowLaunchClip);
        BasePlayerArrow.OnPlayerArrowHit.AddListener(PlayArrowHitClip);
    }

    private void PlayEnterInPortalClip() => PlayClip(_portalEnterSound, _audioSource);
    private void PlayBulletHitClip(BaseEnemyBullet bullet)=> PlayClip(bullet._hitSound, _audioSource);
    private void PlayEnemyAttackClip(BaseEnemyWeapon weapon) => PlayClip(weapon._shootingSound, _audioSource);
    private void PlayArrowLaunchClip(BasePlayerArrow arrow) => PlayClip(arrow._arrowLaunchClip, _playerAudioSource);
    private void PlayArrowHitClip(BasePlayerArrow arrow) => PlayClip(arrow._arrowHitClip, _playerAudioSource);

    private void PlayClip(AudioClip clip, AudioSource source)
    {
        if (clip is null)
            return;

        source.clip = clip;
        source.Play();
    }
}
