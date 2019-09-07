using System.Collections.Generic;

namespace XL_Car
{
    public enum WeaponList
    {
       Homing,
       Laser
    }

    [System.Serializable]
    public class Weapon
    {
        public WeaponList weapon;
        public int amount;
        public int damage;
    }
    [System.Serializable]
    public class WeaponData
    {
        public List<Weapon> ListWeaponData;
    }
}
