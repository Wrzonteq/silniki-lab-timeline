using UnityEngine;

public class WitcherVisualisation : MonoBehaviour {
    public RectTransform bar;
    public RectTransform point;
    public WitcherLogic logic;
    const float DEFAULT_BAR_WIDTH = 100;
    const float MIN_BAR_WIDTH = 10;

    public float CanvasWidth => 1000;

    public float MouseX {
        get {
            var pos01 = Mathf.Clamp01(Input.mousePosition.x / Screen.width);
            return pos01*CanvasWidth;
        }
    }

    public float BarX {
        get => bar.anchoredPosition.x + CanvasWidth / 2;
        set {
            var pos = bar.anchoredPosition;
            pos.x = value - CanvasWidth/2;
            bar.anchoredPosition = pos;
        }
    }

    public float BarWidth {
        get {
            return DEFAULT_BAR_WIDTH*bar.localScale.x;
        }
        set {
            var localScale = bar.localScale;
            localScale.x = Mathf.Clamp(value, MIN_BAR_WIDTH, DEFAULT_BAR_WIDTH) / DEFAULT_BAR_WIDTH;
            bar.localScale = localScale;
        }
    }

    public float PointX {
        get => point.anchoredPosition.x + CanvasWidth / 2;
        set => point.anchoredPosition = new Vector2(value - CanvasWidth/2, point.anchoredPosition.y);
    }


}
