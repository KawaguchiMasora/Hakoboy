using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class EventChecker : MonoBehaviour
{
    private static EventChecker _ins;
    public static EventChecker instance
    {
        get
        {
            if (_ins == null)
                _ins = FindObjectOfType<EventChecker>();
            return _ins;
        }
    }
    void Start()
    {
        var i = EventChecker.instance;
        DontDestroyOnLoad(i.gameObject);
    }
    /// <summary>
    /// �S�ẴC�x���g�̃C���^�[�t�F�C�X���`�F�b�N���A���̓��e�����s����
    /// </summary>
    /// <returns></returns>
    public IEnumerator CheckAllEvent()
    {
        var events = FindObjectsOfType<MonoBehaviour>().OfType<IEventChecker>().ToList();
        for (int i = 0; i < events.Count; i++)
        {
            if (events[i].IsComplete())
                yield return StartCoroutine(events[i].EventFunction());
        }
    }
}
