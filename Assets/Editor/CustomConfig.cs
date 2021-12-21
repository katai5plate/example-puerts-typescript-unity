using System;
using System.Collections.Generic;
using Puerts;
using UnityEngine;

[Configure]
public class CustomCfg
{
    [Binding]
    static IEnumerable<Type> Bindings
    {
        get
        {
            return new List<Type>()
            {
                typeof(Array),
                typeof(Behaviour),
                typeof(Canvas),
                typeof(Collider),
                typeof(Collider2D),
                typeof(Collision),
                typeof(Collision2D),
                typeof(Component),
                typeof(ControllerColliderHit),
                typeof(Debug),
                typeof(Dictionary<string, string>.KeyCollection.Enumerator),
                typeof(Dictionary<string, string>.KeyCollection),
                typeof(Dictionary<string, string>),
                typeof(GameObject),
                typeof(Joint),
                typeof(Joint2D),
                typeof(List<string>.Enumerator),
                typeof(List<string>),
                typeof(Mathf),
                typeof(MonoBehaviour),
                typeof(object),
                typeof(ParticleSystem),
                typeof(PlayerPrefs),
                typeof(RenderTexture),
                typeof(Time),
                typeof(Transform),
                typeof(Type),
                typeof(UnityEngine.Events.UnityEvent),
                typeof(UnityEngine.Events.UnityEvent<bool>),
                typeof(UnityEngine.EventSystems.UIBehaviour),
                typeof(UnityEngine.Object),
                typeof(UnityEngine.UI.Button.ButtonClickedEvent),
                typeof(UnityEngine.UI.Button),
                typeof(UnityEngine.UI.InputField),
                typeof(UnityEngine.UI.Selectable),
                typeof(Vector2),
                typeof(Vector2Int),
                typeof(Vector3),
                typeof(Vector3Int),
                typeof(Vector4),
            };
        }
    }
}
