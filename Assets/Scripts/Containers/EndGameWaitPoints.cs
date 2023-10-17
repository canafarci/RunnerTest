using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Runner.Containers
{
    [System.Serializable]
    public class EndGameWaitPoints
    {
        [SerializeField] private WaitPoint[] _waitLocations;
        public WaitPoint GetWaitPoint()
        {
            WaitPoint point = _waitLocations.Where(x => !x.IsOccupied()).FirstOrDefault();
            point.SetIsOccupied(true);
            return point;
        }
    }
}
