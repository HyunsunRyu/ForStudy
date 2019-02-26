using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Study
{
    [CreateAssetMenu(menuName = "Create Data/Custom Data")]
    public class Data : ScriptableObject
    {
        public List<int> values;
    }
}