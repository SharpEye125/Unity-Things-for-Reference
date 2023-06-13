using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontTouchOrIncludeThisPlease : MonoBehaviour
{
    public int a;
    public int b;
    public int c;
    public int d;
    public int e;
    public int f;
    public int g;
    public bool iaskedforit;
   
    public int h;
    // Start is called before the first frame update
    void Start()
    {
        a = Random.Range(1, h);
    }

    // Update is called once per frame
    void Update()
    {
        // num = Random.Range(1, 100000);
        if (iaskedforit== true)
        {
            Game();
            Game();
            Game();
            Game();
            Game();
            Game();
            Game();
            Game();
            Game();
            Game();
            Game();
            Game();
            Game();
            Game();
            Game();
        }
    }

    private void Game()
    {
        if (b != a)
        {
            b = Random.Range(1, h);
        }
        if (c != b)
        {
            c = Random.Range(1, h);
        }
        if (d != c)
        {
            d = Random.Range(1, h);
        }
        if (e != d)
        {
            e = Random.Range(1, h);
        }
        if (f != e)
        {
            f = Random.Range(1, h);
        }
        if (g != f)
        {
            g = Random.Range(1, h);
        }
    }
}
