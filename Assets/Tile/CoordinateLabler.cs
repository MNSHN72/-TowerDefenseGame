using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLabler : MonoBehaviour
{
    [SerializeField] private TMP_Text CoordinateText;
    private Vector2 CoordinateVector2= new Vector2 (0f,0f);
    private string coordinatesToDisplay;

    private void Awake()
    {
        CoordinateText = GetComponentInChildren<TMP_Text>();
        ProccessCoordinates();
    }
    private void Update()
    {
        if (Application.isPlaying == false)
        {
            ProccessCoordinates();
            UpdateObjectName();
        }
    }

    private void ProccessCoordinates()
    {
        float x = (this.gameObject.transform.position.x) * 0.1f;
        float y = (this.gameObject.transform.position.z) * 0.1f;
        CoordinateVector2 = new Vector2(x, y);
        coordinatesToDisplay = $"({x},{y})";
        CoordinateText.text = coordinatesToDisplay;
    }
    private void UpdateObjectName() 
    {
        this.name = coordinatesToDisplay;
    }
}