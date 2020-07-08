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
            _angles = new double[_fragmentsPerStep];

            _angles[0] = _angles[3] = 0;
            _angles[1] = Math.PI / 3;
            _angles[2] = -Math.PI / 3;
        }
    }
}
