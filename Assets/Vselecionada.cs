using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Vselecionada : MonoBehaviour
{
    private RectTransform _rectTransform;
    [SerializeField]  private float _speed = 5f;
    private GameObject selecionada;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }


    // Update is called once per frame
    private void Update()
    {
        var objetoSelecionado = EventSystem.current.currentSelectedGameObject;

        selecionada = (objetoSelecionado == null) ? selecionada : objetoSelecionado;

        EventSystem.current.SetSelectedGameObject(selecionada);

        if (selecionada == null) return;

        transform.position = Vector3.Lerp(transform.position, selecionada.transform.position, _speed*Time.deltaTime);

        var outroLado = selecionada.GetComponent<RectTransform>();

        var HorizontalLerp = Mathf.Lerp(_rectTransform.rect.size.x, outroLado.rect.size.x, _speed * Time.deltaTime);
        var VerticalLerp = Mathf.Lerp(_rectTransform.rect.size.y, outroLado.rect.size.y, _speed * Time.deltaTime);

        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, HorizontalLerp);
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, VerticalLerp);

    }
}
