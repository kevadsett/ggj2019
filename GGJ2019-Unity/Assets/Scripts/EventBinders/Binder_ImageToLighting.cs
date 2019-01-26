using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Image))]
public class Binder_ImageToLighting : MonoBehaviour {

    const bool defaultIsLit = true;

    [SerializeField] Sprite litSprite;
    [SerializeField] Sprite offSprite;

    Image boundImage;

	void Awake () {
        boundImage = GetComponent<Image>();
        Apply(defaultIsLit);

        EventManager.LightingChanged += Apply;
	}
	
	void Apply (bool isLit) {
        boundImage.sprite = isLit ? litSprite : offSprite;
	}

    void OnDestroy() {
        EventManager.LightingChanged -= Apply;
    }
}