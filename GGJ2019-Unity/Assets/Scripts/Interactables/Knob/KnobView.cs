using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class KnobView : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] FloatRequirementType _floatRequirementType;

    KnobPresenter _knobPresenter;
    RectTransform _rectTransform;
    Vector2 _previousMousePos;
    bool _clickedOnThis = false;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _knobPresenter = new KnobPresenter(this, _floatRequirementType);
    }

    void FixedUpdate()
    {
        if (_clickedOnThis)
        {
            float xDiff = Input.mousePosition.x - _previousMousePos.x;
            _knobPresenter.OnUserDrag(xDiff);

            _previousMousePos = Input.mousePosition;
        }
    }

    public void OnValueChange(float percToMax)
    {
        Debug.Log(Mathf.Lerp(-90f, 90f, percToMax));
        //_rectTransform.eulerAngles =Vector3.ClampMagnitude(6 new Vector3(0, 0, Mathf.Lerp(-90f, 90f, percToMax));
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin");
        _clickedOnThis = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end");
        _clickedOnThis = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //we need all 3 drag handler so they are called
    }
}
