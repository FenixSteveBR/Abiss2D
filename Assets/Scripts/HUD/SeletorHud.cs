using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeletorHud : MonoBehaviour
{
    public Image[] items;
    public Color selectedColor;
    public float scrollSpeed = 10f;

    private int selectedItemIndex = 0;
    private ScrollRect scrollRect;

    private void Start()
    {
        UpdateSelection();
        scrollRect = GetComponent<ScrollRect>();
    }

    private void Update()
    {
        // Mover para cima
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedItemIndex = (selectedItemIndex - 1 + items.Length) % items.Length;
            UpdateSelection();
            ScrollToSelectedItem();
        }
        // Mover para baixo
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedItemIndex = (selectedItemIndex + 1) % items.Length;
            UpdateSelection();
            ScrollToSelectedItem();
        }
        // Coletar item selecionado
        else if (Input.GetKeyDown(KeyCode.E))
        {
            CollectSelectedItem();
        }
    }

    private void UpdateSelection()
    {
        for (int i = 0; i < items.Length; i++)
        {
            Image image = items[i].GetComponent<Image>();
            if (i == selectedItemIndex)
            {
                image.color = selectedColor;
            }
            else
            {
                image.color = Color.white;
            }
        }
    }

    private void CollectSelectedItem()
    {
        // Fazer algo com o item selecionado
        Debug.Log("Item coletado: " + selectedItemIndex);
    }

    private void ScrollToSelectedItem()
    {
        float targetPosition = (1f / items.Length) * selectedItemIndex;
        scrollRect.verticalNormalizedPosition = Mathf.Lerp(scrollRect.verticalNormalizedPosition, targetPosition, Time.deltaTime * scrollSpeed);
    }
}
