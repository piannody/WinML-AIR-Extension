﻿using System;
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
                new Dictionary<string, Func<FREObject, uint, FREObject[], FREObject>> {
                    {"init", InitController},
                    {"predict", Predict}
                };
            return FunctionsDict.Select(kvp => kvp.Key).ToArray();
        }

        private FREObject Predict(FREContext ctx, uint argc, FREObject[] argv) {
            if (argv[0] == FREObject.Zero) {
                return FREObject.Zero;
            }

            if (argv[1] == FREObject.Zero) {
                return FREObject.Zero;
            }

            var imagePath = argv[0].AsString();
            var modelPath = argv[1].AsString();
            try {
                EvaluateImageAsync(imagePath, modelPath);
            }
            catch (Exception e) {
                return new FreException(e).RawValue;
            }

            return FREObject.Zero;
        }

        private async Task EvaluateImageAsync(string imagePath, string modelPath) {
            