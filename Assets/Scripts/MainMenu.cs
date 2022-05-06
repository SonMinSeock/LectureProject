using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text userDisplay;

    public Toggle professorToggle;
    public Toggle studentToggle;

    private void Start() {
        if (DBManager.LoggedIn) {
            userDisplay.text = "User: " + DBManager.id;
        }
    }

    public void GoToRegister() {
        if (professorToggle.isOn == true) {
            SceneManager.LoadScene(1);   
        } else if (studentToggle.isOn == true) {
            SceneManager.LoadScene(2);
        }
    }

    public void GoToLogin() {
        SceneManager.LoadScene(3);
    }
    
}
