using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

namespace Game.Weapons
{
    public class WeaponController : MonoBehaviour
    {
        private List<RangedWeapon> weapons = new List<RangedWeapon>();
        private AmmoContainer[] ammoContainers;
        private int currentWeaponIndex;
        private bool fire;
        private bool haveWeapon;

        private void Awake()
        {
            weapons = new List<RangedWeapon>(GetComponentsInChildren<RangedWeapon>());

            if (weapons.Count > 0)
                haveWeapon = true;
        }

        private void Start()
        {
            currentWeaponIndex = 0;
//            SwapWeapon();
        }

        private void Update()
        {
            Fire();
//            SwapWeapon();
        }

        private void Fire()
        {
            if (CrossPlatformInputManager.GetButtonDown("Fire1") && haveWeapon)
            {
                weapons[currentWeaponIndex].Fire();
                Debug.Log("fire");
            }
        }

        private void SwapWeapon()
        {
            if (!CrossPlatformInputManager.GetButtonDown("Fire2")) return;

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
    }
}