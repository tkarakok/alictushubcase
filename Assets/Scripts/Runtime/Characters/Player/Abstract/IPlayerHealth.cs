using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerHealth 
{
    void SetInitializeHealthBarDefaultValues();
    void SetHealthBarValue(int newValue);
}
