using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_State : MonoBehaviour
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
    
    void Update()
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
