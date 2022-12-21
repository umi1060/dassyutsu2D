using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    public static FlagManager instance;

    private void Awake()
    {

        instance = this;
    }

    public int  UseShovelTime = 0;
    public bool IsClearTreasureBox = false;

}
