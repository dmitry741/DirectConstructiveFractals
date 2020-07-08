using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DirectConstructiveFractals
{
    /// <summary>
    /// Декларация базовых методов конструктивных фракталолв.
    /// </summary>
    interface IConstructiveFractal
    {
        /// <summary>
        /// Построение конструктивного фрактала.
        /// </summary>
        /// <param name="N">Число шагов.</param>
        /// <param name="startPoint">Начальная точка сегмента.</param>
        /// <param name="endPoint">Конечная точка сегмента.</param>
        /// <returns>Коллекция точек PointF.</returns>
        IEnumerable<PointF> Build(int N, PointF startPoint, PointF endPoint);
    }
}
