using Sandbox;
using System.Linq;
using Mantis.Entities;

namespace Mantis.Player {
	public partial class MantisCamera : Camera {
		[Net] Vector3 CameraPos { get; set; }
		[Net] Rotation CameraRot { get; set; }
		[Net] float CameraZNear { get; set; }
		[Net] float CameraZFar { get; set; }
		[Net] float CameraFov { get; set; }

		public void SetNewCamera(Vector3 pos, Rotation rot, float znear = 4, float zfar = 1000, float fov = 90) {
			CameraPos = pos;
			CameraRot = rot;
			CameraZNear = znear;
			CameraZFar = zfar;
			CameraFov = fov;
		}

		public void SetDefaultCamera() {
			var defaultcam = (ZoneCamera)Entity.All.Where((c) => c is ZoneCamera cam && cam.MasterCamera).FirstOrDefault();
			if(defaultcam == null)
				return;
			CameraPos = defaultcam.Position;
			CameraRot = defaultcam.Rotation;
			CameraZNear = defaultcam.ZNear;
			CameraZFar = defaultcam.ZFar;
			CameraFov = defaultcam.Fov;
		}

		public override void Update() {
			Pos = CameraPos;
			Rot = CameraRot;
			ZNear = CameraZNear;
			ZFar = CameraZFar;
			FieldOfView = CameraFov;

			Viewer = null;
		}

		public override void BuildInput(InputBuilder input) {
			base.BuildInput(input);
		}
	}
}
