﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rider : UnitBase
{

    public Rider()
    {
        base.SetUnitType("骑士", UnitType.Rider);
        base._HP = 3;
        base._Description = "骑士";
    }
}
