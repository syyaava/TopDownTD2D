using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestText : MonoBehaviour
{
    public GameObject TestObject;

    private TMP_Text text;
    private EnemySpawnController obj;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
        obj = TestObject.GetComponent<EnemySpawnController>();
    }

    private void Update()
    {
        text.text = obj.TotalEnemyCount.ToString();
    }
}
