using System.Collections.Generic;
using UnityEngine;

public class SpawnerCubes : MonoBehaviour
{
    [SerializeField] private Cube _prefabCube;
    [SerializeField] private Cube[] _cubesStage;

    private List<Cube> _newCubes = new List<Cube>();

    private int _maxChanceDivision = 100;
    private int _minNumberNewCubes = 2;
    private int _maxNumberNewCubes = 7;
    private int _reductionCoefficientChance = 2;
    private int _reductionFactorSize = 2;

    private void OnEnable()
    {
        for (int i = 0; i < _cubesStage.Length; i++)
        {
            _cubesStage[i].Clicked += OnClicked;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _newCubes.Count; i++)
        {
            _newCubes[i].Clicked -= OnClicked;
        }
    }

    private void OnClicked(Transform spawnPoint, int spawnChance)
    {
        if (Random.Range(0, _maxChanceDivision) < spawnChance)
        {
            CreateCubes(Random.Range(_minNumberNewCubes, _maxNumberNewCubes), spawnPoint, spawnChance);
        }
    }

    private void CreateCubes(int count, Transform transform, int chance)
    {
        chance /= _reductionCoefficientChance;

        for (int i = 0; i < count; i++)
        {
            Cube cube = Instantiate(_prefabCube, transform.position, transform.rotation);

            _newCubes.Add(cube);

            cube.SetChance(chance);
            cube.Clicked += OnClicked;
            cube.transform.localScale = transform.localScale / _reductionFactorSize;
            cube.SetColor(Random.ColorHSV());
        }
    }
}
