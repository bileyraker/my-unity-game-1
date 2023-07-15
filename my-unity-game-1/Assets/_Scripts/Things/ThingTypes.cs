using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Birdy.Things
{
	// This list enum also defines the default selection priority order.
	// i.e. if selecting an area with 10 doodads and 1 building, only the building will be selected by default.
    public enum ThingTypes
    {
		None,
		Doodad,
		Building,
		Unit
    }
}
