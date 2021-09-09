using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Examples.Strategy
{
    public class WeaponSystem : MonoBehaviour
    {
        [SerializeField] WeaponBase _startingWeaponPrefab = null;
        [SerializeField] WeaponBase _slot01WeaponPrefab = null;
        [SerializeField] WeaponBase _slot02WeaponPrefab = null;

        [SerializeField] Transform _weaponSocket = null;

        public WeaponBase EquippedWeapon { get; private set; }

        private void Awake()
        {
            if(_startingWeaponPrefab != null)
            {
                EquipWeapon(_startingWeaponPrefab);
            }
        }

        private void Update()
        {
            //press 1
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                EquipWeapon(_slot01WeaponPrefab);
            }

            //press 2
            if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                EquipWeapon(_slot02WeaponPrefab);
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                ShootWeapon();
            }
        }

        public void EquipWeapon(WeaponBase newWeapon)
        {
            if(EquippedWeapon != null)
            {
                Destroy(EquippedWeapon.gameObject);
            }

            EquippedWeapon = Instantiate(newWeapon, _weaponSocket.position, _weaponSocket.rotation);

            EquippedWeapon.transform.SetParent(_weaponSocket);
        }

        public void ShootWeapon()
        {
            EquippedWeapon.Shoot();
        }

    }
}
