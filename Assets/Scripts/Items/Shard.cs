using System.Collections.Generic;
using UnityEngine;

public class Shard : BaseWeapon
{
    [SerializeField] protected float wetInfluence;
    [SerializeField] protected ParticleSystem particleShootSystem;

    public override void Shoot()
    {
        base.Shoot();
        if (!isReadyToShoot)
            return;

        isReadyToShoot = false;

        particleShootSystem.Play();

        Invoke(nameof(ReadyToShoot), delayBetweenShoot);
    }

    private void OnParticleCollision(GameObject hitObject)
    {
        if (hitObject.GetComponent<Damageable>())
        {
            hitObject.GetComponent<Damageable>().TakeDamage(damage,false);
            hitObject.GetComponent<Damageable>().ChangeWet(wetInfluence);
        }
    }
}
