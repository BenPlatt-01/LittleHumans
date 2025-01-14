using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class MenuController : MonoBehaviour
{
    public string _newGameLevel;

    private void Start()
    {
        
    }


    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(_newGameLevel);
    }


    public void ExitButton() 
    { 
        Application.Quit();
    }

    }


