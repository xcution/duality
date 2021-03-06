﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Duality;
using Duality.Components;
using Duality.Components.Physics;
using Duality.Editor;
using Duality.Properties;

namespace Duality.Plugins.Steering.Sample
{
	/// <summary>
	/// This Component assigns the objects RigidBody radius (taken from its first circle shape) directly to its
	/// Agent radius, and applies the Agents suggested velocity back to the RigidBody. The sole purpose if this
	/// Component is to visualize Agent behavior.
	/// </summary>
	[Serializable]
	[RequiredComponent(typeof(Agent))]
	[RequiredComponent(typeof(Transform))]
	[RequiredComponent(typeof(RigidBody))]
	[EditorHintCategory(typeof(CoreRes), CoreResNames.CategoryAI)]
	public class AgentAttributeTranslator : Component, ICmpUpdatable
	{
		public void OnUpdate()
		{
			RigidBody		rigidBody	= this.GameObj.RigidBody;
			Agent			agent		= GameObj.GetComponent<Agent>();
			CircleShapeInfo shapeInfo	= rigidBody.Shapes.OfType<CircleShapeInfo>().FirstOrDefault();
			if (shapeInfo != null)
			{
				agent.Radius = shapeInfo.Radius;
			}
			rigidBody.AngularVelocity = 0.0f;
			rigidBody.LinearVelocity = agent.SuggestedVel;
		}
	}
}
