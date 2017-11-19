using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

namespace Game.Weapons
{
    public class WeaponController : MonoBehaviour
    {
        public RectTransform Aim;
        public Text ammoCountText;

        private List<RangedWeapon> weapons = new List<RangedWeapon>();
        private AmmoContainer[] ammoContainers;
        private int currentWeaponIndex;
        private bool fire;
        private bool haveWeapon;

        void Awake()
        {
            weapons = new List<RangedWeapon>(GetComponentsInChildren<RangedWeapon>());

            if (weapons.Count > 0)
                haveWeapon = true;
        }

        void Start()
        {
            currentWeaponIndex = 0;
            SwapWeapon();
        }

        void Update()
        {
            fire = CrossPlatformInputManager.GetButtonDown("Fire1");
            if (CrossPlatformInputManager.GetButtonDown("Fire2"))
            {
                SwapWeapon();
            }
        }

        void FixedUpdate()
        {
            if (fire && haveWeapon)
                weapons[currentWeaponIndex].Fire(Aim);
        }

        public void SwapWeapon()
        {
            currentWeaponIndex++;

            if (currentWeaponIndex > weapons.Count - 1)
                currentWeaponIndex = 0;

            for (var index = 0; index < weapons.Count; index++)
            {
                var weapon = weapons[index];
                if (index != currentWeaponIndex)
                    weapon.transform.parent.gameObject.SetActive(false);
                else
                {
                    weapon.transform.parent.gameObject.SetActive(true);
                }
            }
        }

        public void AddWeapon(GameObject weaponPrefab)
        {
            haveWeapon = true;
            RangedWeapon weapon = weaponPrefab.GetComponent<RangedWeapon>();

            if (weapon && !weapons.Contains(weapon))
                weapons.Add(weapon);
        }

        public void AddAmmo(AmmoContainer ammoContainer)
        {
            
        }
    }
}