/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
namespace Gauge.CSharp.Lib;

public static class GaugeScreenshots
{
    private static ICustomScreenshotWriter screenshotWriter = new DefaultScreenshotWriter();

    internal static List<string> ScreenshotFiles = new List<string>();

    public static void RegisterCustomScreenshotWriter(ICustomScreenshotWriter customScreenshotWriter)
    {
        screenshotWriter = customScreenshotWriter;
    }

    public static void Capture()
    {
        ScreenshotFiles.Add(screenshotWriter.TakeScreenShot());
    }

    public static void CaptureWithDataStores(DataStore suiteDataStore, DataStore specDataStore, DataStore scenarioDataStore)
    {
        SetDataStores(suiteDataStore, specDataStore, scenarioDataStore);
        Capture();
    }

    private static void SetDataStores(DataStore suiteDataStore, DataStore specDataStore, DataStore scenarioDataStore)
    {
        lock (SuiteDataStore.Store)
        {
            SuiteDataStore.Store.Value = suiteDataStore;
        }
        lock (SpecDataStore.Store)
        {
            SpecDataStore.Store.Value = specDataStore;
        }
        lock (ScenarioDataStore.Store)
        {
            ScenarioDataStore.Store.Value = scenarioDataStore;
        }
    }
}