using UnityEngine;

namespace utility
{
    public class VectorToMagnitude
    {
        public static Vector2 ToMagnitude(Vector2 origin, float magnitude) {
            return origin.normalized * magnitude;
        }
    }
}