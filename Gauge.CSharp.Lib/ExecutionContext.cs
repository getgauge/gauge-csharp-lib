/*----------------------------------------------------------------
 *  Copyright (c) ThoughtWorks, Inc.
 *  Licensed under the Apache License, Version 2.0
 *  See LICENSE.txt in the project root for license information.
 *----------------------------------------------------------------*/


using System;
using System.Collections.Generic;
/**
* Gives the information about the current execution at runtime - spec, scenario, step that is running.
*/

namespace Gauge.CSharp.Lib {

    [Serializable()]
    public class ExecutionContext {
        public ExecutionContext(Specification specification, Scenario scenario, StepDetails stepDetails) {
            this.CurrentSpecification = specification;
            this.CurrentScenario = scenario;
            this.CurrentStep = stepDetails;
        }

        public ExecutionContext() {
            this.CurrentSpecification = new Specification();
            this.CurrentScenario = new Scenario();
            this.CurrentStep = new StepDetails();
        }

        /**
        * @return - The Current Specification that is executing.
        * Returns null in BeforeSuite and AfterSuite levels as no spec is executing then.
        */
        public Specification CurrentSpecification { get; }

        /**
        * @return - The Current Scenario that is executing.
        * Returns null in BeforeSuite, AfterSuite, BeforeSpec levels as no scenario is executing then.
        */
        public Scenario CurrentScenario { get; }

        /**
        * @return - The Current Step that is executing.
        * Returns null in BeforeSuite, AfterSuite, BeforeSpec, AfterSpec, BeforeScenario levels as no step is executing then.
        */
        public StepDetails CurrentStep { get; }

        /**
        * @return - All the valid tags (including scenario and spec tags) at the execution level.
        */
        public List<String> GetAllTags() {
            HashSet<String> specTags = new HashSet<String>(CurrentSpecification.Tags);
            foreach (var tag in CurrentScenario.Tags){
                specTags.Add(tag);    
            }
            return new List<String>(specTags);
        }

        [Serializable()]
        public class Specification {
            public Specification(String name, String fileName, bool isFailing, IEnumerable<String> tags) {
                this.Name = name;
                this.FileName = fileName;
                this.IsFailing = isFailing;
                this.Tags = tags;
            }

            public Specification() {
                Tags = new List<String>();
            }

            /**
            * @return List of all the tags in the Spec
            */
            public IEnumerable<String> Tags { get; }

            /**
            * @return True if the current spec is failing.
            */
            public Boolean IsFailing { get; }

            /**
            * @return Full path to the Spec
            */
            public String FileName { get; } = "";

            /**
            * @return The name of the Specification as mentioned in the Spec heading
            */
            public String Name { get; } = "";
        }
        
        [Serializable()]
        public class StepDetails {
            public StepDetails(String text, bool isFailing) {
                this.Text = text;
                this.IsFailing = isFailing;
            }

            public StepDetails() {
            }

            /**
            * @return True if the current spec or scenario or step is failing due to error.
            */
            public Boolean IsFailing { get; }

            /**
            * @return The name of the step as given in the spec file.
            */
            public String Text { get; } = "";
        }

        [Serializable]
        public class Scenario {
            public Scenario(String name, bool isFailing, IEnumerable<String> tags) {
                this.Name = name;
                this.IsFailing = isFailing;
                this.Tags = tags;
            }

            public Scenario() {
                Tags = new List<String>();
            }

            /**
            * @return List of all tags in just the scenario
            */
            public IEnumerable<String> Tags { get; }

            /**
            * @return True if the scenario or spec is failing
            */
            public Boolean IsFailing { get; }

            /**
            * @return Name of the Scenario as mentioned in the scenario heading
            */
            public String Name { get; } = "";
        }
    }
}