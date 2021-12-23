using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

using TMPro;

public class UIStartMenu : MonoBehaviour
{
    //handle to Input Field
    public TMP_InputField nameField;

    //handle to Button
    public Button startButton;



    // Start is called before the first frame update
    void Start()
    {
        startButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //make the start button toggle on and off deping if their is a name in the field
    // Linked with On End Edit  in TMP Input field inspector
    public void StartBtnOn()
    {
        if (nameField.GetComponent<TMP_InputField>().text != "")
        {
            startButton.interactable = true;
        }
        else
        {
            startButton.interactable = false;
        }
    }


    //We want to Load the main scene
    //we want to save the name
    public void LoadGame()
    {
        GameManager.Instance.playerName = nameField.GetComponent<TMP_InputField>().text;
        SceneManager.LoadScene("main");
    }
}
