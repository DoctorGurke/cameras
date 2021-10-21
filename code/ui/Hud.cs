using Sandbox.UI;

namespace Mantis.UI {
	public partial class MantisHud : Sandbox.HudEntity<RootPanel> {
		public MantisHud() {
			if(!IsClient) return;
			RootPanel.AddChild<ChatBox>();
			RootPanel.AddChild<Scoreboard<ScoreboardEntry>>();
		}
	}
}
