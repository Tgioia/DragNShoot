using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.SceneManagement;


public class LoginPlayfab : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI MessageText;

    [SerializeField] TMP_InputField EmailLogin;
    [SerializeField] TMP_InputField PasswordLogin;

    [SerializeField] TMP_InputField EmailRegister;
    [SerializeField] TMP_InputField UsernameRegister;
    [SerializeField] TMP_InputField PasswordRegister;

    public void RegisterUser()
    {
        var request = new RegisterPlayFabUserRequest
        {
            DisplayName = UsernameRegister.text,
            Email = EmailRegister.text,
            Password = PasswordRegister.text,

            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    private void OnError(PlayFabError error)
    {
        MessageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        MessageText.text = "New account has been created";
    }

    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = EmailLogin.text,
            Password = PasswordLogin.text,
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnErrorr);
    }

    private void OnErrorr(PlayFabError error)
    {
        MessageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

    private void OnLoginSuccess(LoginResult result)
    {
        SceneManager.LoadScene("Menu");
    }
}