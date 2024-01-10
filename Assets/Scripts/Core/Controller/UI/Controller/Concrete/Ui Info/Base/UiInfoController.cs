using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiInfoController : MonoBehaviour, IUiInfoController
{
    [SerializeField] protected TMP_Text _valueText;
    
    public virtual void SetUIValues()
    {
    }
}
