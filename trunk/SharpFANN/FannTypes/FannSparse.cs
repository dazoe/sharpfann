using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpFANN
{
    public class FannSparse : BaseFann
    {
        private float _connectionRate = 1f; //default rate

        public FannSparse(string file) : base(file) { }

        public FannSparse(float connectionRate, List<Layer> layers) 
        {
            _connectionRate = connectionRate;

            Initialize(layers); 
        }

        protected override IntPtr CreateAnn(int neuronCount, int[] neurons)
        {
            return fann_create_sparse_array(_connectionRate, neuronCount, neurons);
        }
    }
}
