using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectConstructiveFractals
{
    class KochDirectFractal : AbstractDirectFractal
    {
        public KochDirectFractal()
        {
            _fragmentsPerStep = 4;
            _lenght = 1.0f / 3.0f;
            _angles = new double[] { 0, Math.PI / 3, -Math.PI / 3, 0 };
        }
    }
}
