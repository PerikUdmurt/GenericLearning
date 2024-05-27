using GenericLearning;
using UnityEngine;

public class StatsHolder: MonoBehaviour, IPoolObject
{
	
	[SerializeField] private Range<float> damageRange = new Range<float>(1f, 3f);
	[SerializeField] private Range<float> healthRange = new Range<float>(30f, 100f);
	[SerializeField] private Range<int> levelRange = new Range<int>(1, 5);

    public void Deinit()
    {
        
    }

    public void Init()
    {
        
    }

    private void Start()
	{
		print($"{Random.Range(damageRange.minValue,damageRange.maxValue)}");
        print($"{Random.Range(healthRange.minValue, healthRange.maxValue)}");
        print($"{Random.Range(levelRange.minValue, levelRange.maxValue)}");
    }
}