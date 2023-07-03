using System;
using System.Collections.Generic;
using UnityEngine;

namespace Birdy
{
    public class Item : Selectable
    {
	    public ThingRuntimeSet itemRS;

	    private float _durability;
	    private float _maxDurability;

	    private Thing _holder;

	    public void Degrade(float amount)
		{
			_durability = Mathf.Clamp(_durability - amount, 0, _maxDurability);
		}

	    public void Mend(float amount)
	    {
		    _durability = Mathf.Clamp(_durability + amount, 0, _maxDurability);
	    }

	    public Thing Holder
	    {
		    get => _holder;
			set => _holder = value;
	    }
    }
}