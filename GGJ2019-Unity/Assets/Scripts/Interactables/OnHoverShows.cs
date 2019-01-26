using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/*
 * attach this to any objects that want to show another object on hover
 */
[RequireComponent(typeof(Image))] //we expect an image that IS a raycast target, for the hovering system to work properly
public class OnHoverShows : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject _objectToActivate;
    [SerializeField] float _timeToActivate = 0.5f;

    bool _isHovering;
    float _timer;
    void Update()
    {
        if (_isHovering)
        {
            _timer += Time.deltaTime;
            if (_timer >= _timeToActivate && !_objectToActivate.activeSelf)
            {
                _objectToActivate.SetActive(true);
                _timer = 0;
            }
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isHovering = false;
        _timer = 0;
    }
}
