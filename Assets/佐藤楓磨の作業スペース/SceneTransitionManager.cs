using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
public class SceneTransitionManager : MonoBehaviour
{
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

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public async void SceneTransition(int _sceneIndex,float _transitionTime)
    {
        await FadeIn();
        var ay = SceneManager.LoadSceneAsync(_sceneIndex);
        while (!ay.isDone)
        {
            
        }
        await FadeOut();
    }
    private async Task FadeIn()
    {
         
    }
    private async Task FadeOut()
    {

    }
}
