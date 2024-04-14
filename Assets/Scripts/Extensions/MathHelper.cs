using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public static class MathHelper {
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static int2 Rel(int side) {
    float2 pos = new float2(0, 1);

    float2x2 rotationMatrix = float2x2.Rotate(math.radians(45 * side));
    float2 rotPt = math.round(math.mul(pos, rotationMatrix));

    return new int2(rotPt);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool IsInRect(this int2 coords, int4 rect) {
    return coords.x >= rect.x && coords.x < rect.x + rect.z &&
        coords.y >= rect.y && coords.y < rect.y + rect.w;
  }
}
