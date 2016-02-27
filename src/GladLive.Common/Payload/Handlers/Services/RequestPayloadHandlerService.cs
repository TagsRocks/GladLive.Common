﻿using GladNet.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GladLive.Common
{
	/// <summary>
	/// Request payload handler service that handles events based on the
	/// strategy provided.
	/// </summary>
	/// <typeparam name="TSessionType">Type of the session</typeparam>
	public class RequestPayloadHandlerService<TSessionType> : IRequestPayloadHandlerService<TSessionType>
		where TSessionType : INetPeer
	{
		private IPayloadHandlerStrategy<TSessionType> handlerStrat { get; }

		public RequestPayloadHandlerService(IPayloadHandlerStrategy<TSessionType> strat)
		{
			handlerStrat = strat;
		}

		public bool TryProcessPayload(PacketPayload payload, IMessageParameters parameters, TSessionType peer)
		{
			return handlerStrat.TryProcessPayload(payload, parameters, peer);
		}
	}
}
