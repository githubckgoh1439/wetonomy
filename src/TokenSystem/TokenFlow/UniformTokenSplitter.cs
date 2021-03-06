// Copyright (c) Comrade Coop. All rights reserved.

using System.Collections.Generic;
using System.Numerics;
using StrongForce.Core;
using StrongForce.Core.Extensions;
using TokenSystem.TokenManagerBase;
using TokenSystem.TokenManagerBase.Actions;
using TokenSystem.Tokens;

namespace TokenSystem.TokenFlow
{
	public class UniformTokenSplitter : TokenSplitter
	{
		protected override void Split(Address tokenManager, IReadOnlyTaggedTokens availableTokens)
		{
			if (this.Recipients.Count <= 0)
			{
				return;
			}

			BigInteger splitAmount = availableTokens.TotalBalance / this.Recipients.Count;

			if (splitAmount <= 0)
			{
				return;
			}

			foreach (Address recipient in this.Recipients)
			{
				this.SendMessage(tokenManager, TransferAction.Type, new Dictionary<string, object>()
				{
					{ TransferAction.To, recipient.ToString() },
					{ TransferAction.Amount, splitAmount.ToString() },
				});
			}
		}
	}
}