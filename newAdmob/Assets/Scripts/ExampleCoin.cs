using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleCoin : MonoBehaviour
{
    public float hp = 100;
    public int goldCount;
    private void OnEnable()
    {
        ADController.OnGaveReward += GiveCoin;
    }
    private void OnDisable()
    {

        ADController.OnGaveReward-= GiveCoin;
    } 
    private void GiveCoin()
    {
        goldCount += 5;
    }
    private void Update()
    {
        hp -= Time.deltaTime * 10;
        if (hp <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        //sizin ölme mekaniðiniz
        ADController.Instance.ShowInterstitial();
    }
}
