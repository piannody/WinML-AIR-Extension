using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.AI.MachineLearning;

namespace MLANELib.WinML {
    public class SqueezeNetModel : IMachineLearningModel {
        private readonly List<string> _labels = new List<string>();
        public LearningModel LearningModel { get; set; }
        public LearningModelSession Session { get; set; }
        public LearningModelBinding Binding { get; set; }

        private const string LabelsJson = "{\"0\": \"tench, Tinca tinca\",\"1\": \"goldfish, Carassius auratus\",\"2\": \"great white shark, white shark