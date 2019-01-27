using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class KnobView : MonoBehaviour
{
    [SerializeField] FloatRequirementType _floatRequirementType;
    [SerializeField] GameObject _goToDeactivate;

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
        if (Input.GetMouseButton(0))
        {
            float xDiff = _previousMousePos.x - Input.mousePosition.x;
            _knobPresenter.OnUserDrag(xDiff);

            _previousMousePos = Input.mousePosition;
        }
        else
        {
            _goToDeactivate.SetActive(false);
            _knobPresenter.OnDeactivate(_goToDeactivate);
        }
    }

    public void OnValueChange(float percToMax)
    {
        _rectTransform.eulerAngles = Vector3.ClampMagnitude(new Vector3(0, 0, Mathf.Lerp(-90f, 90f, percToMax)), 90f);
    }
}
