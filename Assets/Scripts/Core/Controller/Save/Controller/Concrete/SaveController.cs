using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour, ISaveController
{
    #region Fields
    public SaveState SaveState = new SaveState();
    private const string _firstSaveCompletedString = "FirstSaveCompleted";
    #endregion
    
    private void Start()
    {
        Load();
    }
        
    /// <summary>
    /// Save the current state of SAVESTATE
    /// </summary>
    public void Save()
    {
        ES3.Save(_firstSaveCompletedString, true); // Save the "first Save"
        ES3.Save("state", SaveState); // Save the "State"

        Debug.Log("The game session saved successfully", gameObject);
    }
        
    /// <summary>
    /// Load and Update the SAVESTATE
    /// </summary>
    public void Load()
    {
        bool isExist = ES3.KeyExists(_firstSaveCompletedString);
        if (!isExist)
        {
            SaveState = new SaveState();
            SaveState.SetInitializeValues();
            Save();

            Debug.Log("The inital data created successfully", gameObject);
        }
        else if(isExist)
        {
            SaveState = ES3.Load("state", new SaveState());

            Debug.Log("The saved data loaded successfully", gameObject);
        }
   
    }
}
