using System.Collections.Generic;
using UnityEngine;

public class SpawnerCubes : MonoBehaviour
{
    [SerializeField] private Cube _prefabCube;
    [SerializeField] private Cube[] _cubesStage;

    private List<Cube> _activeCubes = new List<Cube>();

    private Explosion _explosion;
    private int _maxChanceDivision = 100;
    private int _minNumberNewCubes = 2;
    private int _maxNumberNewCubes = 7;
    private int _reductionCoefficientChance = 2;
    private int _reductionFactorSize = 2;

    private void Awake()
    {
        _explosion = new Explosion();
    }

    private void OnEnable()
    {
        for (int i = 0; i < _cubesStage.Length; i++)
        {
            _cubesStage[i].Clicked += OnClicked;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _activeCubes.Count; i++)
        {
            _activeCubes[i].Clicked -= OnClicked;
        }
    }

    private void OnClicked(Cube cube, int spawnChance)
    {
        cube.Clicked -= OnClicked;
        _activeCubes.Remove(cube);

        if (Random.Range(0, _maxChanceDivision) < spawnChance)
        {
            CreateCubes(Random.Range(_minNumberNewCubes, _maxNumberNewCubes), cube.transform, spawnChance);
        }
    }

    private void CreateCubes(int count, Transform transformOldCube, int chance)
    {
        List<Cube> newCubes = new List<Cube>();

        chance /= _reductionCoefficientChance;

        for (int i = 0; i < count; i++)
        {
            Cube cube = Instantiate(_prefabCube, transformOldCube.position, transformOldCube.rotation);

            _activeCubes.Add(cube);
            newCubes.Add(cube);

            cube.SetChance(chance);
            cube.Clicked += OnClicked;
            cube.transform.localScale = transformOldCube.localScale / _reductionFactorSize;
            cube.SetColor(Random.ColorHSV());
        }

        _explosion.Explode(newCubes, transformOldCube.position);
    }
}
