using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class SceneTransitionManager : MonoBehaviour
{
    private Image fadePanel;
    private static SceneTransitionManager _ins;
    public static SceneTransitionManager instance
    {
        get
        {
            if (_ins == null)
                _ins = FindObjectOfType<SceneTransitionManager>();
            return _ins;
        }
    }
    private const float FADE_SECONDS = 2f;
    void Start()
    {
        var i = SceneTransitionManager.instance;
        DontDestroyOnLoad(i.gameObject);
        Setup();
    }
    void Update()
    {
        
    }
    public IEnumerator SceneTransition(int _sceneIndex,System.Action setup = null)
    {
        yield return StartCoroutine(Fade());
        var asy = SceneManager.LoadSceneAsync(_sceneIndex);
        while (!asy.isDone)
        {
            yield return null;
        }
        Setup();
        if (setup != null)
            setup();
        yield return StartCoroutine(Fade(true));
    }
    private IEnumerator Fade(bool revers = false)
    {
        float step = 0f;
        while (step < 1f)
        {
            var col = fadePanel.color;
            col.a = revers ? 1f - step : step;
            step += Time.deltaTime / FADE_SECONDS;
            fadePanel.color = col;
            yield return null;
        }
    }
    private void Setup()
    {
        fadePanel = GameObject.Find("Canvas").transform.Find("FadeImage").GetComponent<Image>();
    }
}
