using UnityEngine;
using Puerts;
using System;

/// <summary>
/// JavaScript ファイルから、MonoBehaviour を操作する。
/// </summary>
public class JSLoader : MonoBehaviour
{
    // 以下、引数

    /// <summary>
    /// インポートする JS ファイル名
    /// </summary>
    public string fileName;

    /// <summary>
    /// ループ関数名
    /// </summary>
    public enum TickTiming
    {
        Update,
        FixedUpdate,
        LateUpdate,
        OnGUI
    }
    /// <summary>
    /// jsEnv.Tick を実行するタイミング
    /// </summary>
    [SerializeField]
    TickTiming tickTiming = TickTiming.Update;

    // 以下、jsEnv.Eval 時に上書きされる関数

    /* 固有処理あり */
    public Action _awake;
    public Action _onDestroy;
    public Action _update;

    /* Tick タイミング処理あり */
    public Action _fixedUpdate;
    public Action _lateUpdate;
    public Action _onGUI;

    /* その他 */
    public Action _start;
    public Action _reset;
    public Action<int> _onAnimatorIK;
    public Action _onAnimatorMove;
    public Action<bool> _onApplicationFocus;
    public Action<bool> _onApplicationPause;
    public Action _onApplicationQuit;
    public Action<float[], int> _onAudioFilterRead;
    public Action _onBecameInvisible;
    public Action _onBecameVisible;
    public Action _onBeforeTransformParentChanged;
    public Action _onCanvasGroupChanged;
    public Action<Collision> _onCollisionEnter;
    public Action<Collision2D> _onCollisionEnter2D;
    public Action<Collision> _onCollisionExit;
    public Action<Collision2D> _onCollisionExit2D;
    public Action<Collision> _onCollisionStay;
    public Action<Collision2D> _onCollisionStay2D;
    public Action _onConnectedToServer;
    public Action<ControllerColliderHit> _onControllerColliderHit;
    public Action _onDisable;
    //public Action<NetworkDisconnection> _onDisconnectedFromMasterServer;
    //public Action<NetworkDisconnection> _onDisconnectedFromServer;
    public Action _onDrawGizmos;
    public Action _onDrawGizmosSelected;
    public Action _onEnable;
    //public Action<NetworkConnectionError> _onFailedToConnect;
    //public Action<NetworkConnectionError> _onFailedToConnectToMasterServer;
    public Action<float> _onJointBreak;
    public Action<Joint2D> _onJointBreak2D;
    public Action<int> _onLevelWasLoaded;
    //public Action<MasterServerEvent> _onMasterServerEvent;
    public Action _onMouseDown;
    public Action _onMouseDrag;
    public Action _onMouseEnter;
    public Action _onMouseExit;
    public Action _onMouseOver;
    public Action _onMouseUp;
    public Action _onMouseUpAsButton;
    //public Action<NetworkMessageInfo> _onNetworkInstantiate;
    public Action<GameObject> _onParticleCollision;
    public Action _onParticleSystemStopped;
    public Action _onParticleTrigger;
    public Action _onParticleUpdateJobScheduled;
    //public Action<NetworkPlayer> _onPlayerConnected;
    //public Action<NetworkPlayer> _onPlayerDisconnected;
    public Action _onPostRender;
    public Action _onPreCull;
    public Action _onPreRender;
    public Action _onRectTransformDimensionsChange;
    public Action _onRectTransformRemoved;
    public Action<RenderTexture, RenderTexture> _onRenderImage;
    public Action _onRenderObject;
    //public Action<BitStream, NetworkMessageInfo> _onSerializeNetworkView;
    public Action _onServerInitialized;
    public Action _onTransformChildrenChanged;
    public Action _onTransformParentChanged;
    public Action<Collider> _onTriggerEnter;
    public Action<Collider2D> _onTriggerEnter2D;
    public Action<Collider> _onTriggerExit;
    public Action<Collider2D> _onTriggerExit2D;
    public Action<Collider> _onTriggerStay;
    public Action<Collider2D> _onTriggerStay2D;
    public Action _onValidate;
    public Action _onWillRenderObject;

    // 以下、内部で使用するもの

    /// <summary>
    /// JS からインポートされた MonoBehaviour
    /// </summary>
    /// <param name="monoBehaviour"></param>
    public delegate void This(JSLoader monoBehaviour);

    /// <summary>
    /// Puerts の JS 実行環境
    /// </summary>
    JsEnv jsEnv;

