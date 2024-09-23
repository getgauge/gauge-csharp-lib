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

    public static void CaptureByStream(int streamId)
    {
        SetDataStores(streamId);
        ScreenshotFiles.Add(screenshotWriter.TakeScreenShot());
    }

    private static void SetDataStores(int streamId)
    {
        var dataStore = DataStoreFactory.GetDataStoresByStream(streamId);
        lock (SuiteDataStore.Store)
        {
            SuiteDataStore.Store.Value = DataStoreFactory.SuiteDataStore;
        }
        lock (SpecDataStore.Store)
        {
            SpecDataStore.Store.Value = dataStore.GetValueOrDefault(DataStoreType.Spec, null);
        }
        lock (ScenarioDataStore.Store)
        {
            ScenarioDataStore.Store.Value = dataStore.GetValueOrDefault(DataStoreType.Scenario, null);
        }
    }
}