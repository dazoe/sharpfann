using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpFANN
{
    public class FannShortcut : BaseFann
    {
        public FannShortcut(string file) : base(file) { }

        public FannShortcut(List<Layer> layers) : base(layers) { }

        protected override IntPtr CreateAnn(int neuronCount, int[] neurons)
        {
            return fann_create_shortcut_array(neuronCount, neurons);
        }
    }
}
