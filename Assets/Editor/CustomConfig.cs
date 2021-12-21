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
                typeof(Type),
                typeof(object),
                typeof(Array),
                typeof(Vector2),
                typeof(Vector3),
                typeof(Vector4),
                typeof(Vector2Int),
                typeof(Vector3Int),
                typeof(Transform),
                typeof(Collision),
                typeof(Collision2D),
                typeof(Collider),
                typeof(Collider2D),
                typeof(ControllerColliderHit),
                typeof(Joint),
                typeof(Joint2D),
                typeof(RenderTexture),
                typeof(GameObject),
                typeof(UnityEngine.Object),
                typeof(ParticleSystem),
                typeof(Canvas),
                typeof(Behaviour),
                typeof(MonoBehaviour),
                typeof(Component),
                typeof(Time),
                typeof(Debug),

                typeof(UnityEngine.EventSystems.UIBehaviour),
                typeof(UnityEngine.Events.UnityEvent<bool>),
                typeof(UnityEngine.UI.Selectable),
                typeof(UnityEngine.UI.Button),
                typeof(UnityEngine.UI.Button.ButtonClickedEvent),
                typeof(UnityEngine.Events.UnityEvent),
                typeof(UnityEngine.UI.InputField),
            };
        }
    }
}
