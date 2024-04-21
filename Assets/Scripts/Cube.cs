using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    private Renderer _renderer;
    private int _chance = 100;

    public event Action<Transform, int> Clicked;

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