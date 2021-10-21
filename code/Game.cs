using Sandbox;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Threading.Tasks;

using Mantis.Player;
using Mantis.UI;
using Mantis.Util;

namespace Mantis {

	public partial class MantisGame : Game {
		public MantisGame() {
			if(IsServer) {
				Log.Info("[SV] Gamemode created");

				_ = new MantisHud();
			}

			if(IsClient) {
				Log.Info("[CL] Gamemode created");
			}
		}

		public override void ClientJoined(Client client) {
			base.ClientJoined(client);

			var player = new MantisPlayer(client);
			client.Pawn = player;

			player.InitialRespawn();
		}

		public override void DoPlayerSuicide(Client cl) {
			if(cl.Pawn == null) return;

			cl.Pawn.Kill();
		}
	}
}
