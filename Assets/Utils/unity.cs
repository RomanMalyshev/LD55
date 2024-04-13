using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using Object = UnityEngine.Object;

public static partial class Ky {

  private static Transform _trashContainer = null;
  public static Transform TrashContainer {
    get {
      if (_trashContainer == null) {
        _trashContainer = new GameObject("Trash Container").transform;
        Object.DontDestroyOnLoad(_trashContainer);
        _trashContainer.gameObject.SetActive(false);
      }
      return _trashContainer;
    }
  }
  public static void EntrashContainersWithFirstPrefab(params Transform[] transforms) {
    foreach (var transform in transforms) {
      transform.GetChild(0).parent = TrashContainer;
      transform.DestroyChildren();
    }
  }
  public static void EntrashContainerWithFirstPrefab(Transform transform, out GameObject prefab) {
    prefab = transform.GetChild(0).gameObject;
    prefab.transform.parent = TrashContainer;
    transform.DestroyChildren();
  }
  public static void EntrashContainerWithFirstPrefab(Transform transform, out Transform prefab) {
    prefab = transform.GetChild(0);
    prefab.parent = TrashContainer;
    transform.DestroyChildren();
  }
  public static void EntrashContainerWithFirstPrefab<T>(Transform transform, out T prefab) where T : Component {
    prefab = transform.GetChild(0).GetComponent<T>();
    prefab.transform.parent = TrashContainer;
    transform.DestroyChildren();
  }

  public static readonly bool ApplicationIsDesktop = Application.isEditor || Application.platform.isAnyOf(RuntimePlatform.WindowsPlayer, RuntimePlatform.OSXPlayer, RuntimePlatform.LinuxPlayer);

  public static int? systemMemorySize =>
      Application.platform == RuntimePlatform.WebGLPlayer ? null :
      SystemInfo.systemMemorySize == 0 ? null :
      SystemInfo.systemMemorySize;

  public static float PixelPerInch => (Screen.dpi != 0 ? Screen.dpi : 72);
  public static float PixelPerCm => (Screen.dpi != 0 ? Screen.dpi : 72) / 2.54f;
  public static float PixelPerPoint => (Screen.dpi != 0 ? Screen.dpi : 72) / 72f;

  public static Vector2 Vector2half => new(.5f, .5f);
  public static Vector2 INVY2 => new(+1, -1);

  public static Vector2 Rotate(this Vector2 v, float angle) {
    var l = v.magnitude;
    var a = Atan2(v) + angle * Mathf.Deg2Rad;
    return new Vector2(l * Mathf.Cos(a), l * Mathf.Sin(a));
  }

  public static float RND => UnityEngine.Random.value % 1;
  public static float RNDS => -1f + 2f * (UnityEngine.Random.value % 1);

  public static Vector2 RND_CIRCLE {
    get {
      while (true) {
        var q = new Vector2(RNDS, RNDS);
        if (q.sqrMagnitude < 1)
          return q;
      }
    }
  }

  public static bool IsNewUpdatePeriod(double value, double period, double offset = 0f) => ((value - offset) % period) - Time.deltaTime < 0.0;
  public static bool IsNewUpdatePeriod(float value, float period, float offset = 0f) => ((value - offset) % period) - Time.deltaTime < 0f;
  public static bool IsNewUpdateTimePeriod(float period, float offset = 0f) => ((Time.time - offset) % period) - Time.deltaTime < 0f;

  public static T trace<T>(T o) {
    Debug.Log(o.str());
    return o;
  }

  public static float Atan2(Vector2 v) => Mathf.Atan2(v.y, v.x);
  public static float Atan2(Vector2Int v) => Mathf.Atan2(v.y, v.x);

  // @formatter:off

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T GetOrAddComponent<T>(this GameObject o) where T : Component { var c = o.GetComponent<T>(); return c != null ? c : o.AddComponent<T>(); }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool HasComponent<T>(this GameObject o) where T : Component { return o.GetComponent<T>() != null; }

  // @formatter:on

  public static Transform GetChildOrNull(this Transform transform, int index) => 0 <= index && index < transform.childCount ? transform.GetChild(index) : null;
  public static Transform[] GetChildren(this Transform transform) {
    var res = new Transform[transform.childCount];
    for (var i = 0; i < res.Length; i++)
      res[i] = transform.GetChild(i);
    return res;
  }

  public static void DestroyChildren(this Transform transform) {
    for (var i = transform.childCount - 1; i >= 0; i--)
      GameObject.Destroy(transform.GetChild(i).gameObject);
  }
  public static void DestroyChildrenImmediate(this Transform transform) {
    for (var i = transform.childCount - 1; i >= 0; i--)
      GameObject.DestroyImmediate(transform.GetChild(i).gameObject);
  }

