using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Binder_ImageColourToLighting : MonoBehaviour {

    const bool defaultIsLit = true;

    [SerializeField] Color litColor;
    [SerializeField] Color offColor;

    Image boundImage;

    void Awake () {
        boundImage = GetComponent<Image>();
        Apply(defaultIsLit);

        EventManager.LightingChanged += Apply;
    }

    void Apply (bool isLit) {
        boundImage.color = isLit ? litColor : offColor;
    }

    void OnDestroy () {
        EventManager.LightingChanged -= Apply;
    }
}