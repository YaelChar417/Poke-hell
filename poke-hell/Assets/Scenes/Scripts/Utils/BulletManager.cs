using UnityEngine;
using System;

public static class BulletManager
{
    public static int bulletNum {get; private set;} = 0;
    public static Action<int> onCountChanged;

    public static void Add()
    {
        bulletNum++;
        onCountChanged?.Invoke(bulletNum);
    }
    
    public static void Remove()
    {
        bulletNum = Mathf.Max(0, bulletNum - 1);
        onCountChanged?.Invoke(bulletNum);
    }
}
