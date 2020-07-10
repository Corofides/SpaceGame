using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStation : MonoBehaviour
{

    private int _parts;

    public void AddParts()
    {
        _parts++;
    }

    public bool IsComplete()
    {
        return _parts >= 5;
    }

}
