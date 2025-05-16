using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

using System;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{
    [SerializeField] private InputActionReference controllerActionGrip;
    [SerializeField] private InputActionReference controllerActionTrigger;
    [SerializeField] private Animator handAnimator;

    private const string CLOSE = "Close";
    private const string UP = "Up";

    private string screenshotFolder; // Carpeta para guardar capturas

    void Start()
    {
        // Ruta donde se guardarán las capturas
        screenshotFolder = Path.Combine(Application.persistentDataPath, "Screenshots");

        // Si la carpeta no existe, créala
        if (!Directory.Exists(screenshotFolder))
        {
            Directory.CreateDirectory(screenshotFolder);
        }
    }

    private void OnEnable()
    {
        controllerActionGrip.action.performed += GripActionPerformed;
        controllerActionGrip.action.canceled += GripActionCanceled;

        controllerActionTrigger.action.performed += ThumbActionPerformed;
        controllerActionTrigger.action.canceled += ThumbActionCanceled;
    }

    private void OnDisable()
    {
        controllerActionGrip.action.performed -= GripActionPerformed;
        controllerActionGrip.action.canceled -= GripActionCanceled;

        controllerActionTrigger.action.performed -= ThumbActionPerformed;
        controllerActionTrigger.action.canceled -= ThumbActionCanceled;
    }

    private void GripActionPerformed(InputAction.CallbackContext obj)
    {
        float value = controllerActionGrip.action.ReadValue<float>();
        handAnimator.SetFloat(CLOSE, value);
    }

    private void GripActionCanceled(InputAction.CallbackContext obj)
    {
        handAnimator.SetFloat(CLOSE, 0);
    }

    private void ThumbActionPerformed(InputAction.CallbackContext obj)
    {
        float value = controllerActionTrigger.action.ReadValue<float>();
        handAnimator.SetFloat(UP, value);
        TomarFoto();
    }

    private void ThumbActionCanceled(InputAction.CallbackContext obj)
    {
        if (handAnimator == null)
        {
            Debug.LogError("El Animator no está asignado.");
            return;
        }
        handAnimator.SetFloat(UP, 0);
    }

    private void TomarFoto()
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        string filePath = Path.Combine(screenshotFolder, $"Screenshot_{timestamp}.png");

        // Captura de pantalla en runtime
        ScreenCapture.CaptureScreenshot(filePath);
        Debug.Log($"¡Captura tomada! Guardada en: {filePath}");
    }
}
