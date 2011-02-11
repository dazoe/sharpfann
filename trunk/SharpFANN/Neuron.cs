using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpFANN
{
    public class Neuron
    {
        #region Static Members...
        public static ActivationFunction DEFAULT_ACTIVATION_FUNCTION { get { return ActivationFunction.FANN_SIGMOID_STEPWISE; } }
        public static float DEFAULT_ACTIVATION_STEEPNESS { get { return 0.5f; } } 
        #endregion

        #region Public Properties...
        public ActivationFunction ActivationFunction { get; private set; }
        public float Steepness { get; private set; } 
        #endregion

        #region Constructors...
        public Neuron()
        {
            Initialize(DEFAULT_ACTIVATION_FUNCTION, DEFAULT_ACTIVATION_STEEPNESS);
        }

        public Neuron(ActivationFunction activationFunction)
        {
            Initialize(activationFunction, DEFAULT_ACTIVATION_STEEPNESS);
        }

        public Neuron(ActivationFunction activationFunction, float steepness)
        {
            Initialize(activationFunction, steepness);
        }

        private void Initialize(ActivationFunction activationFunction, float steepness)
        {
            this.ActivationFunction = activationFunction;
            this.Steepness = steepness;
        } 
        #endregion

        
    }
}
