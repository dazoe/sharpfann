using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpFANN;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Layer> layers = new List<Layer>();
            layers.Add(Layer.Create(2));
            layers.Add(Layer.Create(3, ActivationFunction.FANN_SIGMOID_SYMMETRIC));
            layers.Add(Layer.Create(1, ActivationFunction.FANN_SIGMOID_SYMMETRIC));

            using (FannStandard fann = new FannStandard(layers))
            {
                Trainer trainer = new Trainer(fann);

                float desiredError = 0.001f;
                float mse = trainer.Train(@"TestFiles\xor.data", 500000, 100, desiredError);
                Console.WriteLine(mse.ToString());
            }

            Console.ReadLine();
        }
    }
}
