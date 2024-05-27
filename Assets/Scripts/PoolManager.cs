using System.Collections.Generic;
using UnityEngine;

namespace GenericLearning
{
    public class PoolManager : MonoBehaviour
    {
        public ObjectPool<Object> objPool;
        public ObjectPool<StatsHolder> statsPool;

        [SerializeField] private Object objectPrefab;
        [SerializeField] private StatsHolder statsHolder;
        private List<Object> activeObjects = new List<Object>();
        private List<StatsHolder> activeStatsHolder = new List<StatsHolder>();

        private void Start()
        {
            CreateObjectPools();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                Get();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                ReleaseAll();
            }
        }

        private void CreateObjectPools()
        {
            objPool = new ObjectPool<Object>(objectPrefab, 3);
            statsPool = new ObjectPool<StatsHolder>(statsHolder, 3);
        }

        [ContextMenu("Get")]
        private void Get()
        {
            activeObjects.Add(objPool.Get());
            activeStatsHolder.Add(statsPool.Get());
        }

        [ContextMenu("ReleaseAll")]
        private void ReleaseAll()
        {
            foreach (Object obj in activeObjects) {objPool.Release(obj); }
            activeObjects.Clear();
            foreach (StatsHolder obj in activeStatsHolder) { statsPool.Release(obj); }
            activeStatsHolder.Clear();
        }



    }
}
