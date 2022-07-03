﻿using System;
using System.Runtime.Serialization;

namespace East2West.Models.ChartModel
{
	[DataContract]
	public class DataPoint
	{
		public DataPoint(string label, double y)
		{
			this.Label = label;
			this.Y = y;
		}

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "label")]
		public string Label = "";

		//Explicitly setting the name to be used while serializing to JSON.
		[DataMember(Name = "y")]
		public Nullable<double> Y = null;
	}
}