﻿using System;

namespace ET
{
	public interface IEvent
	{
		Type Type { get; }
	}
	
	public abstract class AEvent<S, A>: IEvent where S: class, IScene where A: struct
	{
		public Type Type
		{
			get
			{
				return typeof (A);
			}
		}

		protected abstract ETTask Run(S scene, A a);

		public async ETTask Handle(IScene scene, A a)
		{
			try
			{
				await Run(scene as S, a);
			}
			catch (Exception e)
			{
				Log.Error(e);
			}
		}
	}
}