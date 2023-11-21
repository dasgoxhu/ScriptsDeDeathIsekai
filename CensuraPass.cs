using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CensuraPass : MonoBehaviour
{
    public TMP_InputField passwordInputField;

    private void Start()
    {
        // Configura el tipo de entrada del campo TextMeshPro.
        passwordInputField.contentType = TMP_InputField.ContentType.Password;
    }
}

