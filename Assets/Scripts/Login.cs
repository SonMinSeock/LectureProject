using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField idField;
    public InputField passwordField;

    public Button submitButton;

    public void CallLogin() {
        StartCoroutine(LoginUser());
    }

    IEnumerator LoginUser() {
        WWWForm form = new WWWForm();
        
        form.AddField("id", idField.text);
        form.AddField("password", passwordField.text);

        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
        yield return www;
        Debug.Log(www.text);
        if (www.text == "0") {
            DBManager.id = idField.text;
            UnityEngine.SceneManagement.SceneManager.LoadScene(4);
        } else {
            Debug.Log("User login failed. Error #" + www.text);
        }

    }

    public void VerifyInputs() {
        submitButton.interactable = (passwordField.text.Length >= 8 && idField.text.Length >= 8 );
    }
}
