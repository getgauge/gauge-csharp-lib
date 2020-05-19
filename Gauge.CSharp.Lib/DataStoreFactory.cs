/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
using System.Collections.Generic;

namespace Gauge.CSharp.Lib
{
    /// <summary>
    ///     Holds various DataStores, that have lifetime defined as per their scope.
    ///     Ex: ScenarioDataStore has its scope defined to a particular scenario.
    /// </summary>
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
        ///     Access the Suite level DataStore.
        /// </summary>
        public static DataStore SuiteDataStore => DataStores[DataStoreType.Suite];

        /// <summary>
        ///     Access the Specification level DataStore.
        /// </summary>
        public static DataStore SpecDataStore => DataStores[DataStoreType.Spec];

        /// <summary>
        ///     Access the Scenario level DataStore.
        /// </summary>
        public static DataStore ScenarioDataStore => DataStores[DataStoreType.Scenario];

        /// <summary>
        ///     <remarks>
        ///         FOR GAUGE INTERNAL USE ONLY.
        ///     </remarks>
        ///     Initializes the Suite level DataStore.
        /// </summary>
        public static void InitializeSuiteDataStore()
        {
            SuiteDataStore.Initialize();
        }

        /// <summary>
        ///     <remarks>
        ///         FOR GAUGE INTERNAL USE ONLY.
        ///     </remarks>
        ///     Initializes the Spec level DataStore.
        /// </summary>
        public static void InitializeSpecDataStore()
        {
            SpecDataStore.Initialize();
        }

        /// <summary>
        ///     <remarks>
        ///         FOR GAUGE INTERNAL USE ONLY.
        ///     </remarks>
        ///     Initializes the Scenario level DataStore.
        /// </summary>
        public static void InitializeScenarioDataStore()
        {
            ScenarioDataStore.Initialize();
        }
    }
}