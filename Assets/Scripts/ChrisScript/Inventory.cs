using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> items;
    public float itemSize;
    public GameObject offset;
    public float minPosition;
    BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        minPosition = offset.transform.position.x;
        for (int i = 0; i < items.Count; i++)
        {
            items[i].transform.position = offset.transform.position + new Vector3(itemSize * i, 0);
        }
        StartCoroutine(CheckTesting());
    }

    void Update()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].transform.position = Vector2.MoveTowards(items[i].transform.position, offset.transform.position + new Vector3(itemSize * i, 0), Time.deltaTime * 30);
        }
    }
    public void GoForward()
    {
        if( offset.transform.position.x + (itemSize * (items.Count - 4)) > 0.1)
            offset.transform.position = offset.transform.position - new Vector3(itemSize, 0);
    }
    public void GoBackward()
    {
        if (offset.transform.position.x - minPosition < -0.1)
        {
            offset.transform.position = offset.transform.position + new Vector3(itemSize, 0);
        }
    }
    public void Hide()
    {
        collider.enabled = false;
        foreach (GameObject item in items)
        {
            item.SetActive(false);
        }
    }
    public void Show()
    {
        collider.enabled = true;
        foreach (GameObject item in items)
        {
            item.SetActive(true);
        }
    }
    public bool Check(GameObject item)
    {
        return items.Contains(item);
    }
    public void Pull(GameObject item)
    {
        items.Remove(item);
    }
    public void Add(GameObject item)
    {
        items.Insert(0,item);
    }
    IEnumerator CheckTesting()
    {
        Color c = GetComponent<SpriteRenderer>().color;
        while (true) { 
            yield return new WaitUntil(() => GameObject.FindGameObjectWithTag("PlayButton").GetComponent<PlayButtonScript>().gameTesting);
            GetComponent<SpriteRenderer>().color = Color.gray;
            Hide();
            yield return new WaitUntil(() => !GameObject.FindGameObjectWithTag("PlayButton").GetComponent<PlayButtonScript>().gameTesting);
            GetComponent<SpriteRenderer>().color = c;   
            Show();
        }
    }
}
