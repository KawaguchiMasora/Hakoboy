using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// î†ê∂ê¨ÇÃÉeÉXÉg
/// </summary>
public class TestGenerateBox : MonoBehaviour
{
    [SerializeField] private GameObject box;
    [SerializeField] private float throwPower;
    private Vector3 centerPos;
    private Vector3 spriteSize;
    private int boxCountLimit = 5;
    private int currentBoxCount;
    private List<GameObject> instnacedBoxs = new List<GameObject>();
    private List<GameObject> allparent = new List<GameObject>();
    void Start()
    {
        spriteSize = GetComponent<SpriteRenderer>().bounds.size;
        InputManager.instnace.SetButtonAction(()=>GenerateBox(angle.down),InputManager.KeyType.CreateBoxDown);
        InputManager.instnace.SetButtonAction(()=>GenerateBox(angle.up),InputManager.KeyType.CreateBoxUp);
        InputManager.instnace.SetButtonAction(()=>GenerateBox(angle.left),InputManager.KeyType.CreateBoxL);
        InputManager.instnace.SetButtonAction(()=>GenerateBox(angle.right),InputManager.KeyType.CreateBoxR);
        InputManager.instnace.SetButtonAction(() => ThrowBox(), InputManager.KeyType.Y);
        InputManager.instnace.SetButtonAction(() => DropBox(), InputManager.KeyType.DownArrow);
        InputManager.instnace.SetButtonAction(() => DeleteBox(), InputManager.KeyType.Delete);
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.instnace.IsYButtonDown())
        {
            if (instnacedBoxs.Count == 0)
            {
                centerPos = transform.position;
            }
            GetComponent<Move>().movementSpeed = 0;
        }
        if (InputManager.instnace.IsYButtonUp())
        {
            GetComponent<Move>().movementSpeed = 1;
        }
    }
    private enum angle
    {
        up,
        down,
        right,
        left,
    }
    private void GenerateBox(angle angle)
    {
        if (currentBoxCount >= boxCountLimit) return;
        GameObject instnaceBox = null;
        switch (angle)
        {
            case angle.up:
                instnaceBox = Instantiate(box, centerPos + new Vector3(0,spriteSize.y,0),Quaternion.identity);
                break;
            case angle.down:
                instnaceBox = Instantiate(box, centerPos + new Vector3(0, -spriteSize.y, 0), Quaternion.identity);
                break;
            case angle.right:
                instnaceBox = Instantiate(box, centerPos + new Vector3(spriteSize.x, 0, 0), Quaternion.identity);
                break;
            case angle.left:
                instnaceBox = Instantiate(box, centerPos + new Vector3(-spriteSize.x, 0, 0), Quaternion.identity);
                break;
        }
        centerPos = instnaceBox.transform.position;
        instnaceBox.transform.localScale = spriteSize;
        currentBoxCount++;
        instnacedBoxs.Add(instnaceBox);
        instnaceBox.transform.SetParent(transform);
    }
    private void ThrowBox()
    {
        if (instnacedBoxs.Count == 0) return;
        var parent = new GameObject("Parent");
        var rb = parent.AddComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        for (int i = 0; i < instnacedBoxs.Count; i++)
        {
            instnacedBoxs[i].transform.SetParent(parent.transform);
        }
        rb.AddForce(new Vector3(1, 1, 0) * throwPower, ForceMode2D.Impulse);
        instnacedBoxs = new List<GameObject>();
        allparent.Add(parent);
    }
    private void DropBox()
    {
        if (instnacedBoxs.Count == 0) return;
        var parent = new GameObject("Parent");
        var rb = parent.AddComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        for (int i = 0; i < instnacedBoxs.Count; i++)
        {
            instnacedBoxs[i].transform.SetParent(parent.transform);
        }
        instnacedBoxs = new List<GameObject>();
        allparent.Add(parent);
    }
    private void DeleteBox()
    {
        for (int i = 0; i < allparent.Count; i++)
        {
            Destroy(allparent[i]);
        }
        allparent = new List<GameObject>();
        currentBoxCount = 0;
    }
}
