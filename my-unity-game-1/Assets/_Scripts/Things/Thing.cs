using UnityEngine;

namespace Birdy
{
    public class Thing : MonoBehaviour
    {
        public ThingRuntimeSet RS_thing;

        private void OnEnable()
        {
	        RS_thing.Add(this);
        }

        private void OnDisable()
        {
	        RS_thing.Remove(this);
        }
    }
}