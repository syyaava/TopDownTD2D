using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTowerData", menuName = "Data/Tower/TowerData")]
public class TowerData : ScriptableObject
{
    public int Level = 1;
    public List<Bullet> BulletPrefabs = new List<Bullet>();
    [Min(0.1f)]
    public float ReloadSecs = 2f;
    [Range(1f, 50f)]
    public float ShootDistance = 5.0f;
    public List<Resource> Cost = new List<Resource>();
    public List<Resource> UpgradeCosts = new List<Resource>();
}
