using Sandbox;

namespace Mantis.Entities {
	[Library("ent_zone_camera")]
	[Hammer.EditorModel("models/editor/camera.vmdl")]
	[Hammer.EntityTool("Zone Camera", "Camera Zones", "Defines a Zone Camera Entity.")]
	[Hammer.FrustumBoundless("fov", "znear", "zfar")]
	public partial class ZoneCamera : Entity {

		/// <summary>
		/// Field of view in degrees
		/// </summary>
		[Property] public float Fov { get; set; } = 90.0f;

		/// <summary>
		/// Distance to the near plane
		/// </summary>
		[Property] public float ZNear { get; set; } = 4.0f;

		/// <summary>
		/// Distance to the far plane
		/// </summary>
		[Property] public float ZFar { get; set; } = 1000.0f;

		[Property(Title = "Starting Camera"), Net]
		public bool MasterCamera { get; set; } = false;
		public override void Spawn() {
			base.Spawn();
		}
	}
}
