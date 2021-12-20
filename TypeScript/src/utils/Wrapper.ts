import { UnityEngine } from "csharp";

class EventFunctionDefines {
  _awake() {}
  _update() {}
  _onDestroy() {}

  _fixedUpdate() {}
  _lateUpdate() {}
  _onGUI() {}
  _start() {}
  _reset() {}
  _onAnimatorIK(layerIndex: number) {}
  _onAnimatorMove() {}
  _onApplicationFocus(focus: boolean) {}
  _onApplicationPause(pause: boolean) {}
  _onApplicationQuit() {}
  _onAudioFilterRead(data: number[], channels: number) {}
  _onBecameInvisible() {}
  _onBecameVisible() {}
  _onBeforeTransformParentChanged() {}
  _onCanvasGroupChanged() {}
  _onCollisionEnter(collision: UnityEngine.Collision) {}
  _onCollisionEnter2D(collision: UnityEngine.Collision2D) {}
  _onCollisionExit(collision: UnityEngine.Collision) {}
  _onCollisionExit2D(collision: UnityEngine.Collision2D) {}
  _onCollisionStay(collision: UnityEngine.Collision) {}
  _onCollisionStay2D(collision: UnityEngine.Collision2D) {}
  _onConnectedToServer() {}
  _onControllerColliderHit(hit: UnityEngine.ControllerColliderHit) {}
  _onDisable() {}
  // _onDisconnectedFromMasterServer(info: UnityEngine.NetworkDisconnection) {}
  // _onDisconnectedFromServer(info: UnityEngine.NetworkDisconnection) {}
  _onDrawGizmos() {}
  _onDrawGizmosSelected() {}
  _onEnable() {}
  // _onFailedToConnect(error: UnityEngine.NetworkConnectionError) {}
  // _onFailedToConnectToMasterServer(error: UnityEngine.NetworkConnectionError) {}
  _onJointBreak(breakForce: number) {}
  _onJointBreak2D(joint: UnityEngine.Joint2D) {}
  _onLevelWasLoaded(level: number) {}
  // _onMasterServerEvent(msEvent: UnityEngine.MasterServerEvent) {}
  _onMouseDown() {}
  _onMouseDrag() {}
  _onMouseEnter() {}
  _onMouseExit() {}
  _onMouseOver() {}
  _onMouseUp() {}
  _onMouseUpAsButton() {}
  // _onNetworkInstantiate(info: UnityEngine.NetworkMessageInfo) {}
  _onParticleCollision(other: UnityEngine.GameObject) {}
  _onParticleSystemStopped() {}
  _onParticleTrigger() {}
  _onParticleUpdateJobScheduled() {}
  // _onPlayerConnected(player: UnityEngine.NetworkPlayer) {}
  // _onPlayerDisconnected(player: UnityEngine.NetworkPlayer) {}
  _onPostRender() {}
  _onPreCull() {}
  _onPreRender() {}
  _onRectTransformDimensionsChange() {}
  _onRectTransformRemoved() {}
  _onRenderImage(
    source: UnityEngine.RenderTexture,
    destination: UnityEngine.RenderTexture
  ) {}
  _onRenderObject() {}
  // _onSerializeNetworkView(
  //   stream: UnityEngine.BitStream,
  //   info: UnityEngine.NetworkMessageInfo
  // ) {}
  _onServerInitialized() {}
  _onTransformChildrenChanged() {}
  _onTransformParentChanged() {}
  _onTriggerEnter(other: UnityEngine.Collider) {}
  _onTriggerEnter2D(collision: UnityEngine.Collider2D) {}
  _onTriggerExit(other: UnityEngine.Collider) {}
  _onTriggerExit2D(collision: UnityEngine.Collider2D) {}
  _onTriggerStay(other: UnityEngine.Collider) {}
  _onTriggerStay2D(collision: UnityEngine.Collider2D) {}
  _onValidate() {}
  _onWillRenderObject() {}
}

type EventFunctions = Partial<EventFunctionDefines>;
type BindedBehaviour = UnityEngine.MonoBehaviour & EventFunctions;

export default class extends EventFunctionDefines {
  $: BindedBehaviour;
  constructor(bindTo: BindedBehaviour) {
    super();
    this.$ = bindTo;
    const that = this;
    for (let name of Object.getOwnPropertyNames(
      EventFunctionDefines.prototype
    ) as (keyof EventFunctions)[]) {
      const fn = that[name];
      if (
        typeof fn === "function" &&
        fn.toString() !== super[name].toString()
      ) {
        this.$[name] = function (...args: unknown[]) {
          return (that[name] as (...a: unknown[]) => any)(...args);
        };
      }
    }
  }
}
