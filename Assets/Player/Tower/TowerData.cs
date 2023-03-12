using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTowerData", menuName = "Data/Tower/TowerData")]
public class TowerData : ScriptableObject
{
    public Bullet BulletPrefab;
    public float ReloadSecs = 2f;
    public float ShootDistance = 5.0f;
    public List<Resource> Cost = new List<Resource>();
}
