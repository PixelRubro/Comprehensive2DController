using PixelSpark.Comprehensive2DController.Direction;
using UnityEngine;

namespace PixelSpark.Comprehensive2DController.Helpers
{
    public class RaycastHelper
    {
        public static Vector2[] GetCastingPoints(Bounds bounds, int numberOfFiringPoints, EDirection direction, float offset)
        {
            if (numberOfFiringPoints < 3)
                numberOfFiringPoints = 3;

            float initialPoint = 0;
            float endPoint = 0;
            float distanceBetweenPoints = 0;
            Vector2[] castingPoints = new Vector2[numberOfFiringPoints];

            if (direction.IsVertical())
            {
                initialPoint = bounds.min.x + offset;
                endPoint = bounds.max.x - offset;
                distanceBetweenPoints = (endPoint - initialPoint) / (numberOfFiringPoints - 1);
                float y = 0;

                if (direction == EDirection.Up)
                    y = bounds.max.y;
                else
                    y = bounds.min.y;

                for (int i = 0; i < numberOfFiringPoints; i++)
                {
                    castingPoints[i] = new Vector2(initialPoint, y);
                    initialPoint += distanceBetweenPoints;
                }
            }
            else if (direction.IsHorizontal())
            {
                initialPoint = bounds.min.y + offset;
                endPoint = bounds.max.y - offset;
                distanceBetweenPoints = (endPoint - initialPoint) / (numberOfFiringPoints - 1);
                float x = 0;

                if (direction == EDirection.Right)
                    x = bounds.max.x;
                else
                    x = bounds.min.x;

                for (int i = 0; i < numberOfFiringPoints; i++)
                {
                    castingPoints[i] = new Vector2(x, initialPoint);
                    initialPoint += distanceBetweenPoints;
                }
            }

            return castingPoints;
        }
    }
}