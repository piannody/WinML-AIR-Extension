using System.Threading.Tasks;
using Windows.AI.MachineLearning;

namespace MLANELib.WinML {
    public interface IMachineLearningModel {
        LearningModel LearningModel { get; set; }

        LearningModelSession Session { get; set; }
        LearningModelBin