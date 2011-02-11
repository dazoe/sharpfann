using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpFANN
{
    public class FannStandard : BaseFann
    {
        public FannStandard(string file) : base(file) { }

        public FannStandard(List<Layer> layers) : base(layers) { }

        protected override IntPtr CreateAnn(int neuronCount, int[] neurons)
        {
            return fann_create_standard_array(neuronCount, neurons);
        }
    }
}
