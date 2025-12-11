using UnityEngine;

public class MainMenuAnimation : MonoBehaviour
{
    public GameObject title;
    public GameObject leftMenu;

    void Start()
    {
        AnimateTitle();
        AnimateLeftMenu();
    }

    void AnimateTitle()
    {
        if (!title) return;

        // mulai invisible
        CanvasGroup cg = title.GetComponent<CanvasGroup>();
        if (!cg) cg = title.AddComponent<CanvasGroup>();
        cg.alpha = 0;

        // posisi turun sedikit
        Vector3 startPos = title.transform.localPosition + new Vector3(0, 80, 0);
        title.transform.localPosition = startPos;

        // slide ke posisi normal
        iTween.MoveTo(title, iTween.Hash(
            "islocal", true,
            "y", startPos.y - 80,
            "time", 1f,
            "easetype", iTween.EaseType.easeOutExpo
        ));

        // fade in
        iTween.ValueTo(title, iTween.Hash(
            "from", 0f,
            "to", 1f,
            "time", 1f,
            "onupdate", "FadeUpdate",
            "easetype", iTween.EaseType.easeOutQuad
        ));
    }

    void FadeUpdate(float v)
    {
        CanvasGroup cg = title.GetComponent<CanvasGroup>();
        cg.alpha = v;
    }

    void AnimateLeftMenu()
    {
        if (!leftMenu) return;

        Vector3 startPos = leftMenu.transform.localPosition + new Vector3(-500, 0, 0);
        leftMenu.transform.localPosition = startPos;

        iTween.MoveTo(leftMenu, iTween.Hash(
            "islocal", true,
            "x", startPos.x + 500,
            "time", 1.1f,
            "delay", 0.2f,
            "easetype", iTween.EaseType.easeOutExpo
        ));
    }
}
