using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reward : MonoBehaviour
{
    public List<Resource> Rewards = new List<Resource>();

    public void AddReward()
    {
        PlayerResourceController.Instance.AddResources(Rewards.ToArray());
    }
}
