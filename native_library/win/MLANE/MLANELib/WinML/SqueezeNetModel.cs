using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.AI.MachineLearning;

namespace MLANELib.WinML {
    public class SqueezeNetModel : IMachineLearningModel {
        private readonly List<string> _labels = new