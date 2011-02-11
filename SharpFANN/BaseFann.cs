using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;


namespace SharpFANN
{
    public abstract class BaseFann : IDisposable
    {
        #region FANN PInvoke Declaration...
        [DllImport("fannfloatMT.dll")]
        protected static extern System.IntPtr fann_create_standard_array(int numLayers, int[] layers);

        [DllImport("fannfloatMT.dll")]
        protected static extern System.IntPtr fann_create_sparse_array(float connection_rate, int numLayers,
            int[] layers);

        [DllImport("fannfloatMT.dll")]
        protected static extern System.IntPtr fann_create_shortcut_array(int numLayers, int[] layers);

        [DllImport("fannfloatMT.dll")]
        protected static extern float fann_get_MSE(System.IntPtr ann);

        [DllImport("fannfloatMT.dll")]
        protected static extern System.IntPtr fann_run(System.IntPtr ann, float[] input);

        [DllImport("fannfloatMT.dll")]
        protected static extern void fann_destroy(System.IntPtr ann);

        [DllImport("fannfloatMT.dll")]
        protected static extern int fann_get_num_input(System.IntPtr ann);

        [DllImport("fannfloatMT.dll")]
        protected static extern int fann_get_num_output(System.IntPtr ann);

        [DllImport("fannfloatMT.dll")]
        protected static extern int fann_get_total_neurons(System.IntPtr ann);

        [DllImport("fannfloatMT.dll")]
        protected static extern void fann_set_activation_function(System.IntPtr ann, int activation_function,
            int layer, int neuron);

        [DllImport("fannfloatMT.dll")]
        protected static extern void fann_set_activation_steepness(System.IntPtr ann, float steepness,
            int layer, int neuron);

        [DllImport("fannfloatMT.dll")]
        protected static extern System.IntPtr fann_get_neuron(System.IntPtr ann, int layer, int neuron);

        [DllImport("fannfloatMT.dll")]
        protected static extern System.IntPtr fann_create_from_file(String configuration_file);

        [DllImport("fannfloatMT.dll")]
        protected static extern int fann_save(System.IntPtr ann, String file);

        [DllImport("fannfloatMT.dll")]
        protected static extern int fann_save_to_fixed(System.IntPtr ann, String file);
        #endregion

        #region Properties...
        internal System.IntPtr Ann { get { return _ann; } }
        #endregion

        #region Private Members...
        private System.IntPtr _ann; 
        #endregion

        #region Constructors...
        /// <summary>
        /// Empty constructor used to override initiation order.
        /// </summary>
        public BaseFann()
        {

        }

        /// <summary>
        /// Load an existing FANN definition from a file
        /// </summary>
        public BaseFann(string file)
        {
            _ann = fann_create_from_file(file);
        }

        /// <summary>
        /// Create a new ANN with the provided layers.
        /// </summary>
        public BaseFann(List<Layer> layers)
        {
            Initialize(layers);
        }
        #endregion

        #region Public Methods...
        public int GetNumInputNeurons()
        {
            return fann_get_num_input(_ann);
        }

        public int GetNumOutputNeurons()
        {
            return fann_get_num_output(_ann);
        }

        public int GetTotalNumNeurons()
        {
            return fann_get_total_neurons(_ann);
        }

        public float[] Run(float[] input)
        {
            System.IntPtr result = fann_run(_ann, input);
            object output = Marshal.PtrToStructure(result, typeof(float[]));
            return (float[])output;
        }

        public bool Save(string file)
        {
            return fann_save(_ann, file) == 0;
        }

        public int SaveFixed(string file)
        {
            return fann_save_to_fixed(_ann, file);
        }

        public void Close()
        {
            if (_ann != null)
                fann_destroy(_ann);
        } 
        #endregion

        #region Protected Methods...
        protected void Initialize(List<Layer> layers)
        {
            if (layers == null) throw new DataMisalignedException("layers cannot be null.");
            if (layers.Count <= 0) throw new DataMisalignedException("layers must not be empty.");

            _ann = CreateAnn(layers.Count, layers.Select(x => x.Count).ToArray());

            AddLayers(layers);
        }
        #endregion

        #region Private Methods...
        private void AddLayers(List<Layer> layers)
        {
            //for each neuron in each layer, assign activation function and steepness
            Parallel.For(1, layers.Count, i =>
            {
                Layer layer = layers[i];
                Parallel.For(0, layer.Count, j =>
                    {
                        fann_set_activation_function(_ann, (int)layer[j].ActivationFunction, i, j);
                        fann_set_activation_steepness(_ann, (int)layer[j].Steepness, i, j);
                    });
            });
        } 
        #endregion

        #region Abstract Methods...
        protected abstract IntPtr CreateAnn(int neuronCount, int[] neurons);
        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Close();
        }

        #endregion
    }
}
