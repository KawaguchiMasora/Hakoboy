using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 針の動き
/// </summary>
public class Needle : SetNearGrid, IGimmikFunction
{
    //無効化はしないので常にtrue
    public bool IsEnable()
    {
        return true;
    }
    public void MoveMent(GameObject obj)
    {
        if (obj.TryGetComponent<Move>(out var a))
        {
            //プレイヤーに対する処理
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Playerタグが付いたオブジェクトが触れたらMoveMent関数実行
        if (!collision.gameObject.CompareTag("Player")) return;
        MoveMent(collision.gameObject);
    }
}
/// <summary>
/// ギミックの役割のインターフェース
/// </summary>
public interface IGimmikFunction
{
    /// <summary>
    ///有効か無効か
    /// </summary>
    public bool IsEnable();
    /// <summary>
    ///ギミックが働いた時の動き
    /// </summary>
    public void MoveMent(GameObject obj);
}