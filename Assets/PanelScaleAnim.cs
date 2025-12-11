using UnityEngine;

public class PanelScaleAnim : MonoBehaviour
{
    void OnEnable()
    {
        transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);

        iTween.ScaleTo(gameObject, iTween.Hash(
            "scale", Vector3.one,
            "time", 0.5f,
            "easetype", iTween.EaseType.easeOutBack
        ));
    }

    void OnDisable()
    {
        transform.localScale = Vector3.one;
    }
}
