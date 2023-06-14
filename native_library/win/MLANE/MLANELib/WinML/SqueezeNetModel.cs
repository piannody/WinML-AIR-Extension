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

        private const string LabelsJson = "{\"0\": \"tench, Tinca tinca\",\"1\": \"goldfish, Carassius auratus\",\"2\": \"great white shark, white shark, man-eater, man-eating shark, Carcharodon carcharias\",\"3\": \"tiger shark, Galeocerdo cuvieri\",\"4\": \"hammerhead, hammerhead shark\",\"5\": \"electric ray, crampfish, numbfish, torpedo\",\"6\": \"stingray\",\"7\": \"cock\",\"8\": \"hen\",\"9\": \"ostrich, Struthio camelus\",\"10\": \"brambling, Fringilla montifringilla\",\"11\": \"goldfinch, Carduelis carduelis\",\"12\": \"house finch, linnet, Carpodacus mexicanus\",\"13\": \"junco, sn