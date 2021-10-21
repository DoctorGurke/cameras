using Sandbox;
using Mantis.Player;
using System.Linq;

namespace Mantis.Entities {
	[Library("trigger_camera_zone")]
	[Hammer.Solid]
	[Hammer.AutoApplyMaterial("materials/editor/toolscameratrigger.vmat")]
	[Hammer.EntityTool("Zone Trigger", "Camera Zones", "Defines a Camera Zone Volume.")]
	public partial class CameraZoneTrigger : BaseTrigger {
		[Property(Title = "Camera Entity")]
		[FGDType("target_destination")]
		public string CameraEntity { get; set; }
		public override void OnTouchStart(Entity toucher) {
			base.OnTouchStart(toucher);

			if(toucher is MantisPlayer player) {
				var cam = (ZoneCamera)FindAllByName(CameraEntity).FirstOrDefault();
				if(cam == null)
					return;
				(player.Camera as MantisCamera).SetNewCamera(cam.Position, cam.Rotation, cam.ZNear, cam.ZFar, cam.Fov);
			}
		}
	}
}
