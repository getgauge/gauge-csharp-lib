/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/
using System;

namespace Gauge.CSharp.Lib.Attribute
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AfterScenario : FilteredHookAttribute
    {
        /// <summary>
        ///     Creates a hook that gets executed after every Scenario.
        /// </summary>
        public AfterScenario()
        {
        }

        /// <summary>
        ///     Creates a hook that gets executed after every Scenario.
        ///     Filter the hook execution by specifying a tag.
        ///     This hook will be executed only after the scenario that has the given tag.
        ///     <para> Example:</para>
        ///     <para>
        ///         <code>[AfterScenario("some tag")]</code>
        ///     </para>
        /// </summary>
        /// <param name="filterTag">Tag to filter the hook execution by.</param>
        public AfterScenario(string filterTag) : base(filterTag)
        {
        }

        /// <summary>
        ///     Creates a hook that gets executed after every Scenario.
        ///     Filter the hook execution by specifying one (or more tags).
        ///     This hook will be executed only after the scenario that matches the tag filter.
        ///     <para> Example:</para>
        ///     <para>
        ///         <code>[AfterScenario("tag1", "tag2")]</code>
        ///     </para>
        ///     <para>
        ///         You can control the filtering logic by adding another attribute
        ///         <see cref="TagAggregationBehaviourAttribute" />.
        ///     </para>
        ///     <para>
        ///         By default the hooks are executed only if all the tags specified match the tags of the target
        ///         Spec/Scenario/Step.
        ///     </para>
        /// </summary>
        /// <param name="filterTags">Tags to filter the hook execution by. Multiple tags are passed as additional parameters.</param>
        public AfterScenario(params string[] filterTags) : base(filterTags)
        {
        }
    }
}