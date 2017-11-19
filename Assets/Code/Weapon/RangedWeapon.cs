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
        [Tooltip("Shoot per second")]
        public float AttackSpeed = 6;
        [Tooltip("In seconds")]
        public float RechargeDelay = 2;

        public void Fire(RectTransform aim)
        {
            RaycastHit raycastHit;
            Ray ray = GameManager.Instance.GameCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0)); 
            
            if(Physics.Raycast(ray, out raycastHit, Range))
            {
                HitEntity hitEntity = raycastHit.collider.GetComponent<HitEntity>();

                if (hitEntity)
                    hitEntity.OnHit(Damage);
            }
        }
    }
}
