using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public event Action<Transform, int> Clicked;
    private Renderer _renderer;
    private int _chance = 100;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        Clicked?.Invoke(transform, _chance);
        gameObject.SetActive(false);
    }

    public void SetChance(int chance)
    {
        _chance = chance;
    }

    public void SetColor(Color color)
    {
        _renderer.material.color = color;
    }
}
