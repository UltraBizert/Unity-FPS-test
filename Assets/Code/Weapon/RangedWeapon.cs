using UnityEngine;

namespace Game.Weapons
{
    public enum WeaponTypes
    {
        Rifle,
        Shotgun
    }

    public class RangedWeapon : MonoBehaviour
    {
        public WeaponTypes WeaponType;
        public Transform Muzzle;
        public float Range;
        public float Damage;
        [Tooltip("Shoot per second")] public float AttackSpeed = 6;
        [Tooltip("In seconds")] public float RechargeDelay = 2;

        public void Fire()
        {
            var ray = new Ray(transform.position, transform.forward);

            Debug.DrawRay(ray.origin, ray.direction);

            if (!Physics.Raycast(ray, out var rayCastHit, Range)) return;

            var hitEntity = rayCastHit.collider.GetComponent<HitEntity>();

            if (hitEntity) hitEntity.OnHit(Damage);
        }
    }
}
