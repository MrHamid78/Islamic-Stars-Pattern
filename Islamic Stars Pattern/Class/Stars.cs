using Islamic_Stars_Pattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Islamic_Stars_Pattern.Class
{
    internal class Stars : Draw, FactoryInterface
    {
        public void drawPrimitivePattern()
        {
            throw new NotImplementedException();
        }

        void FactoryInterface.draw()
        {
            throw new NotImplementedException();
        }
    }
}
