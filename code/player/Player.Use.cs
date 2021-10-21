using Sandbox;

namespace Mantis.Player {
	public partial class MantisPlayer {
		protected override void TickPlayerUse() {
			// This is serverside only
			if(!Host.IsServer) return;

			// Turn prediction off
			using(Prediction.Off()) {
				if(Input.Pressed(InputButton.Use)) {
					Using = FindUsable();

					if(Using == null) {
						UseFail();
						return;
					}
				}

				if(!Input.Down(InputButton.Use)) {
					StopUsing();
					return;
				}

				if(!Using.IsValid())
					return;

				// If we move too far away or something we should probably ClearUse()?

				//
				// If use returns true then we can keep using it
				//

				if(Using is IUse use && use.OnUse(this)) {
					return;
				}

				StopUsing();
			}
		}
	}
}
