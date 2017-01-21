using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PowerColor
{
    public string name;
    public Color main, gems;

    public PowerColor(string _name,Color _main, Color _gems)
    {
        name = _name;
        main = _main;
        gems = _gems;
    }


}
