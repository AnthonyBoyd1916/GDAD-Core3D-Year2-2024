using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StateUI : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMesh;
    private Enemy enemy;
    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
        if (textMesh == null)
        {
            textMesh = GetComponent<TextMeshPro>();
        }
        if (textMesh == null)
        {
            Debug.LogError("TextMeshPro component not found on State_UI!");
        }
    }
    private void Update()
    {
        UpdateStateText();
    }
    public void UpdateStateText()
    {
        if (enemy != null && textMesh != null)
        {
            textMesh.text = enemy.GetCurrentStateName();
        }
    }
}
