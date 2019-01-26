using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/*
 * attach this to any objects that want to show another object on hover
 */
[RequireComponent(typeof(Image))] //we expect an image that IS a raycast target, for the hovering system to work properly
public class OnClickShows : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject _objectToActivate;

    public void OnPointerDown(PointerEventData eventData)
    {
        _objectToActivate.SetActive(true);
    }

}