    private void Awake()
    {
        jsEnv = new JsEnv();
        jsEnv.Eval<This>("require('" + fileName + "')")(this);
        if (null != _awake) _awake();
    }
    private void OnDestroy()
    {
        if (null != _onDestroy) _onDestroy();
        jsEnv.Dispose();
    }
    private void Update()
    {
        if (tickTiming == TickTiming.Update) jsEnv.Tick();
        if (null != _update) _update();
    }

    /* Tick タイミング処理あり */

    private void FixedUpdate()
    {
        if (tickTiming == TickTiming.FixedUpdate) jsEnv.Tick();
        if (null != _fixedUpdate) _fixedUpdate();
    }
    private void LateUpdate()
    {
        if (tickTiming == TickTiming.LateUpdate) jsEnv.Tick();
        if (null != _lateUpdate) _lateUpdate();
    }
    private void OnGUI()
    {
        if (tickTiming == TickTiming.OnGUI) jsEnv.Tick();
        if (null != _onGUI) _onGUI();
    }

    /* その他 */

    private void Start()
    {
        if (null != _start) _start();
    }
    private void Reset()
    {
        if (null != _reset) _reset();
    }
    private void OnAnimatorIK(int layerIndex)
    {
        if (null != _onAnimatorIK) _onAnimatorIK(layerIndex);
    }
    private void OnAnimatorMove()
    {
        if (null != _onAnimatorMove) _onAnimatorMove();
    }
    private void OnApplicationFocus(bool focus)
    {
        if (null != _onApplicationFocus) _onApplicationFocus(focus);
    }
    private void OnApplicationPause(bool pause)
    {
        if (null != _onApplicationPause) _onApplicationPause(pause);
    }
    private void OnApplicationQuit()
    {
        if (null != _onApplicationQuit) _onApplicationQuit();
    }
    private void OnAudioFilterRead(float[] data, int channels)
    {
        if (null != _onAudioFilterRead) _onAudioFilterRead(data, channels);
    }
    private void OnBecameInvisible()
    {
        if (null != _onBecameInvisible) _onBecameInvisible();
    }
    private void OnBecameVisible()
    {
        if (null != _onBecameVisible) _onBecameVisible();
    }
    private void OnBeforeTransformParentChanged()
    {
        if (null != _onBeforeTransformParentChanged) _onBeforeTransformParentChanged();
    }
    private void OnCanvasGroupChanged()
    {
        if (null != _onCanvasGroupChanged) _onCanvasGroupChanged();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (null != _onCollisionEnter) _onCollisionEnter(collision);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (null != _onCollisionEnter2D) _onCollisionEnter2D(collision);
    }
    private void OnCollisionExit(Collision collision)
    {
        if (null != _onCollisionExit) _onCollisionExit(collision);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (null != _onCollisionExit2D) _onCollisionExit2D(collision);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (null != _onCollisionStay) _onCollisionStay(collision);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (null != _onCollisionStay2D) _onCollisionStay2D(collision);
    }
    private void OnConnectedToServer()
    {
        if (null != _onConnectedToServer) _onConnectedToServer();
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (null != _onControllerColliderHit) _onControllerColliderHit(hit);
    }
    private void OnDisable()
    {
        if (null != _onDisable) _onDisable();
    }
    //private void OnDisconnectedFromMasterServer(NetworkDisconnection info)
    //{
    //    if (null != _onDisconnectedFromMasterServer) _onDisconnectedFromMasterServer( info);
    //}
    //private void OnDisconnectedFromServer(NetworkDisconnection info)
    //{
    //    if (null != _onDisconnectedFromServer) _onDisconnectedFromServer( info);
    //}
    private void OnDrawGizmos()
    {
        if (null != _onDrawGizmos) _onDrawGizmos();
    }
    private void OnDrawGizmosSelected()
    {
        if (null != _onDrawGizmosSelected) _onDrawGizmosSelected();
    }
    private void OnEnable()
    {
        if (null != _onEnable) _onEnable();
    }
    //private void OnFailedToConnect(NetworkConnectionError error)
    //{
    //    if (null != _onFailedToConnect) _onFailedToConnect( error);
    //}
    //private void OnFailedToConnectToMasterServer(NetworkConnectionError error)
    //{
    //    if (null != _onFailedToConnectToMasterServer) _onFailedToConnectToMasterServer( error);
    //}
    private void OnJointBreak(float breakForce)
    {
        if (null != _onJointBreak) _onJointBreak(breakForce);
    }
    private void OnJointBreak2D(Joint2D joint)
    {
        if (null != _onJointBreak2D) _onJointBreak2D(joint);
    }
    private void OnLevelWasLoaded(int level)
    {
        if (null != _onLevelWasLoaded) _onLevelWasLoaded(level);
    }
    //private void OnMasterServerEvent(MasterServerEvent msEvent)
    //{
    //    if (null != _onMasterServerEvent) _onMasterServerEvent( msEvent);
    //}
    private void OnMouseDown()
    {
        if (null != _onMouseDown) _onMouseDown();
    }
    private void OnMouseDrag()
    {
        if (null != _onMouseDrag) _onMouseDrag();
    }
    private void OnMouseEnter()
    {
        if (null != _onMouseEnter) _onMouseEnter();
    }
    private void OnMouseExit()
    {
        if (null != _onMouseExit) _onMouseExit();
    }
    private void OnMouseOver()
    {
        if (null != _onMouseOver) _onMouseOver();
    }
    private void OnMouseUp()
    {
        if (null != _onMouseUp) _onMouseUp();
    }
    private void OnMouseUpAsButton()
    {
        if (null != _onMouseUpAsButton) _onMouseUpAsButton();
    }
    //private void OnNetworkInstantiate(NetworkMessageInfo info)
    //{
    //    if (null != _onNetworkInstantiate) _onNetworkInstantiate( info);
    //}
    private void OnParticleCollision(GameObject other)
    {
        if (null != _onParticleCollision) _onParticleCollision(other);
    }
    private void OnParticleSystemStopped()
    {
        if (null != _onParticleSystemStopped) _onParticleSystemStopped();
    }
    private void OnParticleTrigger()
    {
        if (null != _onParticleTrigger) _onParticleTrigger();
    }
    private void OnParticleUpdateJobScheduled()
    {
        if (null != _onParticleUpdateJobScheduled) _onParticleUpdateJobScheduled();
    }
    //private void OnPlayerConnected(NetworkPlayer player)
    //{
    //    if (null != _onPlayerConnected) _onPlayerConnected( player);
    //}
    //private void OnPlayerDisconnected(NetworkPlayer player)
    //{
    //    if (null != _onPlayerDisconnected) _onPlayerDisconnected( player);
    //}
    private void OnPostRender()
    {
        if (null != _onPostRender) _onPostRender();
    }
    private void OnPreCull()
    {
        if (null != _onPreCull) _onPreCull();
    }
    private void OnPreRender()
    {
        if (null != _onPreRender) _onPreRender();
    }
    private void OnRectTransformDimensionsChange()
    {
        if (null != _onRectTransformDimensionsChange) _onRectTransformDimensionsChange();
    }
    private void OnRectTransformRemoved()
    {
        if (null != _onRectTransformRemoved) _onRectTransformRemoved();
    }
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (null != _onRenderImage) _onRenderImage(source, destination);
    }
    private void OnRenderObject()
    {
        if (null != _onRenderObject) _onRenderObject();
    }
    //private void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    //{
    //    if (null != _onSerializeNetworkView) _onSerializeNetworkView( stream,  info);
    //}
    private void OnServerInitialized()
    {
        if (null != _onServerInitialized) _onServerInitialized();
    }
    private void OnTransformChildrenChanged()
    {
        if (null != _onTransformChildrenChanged) _onTransformChildrenChanged();
    }
    private void OnTransformParentChanged()
    {
        if (null != _onTransformParentChanged) _onTransformParentChanged();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (null != _onTriggerEnter) _onTriggerEnter(other);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (null != _onTriggerEnter2D) _onTriggerEnter2D(collision);
    }
    private void OnTriggerExit(Collider other)
    {
        if (null != _onTriggerExit) _onTriggerExit(other);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (null != _onTriggerExit2D) _onTriggerExit2D(collision);
    }
    private void OnTriggerStay(Collider other)
    {
        if (null != _onTriggerStay) _onTriggerStay(other);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (null != _onTriggerStay2D) _onTriggerStay2D(collision);
    }
    private void OnValidate()
    {
        if (null != _onValidate) _onValidate();
    }
    private void OnWillRenderObject()
    {
        if (null != _onWillRenderObject) _onWillRenderObject();
    }
}

