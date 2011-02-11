using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpFANN
{
    public class Layer : List<Neuron>
    {
        #region Static Factory Methods...
        public static Layer Create(int numNeurons)
        {
            return Create(numNeurons, Neuron.DEFAULT_ACTIVATION_FUNCTION,
                    Neuron.DEFAULT_ACTIVATION_STEEPNESS);
        }

        public static Layer Create(int numNeurons, ActivationFunction activationFunction)
        {
            return Create(numNeurons, activationFunction, Neuron.DEFAULT_ACTIVATION_STEEPNESS);
        }

        public static Layer Create(int numNeurons, ActivationFunction activationFunction, float steepness)
        {

            Layer layer = new Layer();
            for (int i = 0; i < numNeurons; i++)
                layer.Add(new Neuron(activationFunction, steepness));
            return layer;
        } 
        #endregion
    }
}
