using Sandbox;
using System;
using System.Linq;

namespace Mantis.Player {
	partial class MantisPlayer : Sandbox.Player {

		TimeSince timeSinceDied;
		public float RespawnTime = 1;

		[Net]
		public float MaxHealth { get; set; } = 100;

		public Clothing.Container Clothing = new();

		public virtual void InitialRespawn() {
			Respawn();
		}

		public MantisPlayer() {

		}

		public MantisPlayer(Client cl) : this() {
			Clothing.LoadFromClient(cl);
		}

		public override void Respawn() {
			SetModel("models/citizen/citizen.vmdl");

			Controller = new MantisController();
			Animator = new MantisAnimator();
			Camera = new MantisCamera();
			(Camera as MantisCamera).SetDefaultCamera();

			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;

			Clothing.DressEntity(this);

			Host.AssertServer();

			LifeState = LifeState.Alive;
			Health = MaxHealth;
			Velocity = Vector3.Zero;
			WaterLevel.Clear();

			CreateHull();

			Game.Current?.MoveToSpawnpoint(this);
			ResetInterpolation();
		}

		public override void Simulate(Client cl) {
			if(LifeState == LifeState.Dead) {
				if(timeSinceDied > RespawnTime && IsServer) {
					Respawn();
				}
				return;
			}

			TickPlayerUse();

			var controller = GetActiveController();
			controller?.Simulate(cl, this, GetActiveAnimator());

			SimulateActiveChild(cl, ActiveChild);
		}

		public override void OnKilled() {
			Game.Current?.OnKilled(this);

			timeSinceDied = 0;
			LifeState = LifeState.Dead;
			StopUsing();

			EnableDrawing = false;
		}
	}
}
