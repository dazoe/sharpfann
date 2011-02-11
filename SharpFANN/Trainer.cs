using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace SharpFANN
{
    public class Trainer
    {
        #region PInvoke Methods...
        [DllImport("fannfloatMT.dll")]
        protected static extern void fann_train_on_file(System.IntPtr ann, string filename, int max_epochs, int epochs_between_reports, float desired_error);

        [DllImport("fannfloatMT.dll")]
        protected static extern float fann_get_MSE(System.IntPtr ann);
        #endregion

        #region Public Properties...
        BaseFann FannInstance { get; set; } 
        #endregion

        #region Public Constructor...
        public Trainer(BaseFann fann)
        {
            FannInstance = fann;
        } 
        #endregion

        #region Public Methods...
        public float Train(string trainingFile, int maxEpochs, int epochsBetweenReports, float desiredError)
        {
            fann_train_on_file(FannInstance.Ann, trainingFile, maxEpochs, epochsBetweenReports, desiredError);
            return fann_get_MSE(FannInstance.Ann);
        } 
        #endregion
    }
}