  public static void ReparentChildren(this Transform src, Transform dst) {
    while (src.childCount > 0)
      src.GetChild(0).SetParent(dst);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static RectTransform rectTransform(this MonoBehaviour v) => v.transform as RectTransform;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static RectTransform rectTransform(this GameObject v) => v.transform as RectTransform;


  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float RoundPres(float v, float presision, float offset = 0) => Mathf.Round((v - offset) / presision) * presision + offset;

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Sqr(float v) => v * v;

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float InverseLerpUnclamped(float a, float b, float value) => a != b ? ((value - a) / (b - a)) : 0.0f;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Unlerp(float a, float b, float value) => Mathf.InverseLerp(a, b, value);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float UnlerpUnclamped(float a, float b, float value) => InverseLerpUnclamped(a, b, value);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Remap(float a0, float b0, float a1, float b1, float value0) => Mathf.Lerp(a1, b1, Unlerp(a0, b0, value0));
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float RemapUnclamped(float a0, float b0, float a1, float b1, float value0) => Mathf.LerpUnclamped(a1, b1, UnlerpUnclamped(a0, b0, value0));

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Rect RectUnion(Rect r0, Rect r1)
    => Rect.MinMaxRect(Mathf.Min(r0.xMin, r1.xMin), Mathf.Min(r0.yMin, r1.yMin), Mathf.Max(r0.xMax, r1.xMax), Mathf.Max(r0.yMax, r1.yMax));

  public static Color hexColor(string v) {
    if (v.StartsWith('#')) v = v.Substring(1);
    float parse(int pos, int length) => int.Parse(v.Substring(pos, length), System.Globalization.NumberStyles.HexNumber) / (length == 2 ? 255f : 15f);
    return v.Length > 4
        ? new Color(parse(0, 2), parse(2, 2), parse(4, 2), v.Length > 6 ? parse(6, 2) : 1f)
        : new Color(parse(0, 1), parse(1, 1), parse(2, 1), v.Length > 3 ? parse(3, 1) : 1f);
  }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector3 ToVector3(this Color c) => new(c.r, c.g, c.b);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector4 ToVector4(this Color c) => new(c.r, c.g, c.b, c.a);

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Color hexColor(uint c) => hexColor32(c);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Color32 hexColor32(uint c) => new((byte) ((c >> 16) & 0xff), (byte) ((c >> 8) & 0xff), (byte) ((c >> 0) & 0xff), (byte) ((c >> 24) & 0xff));
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float brightness(this Color c) => c.r * 0.299f + c.g * 0.587f + c.b * 0.114f;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float brightness(this Color32 c) => ((Color) c).brightness();
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static string web(this Color c) => web((Color32) c);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static string web(this uint c) => web(hexColor32(c));
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static string web(this Color32 c) => "#"
      + System.Convert.ToString(c.r, 16).PadLeft(2, '0')
      + System.Convert.ToString(c.g, 16).PadLeft(2, '0')
      + System.Convert.ToString(c.b, 16).PadLeft(2, '0')
      + System.Convert.ToString(c.a, 16).PadLeft(2, '0');

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Color GetPixelInv(this Texture2D tex, int x, int y) => tex.GetPixel(x, tex.height - 1 - y);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static void SetPixelInv(this Texture2D tex, int x, int y, Color color) => tex.SetPixel(x, tex.height - 1 - y, color);
  public static void CopyPixelInv(this Texture2D tex, Texture2D srcTex, int srcX, int srcY, int dstX, int dstY) => tex.SetPixelInv(dstX, dstY, srcTex.GetPixelInv(srcX, srcY));

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Color[] GetPixelsInv(this Texture2D tex, int x, int y, int width, int height) => tex.GetPixels(x, tex.height - height - y, width, height);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static void SetPixelsInv(this Texture2D tex, int x, int y, int width, int height, Color[] colors) => tex.SetPixels(x, tex.height - height - y, width, height, colors);
  public static void CopyPixelsInv(this Texture2D tex, Texture2D srcTex, int srcX, int srcY, int dstX, int dstY, int width, int height) => tex.SetPixelsInv(dstX, dstY, width, height, srcTex.GetPixelsInv(srcX, srcY, width, height));

  public static GameObject getUiGameObjectUnderPointer(int id = -1) {
    if (EventSystem.current == null) return null;
    var eventDataCurrentPosition = new PointerEventData(EventSystem.current);
    if (id == -1)
      eventDataCurrentPosition.position = Input.mousePosition;
    else if (Input.touches.Any(it => it.fingerId == id))
      eventDataCurrentPosition.position = Input.touches.First(it => it.fingerId == id).position;

    var results = new List<RaycastResult>();
    EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
    return results.Count > 0 ? results[0].gameObject : null;
  }

  public static Rect getRectOnCanvas(RectTransform target, Canvas canvas) {
    if (!target.gameObject.activeInHierarchy) return Rect.zero;
    var targetCorners = new Vector3[4];
    var canvasCorners = new Vector3[4];
    target.GetWorldCorners(targetCorners);
    canvas.gameObject.rectTransform().GetWorldCorners(canvasCorners);
    var scaleFactor = canvas.scaleFactor;
    var x0 = (+targetCorners[1].x - canvasCorners[1].x) / scaleFactor;
    var y0 = (-targetCorners[1].y + canvasCorners[1].y) / scaleFactor;
    var x1 = (+targetCorners[3].x - canvasCorners[1].x) / scaleFactor;
    var y1 = (-targetCorners[3].y + canvasCorners[1].y) / scaleFactor;
    return new Rect(x0, y0, x1 - x0, y1 - y0);
  }

}
