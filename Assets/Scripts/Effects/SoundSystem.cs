using DefaultNamespace.EnemyWeapons;
using DefaultNamespace.EnemyWeapons.EnemyBullets;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundSystem : MonoBehaviour
{
    [SerializeField] private AudioClip _portalEnterSound;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        BaseEnemyWeapon.OnWeaponShot.AddListener(PlayEnemyAttackClip);
        BaseEnemyBullet.OnBulletHit.AddListener(PlayBulletHitClip);
        PlayerHitBox.OnPlayerEntersPortal.AddListener(PlayEnterInPortalClip);
    }


    private void PlayEnterInPortalClip() => PlayClip(_portalEnterSound);
    private void PlayBulletHitClip(BaseEnemyBullet bullet)=> PlayClip(bullet._hitSound);
    private void PlayEnemyAttackClip(BaseEnemyWeapon weapon) => PlayClip(weapon._shootingSound);

    private void PlayClip(AudioClip clip)
    {
        if (clip is null)
            return;

        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
