using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEditor.Compilation;
using Debug = UnityEngine.Debug;

[InitializeOnLoad]
internal static class CompilationTime
{
    private static readonly Dictionary<string, Stopwatch> _dictionary;
    private static readonly Stopwatch _stopwatch;

    static CompilationTime()
    {
        CompilationPipeline.compilationStarted += OnCompilationStarted;
        CompilationPipeline.compilationFinished += OnCompilationFinished;
        CompilationPipeline.assemblyCompilationStarted += OnAssemblyCompilationStarted;
        CompilationPipeline.assemblyCompilationFinished += OnAssemblyCompilationFinished;
        //CompilationPipeline.assemblyCompilationNotRequired += OnAssemblyCompilationNotRequired;
        _dictionary = new Dictionary<string, Stopwatch>();
        _stopwatch = new Stopwatch();
    }

    private static void OnAssemblyCompilationNotRequired(string name)
    {
        Debug.Log($"Assembly {name} not required to recompile ");
    }

    private static void OnCompilationStarted(object context)
    {
        _dictionary.Clear();
        _stopwatch.Start();
    }

    private static void OnCompilationFinished(object context)
    {
        var elapsed = _stopwatch.Elapsed;

        _stopwatch.Stop();
        _stopwatch.Reset();

        foreach (var pair in _dictionary)
        {
            Debug.Log($"Assembly {pair.Key.Replace("Library/ScriptAssemblies/", string.Empty)} " +
                      $"built in {pair.Value.Elapsed.TotalSeconds:F} seconds.");
        }

        Debug.Log($"Total compilation time: {elapsed.TotalSeconds:F} seconds.");
    }

    private static void OnAssemblyCompilationStarted(string value)
    {
        _dictionary.Add(value, Stopwatch.StartNew());
    }

    private static void OnAssemblyCompilationFinished(string value, CompilerMessage[] messages)
    {
        _dictionary[value].Stop();
    }
}