/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
using System;
using System.Collections.Generic;

namespace Gauge.CSharp.Lib
{


    /// <summary>
    /// Holds various DataStores, that have lifetime defined as per their scope.
    /// Ex: ScenarioDataStore has its scope defined to a particular scenario.
    /// <para>
    /// This API is deprecated. Use specific data stores instead.
    /// Ex SuiteDataStore, SpecDataStore, ScenarioDataStore etc.
    /// </para>
    /// </summary>
    [Obsolete(@"DataStoreFactory is no longer valid. This API will throw an Exception in multithreaded execution.")]
    public class DataStoreFactory
    {
        private static readonly Dictionary<DataStoreType, DataStore> DataStores =
            new Dictionary<DataStoreType, DataStore>
            {
                {DataStoreType.Suite, new DataStore()},
                {DataStoreType.Spec, new DataStore()},
                {DataStoreType.Scenario, new DataStore()}
            };

        /// <summary>
        /// Access the Suite level DataStore.
        /// <para>
        /// [Deprecated] Use <see cref="Gauge.CSharp.Lib.SuiteDataStore"/> class to fetch/add data.
        /// </para>
        /// </summary>
        [Obsolete(@"SuiteDataStore accessor is deprecated. Use SuiteDataStore.Get/SuiteDataStore.Put to fetch/add data.")]
        public static DataStore SuiteDataStore
        {
            get
            {
                if (IsMultithreaded())
                {
                    throw new Exception("DataStoreFactory cannot be used for multithreaded execution. Use SuiteDataStore.");
                }
                return DataStores[DataStoreType.Suite];
            }
        }

        /// <summary>
        /// Access the Specification level DataStore.
        /// <para>
        /// [Deprecated] Use <see cref="Gauge.CSharp.Lib.SpecDataStore"/> class to fetch/add data.
        /// </para>
        /// </summary>
        [Obsolete(@"SpecDataStore accessor is deprecated. Use SpecDataStore.Get/SpecDataStore.Put to fetch/add data.")]
        public static DataStore SpecDataStore
        {
            get
            {
                if (IsMultithreaded())
                {
                    throw new Exception("DataStoreFactory cannot be used for multithreaded execution. Use SpecDataStore.");
                }
                return DataStores[DataStoreType.Spec];
            }
        }

        /// <summary>
        /// Access the Scenario level DataStore.
        /// <para>
        /// [Deprecated] Use <see cref="Gauge.CSharp.Lib.ScenarioDataStore"/> class to fetch/add data.
        /// </para>
        /// </summary>
        [Obsolete(@"ScenarioDataStore accessor is deprecated. Use ScenarioDataStore.Get/ScenarioDataStore.Put to fetch/add data.")]
        public static DataStore ScenarioDataStore
        {
            get
            {
                if (IsMultithreaded())
                {
                    throw new Exception("DataStoreFactory cannot be used for multithreaded execution. Use ScenarioDataStore.");
                }
                return DataStores[DataStoreType.Spec];
            }
        }

        /// <summary>
        ///     <remarks>
        ///         FOR GAUGE INTERNAL USE ONLY.
        ///     </remarks>
        ///     Initializes the Suite level DataStore.
        /// </summary>
        public static void InitializeSuiteDataStore()
        {
            DataStores[DataStoreType.Suite].Initialize();
            Gauge.CSharp.Lib.SuiteDataStore.Clear();
        }

        /// <summary>
        ///     <remarks>
        ///         FOR GAUGE INTERNAL USE ONLY.
        ///     </remarks>
        ///     Initializes the Spec level DataStore.
        /// </summary>
        public static void InitializeSpecDataStore()
        {
            DataStores[DataStoreType.Spec].Initialize();
            Gauge.CSharp.Lib.SpecDataStore.Clear();
        }

        /// <summary>
        ///     <remarks>
        ///         FOR GAUGE INTERNAL USE ONLY.
        ///     </remarks>
        ///     Initializes the Scenario level DataStore.
        /// </summary>
        public static void InitializeScenarioDataStore()
        {
            DataStores[DataStoreType.Scenario].Initialize();
            Gauge.CSharp.Lib.ScenarioDataStore.Clear();
        }

        private static Boolean IsMultithreaded()
        {
            var multithreaded = Environment.GetEnvironmentVariable("enable_multithreading");
            if (String.IsNullOrEmpty(multithreaded))
                return false;
            return Boolean.Parse(multithreaded);
        }
    }
}