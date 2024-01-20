using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ガチャの確率を計算したりカードのデータを格納するクラス
/// </summary>
public class RandomNumSystem : MonoBehaviour
{
    [SerializeField]List<int> nums = new List<int>();//重み設定用変数
    [SerializeField]List<string> name = new List<string>();
    /// <summary>
    /// ガチャ実行</summary>
    public void ChooseStart10(int Count)
    {
        for (int i = 0; i < Count; i++)
        {
            int ans = 0;
            ans = Choose(nums);
            Debug.Log(name[ans]);
        }
    }
    /// <summary>抽選メソッド</summary>
    public int Choose(List<int> weight)
    {
        float total = 0f;
        //配列の要素をtotalに代入
        for (int i = 0;i < weight.Count; i++)
        {
            total += weight[i];
        }
        //Random.valueは0.1から1までの値を返す
        float random = UnityEngine.Random.value * total;
        //weightがrandomより大きいかを探す
        for (int i = 0;i < weight.Count ; i++)
        {
            if (random < weight[i])
            {
                //ランダムの値より重みが大きかったらその値を返す
                return i;
            }
            else
            {
                //大きくなかったら重みを減らす
                random -= weight[i];
            }
        }
        //なかったら最後の値を返す
        return weight.Count -1;
    }
}
