using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.AI.MachineLearning;
using Windows.Graphics.Imaging;
using Windows.Media;
using Windows.Storage;
using MLANELib.WinML;
using TuaRua.FreSharp;
using TuaRua.FreSharp.Exceptions;
using FREObject = System.IntPtr;
using FREContext = System.IntPtr;

#pragma warning disable 4014

namespace MLANELib {
    public interface IMachineLearningInput { }

    public class MainController : FreSharpMainController {
        private SqueezeNetModel _model;
        private const string Result = "MLANE.OnModelResult";

        // Must have this function. It exposes the methods to our entry C++.
        public string[] GetFunctions() {
            FunctionsDict =
                new Dictionary<string, Func<FREObject, uint, FREObject[], FRE