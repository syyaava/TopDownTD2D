using UnityEngine;

[CreateAssetMenu(fileName = "NewBulletData", menuName = "Data/Bullet")]
public class BulletData : ScriptableObject
{
    public int Damage = 1;
    public float Speed = 50f;
    public float RotationSpeed = 360f;
    public float MaxDistance = 20f;

    public override string ToString()
    {
        return $"Name: {name}. Damage: {Damage}. Speed: {Speed}. RotationSpeed: {RotationSpeed}. Max distance {MaxDistance}.";
    }

    public static BulletData operator+ (BulletData first, BulletData second)
    {
        var newBulletData = new BulletData()
        {
            Damage = first.Damage + second.Damage,
            Speed = first.Speed + second.Speed,
            RotationSpeed = first.RotationSpeed + second.RotationSpeed,
            MaxDistance = first.MaxDistance
        };
        return newBulletData;
    }

    public static BulletData operator- (BulletData first, BulletData second)
    {
        var newBulletData = new BulletData()
        {
            Damage = first.Damage - second.Damage,
            Speed = first.Speed - second.Speed,
            RotationSpeed = first.RotationSpeed - second.RotationSpeed,
            MaxDistance = first.MaxDistance
        };
        return newBulletData;
    }

    public static BulletData operator* (BulletData first, BulletData second)
    {
        var newBulletData = new BulletData()
        {
            Damage = first.Damage * second.Damage,
            Speed = first.Speed * second.Speed,
            RotationSpeed = first.RotationSpeed * second.RotationSpeed,
            MaxDistance = first.MaxDistance
        };
        return newBulletData;
    }

    public static bool operator== (BulletData first, BulletData second)
    {
        return first.Damage == second.Damage &&
            first.Speed == second.Speed &&
            first.RotationSpeed == second.RotationSpeed &&
            first.MaxDistance == second.MaxDistance;
    }

    public static bool operator!= (BulletData first, BulletData second)
    {
        return !(first == second);
    }
}
