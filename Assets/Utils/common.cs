#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.IO;
using System.Text;
using UnityEngine;
using static System.Linq.Enumerable;
using static UnityEngine.Mathf;

public static partial class Ky {

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static O? LetClass<I, O>(this I? v, Func<I, O> func) where O : class => v == null ? null : func.Invoke(v);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static O? LetStruct<I, O>(this I? v, Func<I, O> func) where O : struct => v == null ? null : func.Invoke(v);

  public static double UNIX_TIME => DateTime.Now.ToFileTime() / 10_000_000.0;

  public static float NextFloat(this System.Random rnd) => (float) rnd.NextDouble();

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int? ParseOrNullInt(string s) => int.TryParse(s, out var n) ? n : null;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float? ParseOrNullFloat(string s) => float.TryParse(s, out var n) ? n : null;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int ParseOrDefaultInt(string s) => int.TryParse(s, out var n) ? n : 0;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float ParseOrDefaultFloat(string s) => float.TryParse(s, out var n) ? n : 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int pmod(int v, int m) => ((v % m) + m) % m;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float pmod(float v, float m) => ((v % m) + m) % m;

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Hypot(float x, float y) => Hypot(new Vector2(x, y));
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Hypot(Vector2 fr, Vector2 to) => Hypot(to - fr);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Hypot(Vector2 v) => v.sqrMagnitude;

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Hypot(float x, float y, float z) => Hypot(new Vector2(x, y));
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Hypot(Vector3 fr, Vector3 to) => Hypot(to - fr);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Hypot(Vector3 v) => v.sqrMagnitude;

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static double Floor(double f) => Math.Floor(f);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static double Ceil(double f) => Math.Ceiling(f);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static double Round(double f) => Math.Round(f);

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int FloorToInt(double f) => (int) Math.Floor(f);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int CeilToInt(double f) => (int) Math.Ceiling(f);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int RoundToInt(double f) => (int) Math.Round(f);

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static long FloorToLong(float v) => (long) Math.Floor(v);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static long FloorToLong(double v) => (long) Math.Floor(v);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static long CeilToLong(float v) => (long) Math.Ceiling(v);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static long CeilToLong(double v) => (long) Math.Ceiling(v);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static long RoundToLong(float v) => (long) Math.Round(v);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static long RoundToLong(double v) => (long) Math.Round(v);

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Prec(float v, int precision = 12) => float.Parse(String.Format("{0:0." + new String('0', precision) + "}", v));
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static double Prec(double v, int precision = 12) => double.Parse(String.Format("{0:0." + new String('0', precision) + "}", v));

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float FloorWithMult(float v, float m, float offset = 0) => Mathf.Floor((v - offset) * (1 / m)) * m + offset;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static double FloorWithMult(double v, double m, double offset = 0) => Math.Floor((v - offset) * (1 / m)) * m + offset;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float CeilWithMult(float v, float m, float offset = 0) => Mathf.Ceil((v - offset) * (1 / m)) * m + offset;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static double CeilWithMult(double v, double m, double offset = 0) => Math.Ceiling((v - offset) * (1 / m)) * m + offset;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float RoundWithMult(float v, float m, float offset = 0) => Mathf.Round((v - offset) * (1 / m)) * m + offset;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static double RoundWithMult(double v, double m, double offset = 0) => Math.Round((v - offset) * (1 / m)) * m + offset;

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float FloorWithMultPres(float v, float m, float offset = 0, int precision = 12) => Prec(FloorWithMult(v, m, offset), precision);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static double FloorWithMultPres(double v, double m, double offset = 0, int precision = 12) => Prec(FloorWithMult(v, m, offset), precision);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float CeilWithMultPres(float v, float m, float offset = 0, int precision = 12) => Prec(CeilWithMult(v, m, offset), precision);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static double CeilWithMultPres(double v, double m, double offset = 0, int precision = 12) => Prec(CeilWithMult(v, m, offset), precision);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float RoundWithMultPres(float v, float m, float offset = 0, int precision = 12) => Prec(RoundWithMult(v, m, offset), precision);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static double RoundWithMultPres(double v, double m, double offset = 0, int precision = 12) => Prec(RoundWithMult(v, m, offset), precision);

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int FloorToIntWithMult(float v, int m, int offset = 0) => FloorToInt((v - offset) / m) * m + offset;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int FloorToIntWithMult(double v, int m, int offset = 0) => FloorToInt((v - offset) / m) * m + offset;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int CeilToIntWithMult(float v, int m, int offset = 0) => CeilToInt((v - offset) / m) * m + offset;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int CeilToIntWithMult(double v, int m, int offset = 0) => CeilToInt((v - offset) / m) * m + offset;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int RoundToIntWithMult(float v, int m, int offset = 0) => RoundToInt((v - offset) / m) * m + offset;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int RoundToIntWithMult(double v, int m, int offset = 0) => RoundToInt((v - offset) / m) * m + offset;

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static string signStr(this int v) => v < 0 ? v.ToString() : "+" + v.ToString();
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static string signStr(this long v) => v < 0 ? v.ToString() : "+" + v.ToString();
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static string signStr(this float v) => v < 0 ? v.ToString() : "+" + v.ToString();
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static string signStr(this double v) => v < 0 ? v.ToString() : "+" + v.ToString();

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static string TrimStart(this string s, string v, bool repeatedly = false) {
    while (s.StartsWith(v)) {
      s = s.Substring(v.Length);
      if (!repeatedly) break;
    }
    return s;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static string TrimEnd(this string s, string v, bool repeatedly = false) {
    while (s.EndsWith(v)) {
      s = s.Remove(s.Length - v.Length);
      if (!repeatedly) break;
    }
    return s;
  }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static string InsertReplaced(this string s, int startIndex, int removeLength, string insertValue) =>
      s.Substring(0, startIndex) + insertValue + s.Substring(startIndex + removeLength);

  // @formatter:off

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T[] EnumValues<T>() => Enum.GetValues(typeof(T)).Cast<T>().ToArray();
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T?[] EnumValuesWithSpaces<T>() where T : struct => Range(Enum.GetValues(typeof(T)).Cast<int>().Max() + 1).CastNullableStruct<T>().ToArray();

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static IEnumerable<int> Range(int count) => Enumerable.Range(0, Max(0, count));
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static IEnumerable<int> RangeTo(int from, int to) => Enumerable.Range(from, Max(0, to - from));
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static IEnumerable<int> Range<T>(T[] arr) => Enumerable.Range(0, Max(0, arr.Length));
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static IEnumerable<int> Range<T>(List<T> list) => Enumerable.Range(0, list.Count);

  // @formatter:on

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static IEnumerable<T> nonNullOf<T>(params T?[] values) where T : class => values.OfType<T>();
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static IEnumerable<T> nonNullOf<T>(params T?[] values) where T : struct => values.OfType<T>();

  // @formatter:off

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool None<T>(this IEnumerable<T> src, Func<T, bool> selector) => !src.Any(selector);

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T also<T>(this T obj, Action<T> action) { action(obj); return obj; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static IEnumerable<T> orEmpty<T>(this IEnumerable<T>? src) => src ?? Empty<T>();
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static List<T> orEmpty<T>(this List<T>? src) => src ?? Empty<T>().ToList();

  // [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isAnyOf<T>(this T self, params T[] others) { foreach(var o in others) if (Equals(o, self)) return true; return false; }
  // [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isAnyOf<T>(this T self, IEnumerable<T> others) { foreach(var o in others) if (Equals(o, self)) return true; return false; }

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool All<T>(this T[,] self, Func<T, bool> predicate) { foreach(var o in self) if (!predicate(o)) return false; return true; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool All<T>(this T[,,] self, Func<T, bool> predicate) { foreach(var o in self) if (!predicate(o)) return false; return true; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool All<T>(this T[,,,] self, Func<T, bool> predicate) { foreach(var o in self) if (!predicate(o)) return false; return true; }

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isAnyOf(this sbyte self, params sbyte[] others) { foreach(var o in others) if (self == o) return true; return false; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isAnyOf(this byte self, params byte[] others) { foreach(var o in others) if (self == o) return true; return false; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isAnyOf(this short self, params short[] others) { foreach(var o in others) if (self == o) return true; return false; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isAnyOf(this ushort self, params ushort[] others) { foreach(var o in others) if (self == o) return true; return false; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isAnyOf(this int self, params int[] others) { foreach(var o in others) if (self == o) return true; return false; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isAnyOf(this uint self, params uint[] others) { foreach(var o in others) if (self == o) return true; return false; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isAnyOf(this long self, params long[] others) { foreach(var o in others) if (self == o) return true; return false; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isAnyOf(this ulong self, params ulong[] others) { foreach(var o in others) if (self == o) return true; return false; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isAnyOf(this nint self, params nint[] others) { foreach(var o in others) if (self == o) return true; return false; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isAnyOf(this nuint self, params nuint[] others) { foreach(var o in others) if (self == o) return true; return false; }

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isNoneOf(this sbyte self, params sbyte[] others) => !self.isAnyOf(others);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isNoneOf(this byte self, params byte[] others) => !self.isAnyOf(others);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isNoneOf(this short self, params short[] others) => !self.isAnyOf(others);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isNoneOf(this ushort self, params ushort[] others) => !self.isAnyOf(others);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isNoneOf(this int self, params int[] others) => !self.isAnyOf(others);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isNoneOf(this uint self, params uint[] others) => !self.isAnyOf(others);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isNoneOf(this long self, params long[] others) => !self.isAnyOf(others);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isNoneOf(this ulong self, params ulong[] others) => !self.isAnyOf(others);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isNoneOf(this nint self, params nint[] others) => !self.isAnyOf(others);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isNoneOf(this nuint self, params nuint[] others) => !self.isAnyOf(others);

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isAnyOf(this sbyte self, IEnumerable<sbyte> others) { foreach(var o in others) if (self == o) return true; return false; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isAnyOf(this byte self, IEnumerable<byte> others) { foreach(var o in others) if (self == o) return true; return false; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isAnyOf(this short self, IEnumerable<short> others) { foreach(var o in others) if (self == o) return true; return false; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isAnyOf(this ushort self, IEnumerable<ushort> others) { foreach(var o in others) if (self == o) return true; return false; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isAnyOf(this int self, IEnumerable<int> others) { foreach(var o in others) if (self == o) return true; return false; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isAnyOf(this uint self, IEnumerable<uint> others) { foreach(var o in others) if (self == o) return true; return false; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isAnyOf(this long self, IEnumerable<long> others) { foreach(var o in others) if (self == o) return true; return false; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isAnyOf(this ulong self, IEnumerable<ulong> others) { foreach(var o in others) if (self == o) return true; return false; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isAnyOf(this nint self, IEnumerable<nint> others) { foreach(var o in others) if (self == o) return true; return false; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isAnyOf(this nuint self, IEnumerable<nuint> others) { foreach(var o in others) if (self == o) return true; return false; }

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isNoneOf(this sbyte self, IEnumerable<sbyte> others) => !self.isAnyOf(others);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isNoneOf(this byte self, IEnumerable<byte> others) => !self.isAnyOf(others);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isNoneOf(this short self, IEnumerable<short> others) => !self.isAnyOf(others);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isNoneOf(this ushort self, IEnumerable<ushort> others) => !self.isAnyOf(others);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isNoneOf(this int self, IEnumerable<int> others) => !self.isAnyOf(others);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isNoneOf(this uint self, IEnumerable<uint> others) => !self.isAnyOf(others);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isNoneOf(this long self, IEnumerable<long> others) => !self.isAnyOf(others);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isNoneOf(this ulong self, IEnumerable<ulong> others) => !self.isAnyOf(others);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isNoneOf(this nint self, IEnumerable<nint> others) => !self.isAnyOf(others);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isNoneOf(this nuint self, IEnumerable<nuint> others) => !self.isAnyOf(others);

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isAnyOf<T>(this T? self, params T?[] others) { var c = EqualityComparer<T>.Default; foreach(var o in others) if (c.Equals(o, self)) return true; return false; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isAnyOf<T>(this T? self, IEnumerable<T?> others) { var c = EqualityComparer<T>.Default; foreach(var o in others) if (c.Equals(o, self)) return true; return false; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isNoneOf<T>(this T? self, params T?[] others) => !self.isAnyOf(others);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool isNoneOf<T>(this T? self, IEnumerable<T?> others) => !self.isAnyOf(others);

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsEmpty<T>(this IEnumerable<T> src) => !src.Any();
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsNotEmpty<T>(this IEnumerable<T> src) => src.Any();
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool IsNullOrEmpty<T>(this IEnumerable<T>? src) { if (src != null) return !src.Any(); return true; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int IndexOf<T>(this IEnumerable<T> src, T value) => Array.IndexOf(src.ToArray(), value);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int IndexOf<T>(this IEnumerable<T> src, Func<T, bool> predicate) => Array.FindIndex(src.ToArray(), predicate.Invoke);

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static IEnumerable<T> ForEach<T>(this IEnumerable<T> src, Action<T> func) { foreach(var v in src) func.Invoke(v); return src; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static IEnumerable<T> NonNull<T>(this IEnumerable<T> src) => src.Where(it => it != null);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> src) => src.OrderBy(it => RND);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Random<T>(this IList<T> src) => src[FloorToInt(RND * src.Count)];
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T Random<T>(this IList<T> src, System.Random rnd) => src[FloorToInt((float)rnd.NextDouble() * src.Count)];
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T FirstOr<T>(this IEnumerable<T> src, T defaultValue) => !src.IsEmpty() ? src.First() : defaultValue;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T LastOr<T>(this IEnumerable<T> src, T defaultValue) => !src.IsEmpty() ? src.Last() : defaultValue;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T? FirstOrNullClass<T>(this IEnumerable<T> src) where T : class => !src.IsEmpty() ? src.First() : null;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T? LastOrNullClass<T>(this IEnumerable<T> src) where T : class => !src.IsEmpty() ? src.Last() : null;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T? FirstOrNullStruct<T>(this IEnumerable<T> src) where T : struct => !src.IsEmpty() ? src.First() : null;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T? LastOrNullStruct<T>(this IEnumerable<T> src) where T : struct => !src.IsEmpty() ? src.Last() : null;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T FirstOr<T>(this IEnumerable<T> src, Func<T, bool> predicate, T defaultValue) { foreach (var v in src) if (predicate(v)) return v; return defaultValue; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T LastOr<T>(this IEnumerable<T> src, Func<T, bool> predicate, T defaultValue) { foreach (var v in src.Reverse()) if (predicate(v)) return v; return defaultValue; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T? FirstOrNullClass<T>(this IEnumerable<T> src, Func<T, bool> predicate) where T : class => src.FirstOrDefault(predicate);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T? LastOrNullClass<T>(this IEnumerable<T> src, Func<T, bool> predicate) where T : class => src.LastOrDefault(predicate);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T? FirstOrNullStruct<T>(this IEnumerable<T> src, Func<T, bool> predicate) where T : struct { foreach (var item in src) if (predicate(item)) return item; return null; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T? LastOrNullStruct<T>(this IEnumerable<T> src, Func<T, bool> predicate) where T : struct { foreach (var item in src) if (predicate(item)) return item; return null; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T? MinOrNullClass<T>(this IEnumerable<T> src) where T : class => src.IsNotEmpty() ? src.Min() : null;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T? MaxOrNullClass<T>(this IEnumerable<T> src) where T : class => src.IsNotEmpty() ? src.Max() : null;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T? MinOrNullStruct<T>(this IEnumerable<T> src) where T : struct => src.IsNotEmpty() ? src.Min() : null;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T? MaxOrNullStruct<T>(this IEnumerable<T> src) where T : struct => src.IsNotEmpty() ? src.Max() : null;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T GetOr<T>(this IList<T> src, int index, T defaultVal) => 0 <= index && index < src.Count ? src[index] : defaultVal;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T? GetOrNullClass<T>(this IList<T> src, int index) where T : class => 0 <= index && index < src.Count ? src[index] : null;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T? GetOrNullStruct<T>(this IList<T> src, int index) where T : struct => 0 <= index && index < src.Count ? src[index] : null;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T GetClamped<T>(this IList<T> src, int index) => src[Math.Clamp(index, 0, src.Count - 1)];
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T GetInClampedOr<T>(this IList<T> src, int index, T defaultVal) => src.IsNotEmpty() ? src[Math.Clamp(index, 0, src.Count - 1)] : defaultVal;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T GetModuled<T>(this IList<T> src, int index) => src[pmod(index, src.Count)];
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T GetInModuledOr<T>(this IList<T> src, int index, T defaultVal) => src.IsNotEmpty() ? src[pmod(index, src.Count)] : defaultVal;

  // @formatter:on

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static IEnumerable<T?> CastNullableStruct<T>(this IEnumerable src) where T : struct {
    foreach (var item in src)
      yield return item == null ? null : (T) item;
  }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static IEnumerable<T?> CastNullableClass<T>(this IEnumerable src) where T : class {
    foreach (var item in src)
      yield return item == null ? null : (T) item;
  }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static IEnumerable<(int, T)> WithIndex<T>(this IEnumerable<T> src) {
    var i = 0;
    foreach (var item in src)
      yield return (i++, item);
  }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int IndexOfMin<T>(this IEnumerable<T> src) where T : IComparable<T> {
    var s = src.ToArray();
    if (s.Length == 0) return -1;
    var index = 0;
    for (var i = 1; i < s.Length; i++)
      if (s[i].CompareTo(s[index]) < 0)
        index = i;
    return index;
  }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int IndexOfMax<T>(this IEnumerable<T> src) where T : IComparable<T> {
    var s = src.ToArray();
    if (s.Length == 0) return -1;
    var index = 0;
    for (var i = 1; i < s.Length; i++)
      if (s[i].CompareTo(s[index]) > 0)
        index = i;
    return index;
  }
  // @formatter:off

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T AddGet<T>(this List<T> src, T val) { src.Add(val); return val; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T RemoveGet<T>(this List<T> src, int index) { var item = src[index]; src.RemoveAt(index); return item; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T RemoveGetFirst<T>(this List<T> src) => src.RemoveGet(0);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T RemoveGetLast<T>(this List<T> src) => src.RemoveGet(Max(0, src.Count - 1));
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T? RemoveGetOrDefault<T>(this List<T> src, int index) { if (index >= src.Count) return default; var item = src[index]; src.RemoveAt(index); return item; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T? RemoveGetFirstOrDefault<T>(this List<T> src) => src.RemoveGetOrDefault(0);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T? RemoveGetLastOrDefault<T>(this List<T> src) => src.RemoveGetOrDefault(Max(0, src.Count - 1));
  // [MethodImpl(MethodImplOptions.AggressiveInlining)] public static void ExpandAndSet<V>(this List<V> src, int index, V value) { while (src.Count < index) src.Add(default); if (src.Count == index) src.Add(value); else src[index] = value; }

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T AddGet<T>(this HashSet<T> src, T val) { src.Add(val); return val; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T RemoveGet<T>(this HashSet<T> src, int index) { var item = src.ElementAt(index); src.Remove(item); return item; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T RemoveGetFirst<T>(this HashSet<T> src) => src.RemoveGet(0);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static T RemoveGetLast<T>(this HashSet<T> src) => src.RemoveGet(Max(0, src.Count - 1));

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static  V SetGet<K, V>(this IDictionary<K, V> src, K key, V val) { src[key] = val; return val; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static void AddRange<K, V>(this IDictionary<K, V> src, IDictionary<K, V> values) { foreach (var (key, value) in values) src.Add(key, value); }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static void AddRange<K, V>(this IDictionary<K, V> src, params (K key, V value)[] values) { foreach (var (key, value) in values) src.Add(key, value); }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static V? GetOrNullClass<K, V>(this IDictionary<K, V> src, K key) where V : class => src.ContainsKey(key) ? src[key] : null;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static V? GetOrNullStruct<K, V>(this IDictionary<K, V> src, K key) where V : struct => src.ContainsKey(key) ? src[key] : null;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static V GetOr<K, V>(this IDictionary<K, V> src, K key, V defaultVal) => src.ContainsKey(key) ? src[key] : defaultVal;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static V GetOrSetGet<K, V>(this IDictionary<K, V> src, K key, V defaultVal) => src.ContainsKey(key) ? src[key] : src[key] = defaultVal;
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static V GetOrSetGet<K, V>(this IDictionary<K, V> src, K key, Func<K, V> defaultValBlock) => src.ContainsKey(key) ? src[key] : src[key] = defaultValBlock.Invoke(key);
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static V RemoveGet<K, V>(this IDictionary<K, V> src, K key) { var item = src[key]; src.Remove(key); return item; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static V? RemoveGetOrNullClass<K, V>(this IDictionary<K, V> src, K key) where V : class { var item = src.GetOrNullClass(key); src.Remove(key); return item; }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static V? RemoveGetOrNullStruct<K, V>(this IDictionary<K, V> src, K key) where V : struct { var item = src.GetOrNullStruct(key); src.Remove(key); return item; }

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static IEnumerable<T> Distinct<T, TD>(this IEnumerable<T> src, Func<T, TD> predicate) => src.Distinct(new DistinctPredicateComparer<T,TD>(predicate));

  // @formatter:on

  private class DistinctPredicateComparer<T, TD> : IEqualityComparer<T> {
    private readonly Func<T, TD> predicate;
    public DistinctPredicateComparer(Func<T, TD> predicate) => this.predicate = predicate;
    public bool Equals(T x, T y) => predicate.Invoke(x)!.Equals(predicate.Invoke(y));
    public int GetHashCode(T obj) => predicate.Invoke(obj)!.GetHashCode();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static TResult[,] SelectArr<TSource, TResult>(this TSource[,] src, Func<TSource, TResult> selector) {
    var res = new TResult[src.GetLength(0), src.GetLength(1)];
    for (var i = 0; i < src.GetLength(0); i++)
      for (var j = 0; j < src.GetLength(1); j++)
        res[i, j] = selector.Invoke(src[i, j]);
    return res;
  }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static TResult[,,] SelectArr<TSource, TResult>(this TSource[,,] src, Func<TSource, TResult> selector) {
    var res = new TResult[src.GetLength(0), src.GetLength(1), src.GetLength(2)];
    for (var i = 0; i < src.GetLength(0); i++)
      for (var j = 0; j < src.GetLength(1); j++)
        for (var k = 0; k < src.GetLength(2); k++)
          res[i, j, k] = selector.Invoke(src[i, j, k]);
    return res;
  }
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static TResult[,,,] SelectArr<TSource, TResult>(this TSource[,,,] src, Func<TSource, TResult> selector) {
    var res = new TResult[src.GetLength(0), src.GetLength(1), src.GetLength(2), src.GetLength(3)];
    for (var i = 0; i < src.GetLength(0); i++)
      for (var j = 0; j < src.GetLength(1); j++)
        for (var k = 0; k < src.GetLength(2); k++)
          for (var l = 0; l < src.GetLength(3); l++)
            res[i, j, k, l] = selector.Invoke(src[i, j, k, l]);
    return res;
  }

  public static string str(this object source) {
    if (source == null) return "null";
    if (source is string str) return str;
    if (source is bool sourceBool) {
      if (sourceBool) return "true";
      if (!sourceBool) return "false";
    }
    if (source is IEnumerable enumerable) {
      var outElements = new List<string>();
      var multiline = false;
      foreach (var element in enumerable) {
        if (element is IEnumerable enumerableElement) {
          multiline = true;
          outElements.Add(enumerableElement.str());
        } else
          outElements.Add(element.str());
      }
      return source.GetType().Name + "(" + (multiline ? "\n" : "")
          + string.Join(multiline ? ",\n" : ", ", outElements)
          + (multiline ? "\n)" : ")");
    }
    return source.ToString();
  }

  public static string nicifyName(string src) {
    var sb = new StringBuilder();
    var wordBegin = 0;
    foreach (var i in Range(src.Length + 1)) {
      void makeWord() {
        var word = src.Substring(wordBegin, i - wordBegin);
        if (char.IsLetter(word[0])) {
          word = word.ToLower();
          if (sb.Length == 0 && char.IsLower(word[0]))
            word = char.ToUpper(word[0]) + word.Substring(1);
        }
        if (sb.Length > 0) sb.Append(" ");
        sb.Append(word);
        wordBegin = i;
      }
      if (i == src.Length) {
        if (wordBegin != i) makeWord();
      } else if (src[i] == '_') {
        if (wordBegin != i) makeWord();
        wordBegin = i + 1;
      } else if (char.IsLower(src[i])) {
        if (wordBegin != i)
          if (char.IsDigit(src[i - 1]))
            makeWord();
      } else if (char.IsUpper(src[i])) {
        if (wordBegin != i)
          if (char.IsLower(src[i - 1]) || char.IsDigit(src[i - 1])
              || (i < src.Length - 1 && char.IsUpper(src[i - 1]) && (char.IsLower(src[i + 1]) || char.IsDigit(src[i + 1]))))
            makeWord();
      } else if (char.IsDigit(src[i])) {
        if (wordBegin != i)
          if (!char.IsDigit(src[i - 1]))
            makeWord();
      }
    }
    return sb.ToString();
  }

  // @formatter:off

  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float easeIn(this Func<float, float> func, float val) => func.Invoke(Clamp01(val));
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float easeOut(this Func<float, float> func, float val) => 1f - func.Invoke(Clamp01(1f - val));
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float easeInOut(this Func<float, float> func, float val) => val < .5f
          ? func.Invoke(Clamp01(val * 2f)) / 2f
          : 1f - func.Invoke(Clamp01(2f - val * 2f)) / 2f;

  
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool ReadBool(this BinaryReader r) => r.ReadBoolean();
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static short ReadShort(this BinaryReader r) => r.ReadInt16();
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int ReadInt(this BinaryReader r) => r.ReadInt32();
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static uint ReadUInt(this BinaryReader r) => r.ReadUInt32();
  [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float ReadFloat(this BinaryReader r) => r.ReadSingle();
  
  // @formatter:on

  // these two functions copied from sources

  public static int Read7BitEncodedInt(this BinaryReader r) {
    // Read out an Int32 7 bits at a time.  The high bit
    // of the byte when on means to continue reading more bytes.
    int count = 0;
    int shift = 0;
    byte b;
    do {
      // Check for a corrupted stream.  Read a max of 5 bytes.
      // In a future version, add a DataFormatException.
      if (shift == 5 * 7) // 5 bytes max per Int32, shift += 7
          // throw new FormatException(Environment.GetResourceString("Format_Bad7BitInt32"));
        throw new FormatException("Format_Bad7BitInt32");

      // ReadByte handles end of stream cases for us.
      b = r.ReadByte();
      count |= (b & 0x7F) << shift;
      shift += 7;
    } while ((b & 0x80) != 0);
    return count;
  }
  public static void Write7BitEncodedInt(this BinaryWriter w, int value) {
    // Write out an int 7 bits at a time.  The high bit of the byte,
    // when on, tells reader to continue reading more bytes.
    uint v = (uint) value; // support negative numbers
    while (v >= 0x80) {
      w.Write((byte) (v | 0x80));
      v >>= 7;
    }
    w.Write((byte) v);
  }

  public static float superellipseRadius(float x, float y, float n, float angle)
    => x * y / Pow(Pow(Abs(y * Cos(Deg2Rad * angle)), n) + Pow(Abs(x * Sin(Deg2Rad * angle)), n), 1f / n);

}
