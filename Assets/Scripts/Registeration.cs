using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Registeration : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;
    public InputField idField;
    public InputField emailField;

    public Button submitButton;
    public Button mainButton;

    public void CallRegister() {
        StartCoroutine(Register());
    }

    IEnumerator Register() {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("id", idField.text);
        form.AddField("password", passwordField.text);
        form.AddField("email", emailField.text);

        WWW www = new WWW("http://localhost/sqlconnect/professorRegister.php", form);
        yield return www;
        Debug.Log(www.text);
        if (www.text == "0") {
            Debug.Log("User created successfully.");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        } else {
            Debug.Log("User created Failed. Error #" + www.text);
        }
    }

    public void VerifyInputs() {
        submitButton.interactable = (nameField.text.Length >= 3 && passwordField.text.Length >= 8 && idField.text.Length >= 8 && emailField.text.Length >= 8);
    }

    public void GoToMain() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
