using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples.Strategy
{
    public class Launcher : WeaponBase
    {
        public override void Shoot()
        {
            Debug.Log("Shoot Launcher - BOOM");

            Projectile newProjectile = Instantiate(Projectile, ProjectileSpawnLocation.position, ProjectileSpawnLocation.rotation);

            ParticleSystem burstParticle = Instantiate(ShootParticle, ProjectileSpawnLocation.position, Quaternion.identity);
            burstParticle.Play();

            AudioSource.PlayClipAtPoint(ShootSound, ProjectileSpawnLocation.position);
        }

    }
}
