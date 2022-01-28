﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Ynov.Delannis.Specs.Features.Users
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class UserRegistrationFeature : object, Xunit.IClassFixture<UserRegistrationFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "UserRegistration.feature"
#line hidden
        
        public UserRegistrationFeature(UserRegistrationFeature.FixtureData fixtureData, Ynov_Delannis_Specs_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Users", "UserRegistration", "As a visitor, I want to create an account, so that I can be logged in", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 4
    #line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "UserName",
                        "Email",
                        "Password"});
            table1.AddRow(new string[] {
                        "elonMusk",
                        "elonMusk@tesla.com",
                        "Azerty123&"});
            table1.AddRow(new string[] {
                        "billGate",
                        "billgate@microsoft.com",
                        "Azerty123&"});
#line 5
        testRunner.Given("the following users exist", ((string)(null)), table1, "Given ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Trying to create an account as logged user")]
        [Xunit.TraitAttribute("FeatureTitle", "UserRegistration")]
        [Xunit.TraitAttribute("Description", "Trying to create an account as logged user")]
        public virtual void TryingToCreateAnAccountAsLoggedUser()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Trying to create an account as logged user", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 10
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
    this.FeatureBackground();
#line hidden
#line 11
        testRunner.Given("a logged user as \"elonMusk\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "UserName",
                            "Email",
                            "Password"});
                table2.AddRow(new string[] {
                            "elonMusk",
                            "elonMusk@tesla.com",
                            "Azerty123&"});
#line 12
        testRunner.And("my registration information", ((string)(null)), table2, "And ");
#line hidden
#line 15
        testRunner.When("I create an account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 16
        testRunner.Then("I should be notified with \"CantCreateAccountWhenLogged\" message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Trying to create an account with bad password")]
        [Xunit.TraitAttribute("FeatureTitle", "UserRegistration")]
        [Xunit.TraitAttribute("Description", "Trying to create an account with bad password")]
        [Xunit.InlineDataAttribute("Azert", new string[0])]
        [Xunit.InlineDataAttribute("Azerty1", new string[0])]
        [Xunit.InlineDataAttribute("Azerty&", new string[0])]
        [Xunit.InlineDataAttribute("azerty1&", new string[0])]
        [Xunit.InlineDataAttribute("", new string[0])]
        public virtual void TryingToCreateAnAccountWithBadPassword(string password, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Password", password);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Trying to create an account with bad password", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 18
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
    this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "UserName",
                            "Email"});
                table3.AddRow(new string[] {
                            "alexTeixeira",
                            "alex@gmail.com"});
#line 19
        testRunner.Given("my registration information", ((string)(null)), table3, "Given ");
#line hidden
#line 22
        testRunner.And(string.Format("I set an unvalid password \"{0}\"", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 23
        testRunner.When("I create an account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 24
        testRunner.Then("I should be notified with \"UnvalidPassword\" message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Trying to create an account with bad email")]
        [Xunit.TraitAttribute("FeatureTitle", "UserRegistration")]
        [Xunit.TraitAttribute("Description", "Trying to create an account with bad email")]
        [Xunit.InlineDataAttribute("alex", new string[0])]
        [Xunit.InlineDataAttribute("alex@gmail", new string[0])]
        [Xunit.InlineDataAttribute("alex@gmail.", new string[0])]
        [Xunit.InlineDataAttribute("alexgmail.com", new string[0])]
        [Xunit.InlineDataAttribute("", new string[0])]
        public virtual void TryingToCreateAnAccountWithBadEmail(string email, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Email", email);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Trying to create an account with bad email", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 34
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
    this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "UserName",
                            "Password"});
                table4.AddRow(new string[] {
                            "alexTeixeira",
                            "Azerty123&"});
#line 35
        testRunner.Given("my registration information", ((string)(null)), table4, "Given ");
#line hidden
#line 38
        testRunner.And(string.Format("I set an unvalid email \"{0}\"", email), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 39
        testRunner.When("I create an account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 40
        testRunner.Then("I should be notified with \"UnvalidEmail\" message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Trying to create an account with bad userName")]
        [Xunit.TraitAttribute("FeatureTitle", "UserRegistration")]
        [Xunit.TraitAttribute("Description", "Trying to create an account with bad userName")]
        [Xunit.InlineDataAttribute("Aze", new string[0])]
        [Xunit.InlineDataAttribute("Azer&", new string[0])]
        [Xunit.InlineDataAttribute("", new string[0])]
        public virtual void TryingToCreateAnAccountWithBadUserName(string userName, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("UserName", userName);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Trying to create an account with bad userName", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 50
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
    this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "Password",
                            "Email"});
                table5.AddRow(new string[] {
                            "Azerty123&",
                            "alex@gmail.com"});
#line 51
        testRunner.Given("my registration information", ((string)(null)), table5, "Given ");
#line hidden
#line 54
        testRunner.And(string.Format("I set an unvalid userName \"{0}\"", userName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 55
        testRunner.When("I create an account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 56
        testRunner.Then("I should be notified with \"UnvalidUsername\" message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Trying to create an account with an existing email")]
        [Xunit.TraitAttribute("FeatureTitle", "UserRegistration")]
        [Xunit.TraitAttribute("Description", "Trying to create an account with an existing email")]
        public virtual void TryingToCreateAnAccountWithAnExistingEmail()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Trying to create an account with an existing email", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 64
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
    this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                            "UserName",
                            "Email",
                            "Password"});
                table6.AddRow(new string[] {
                            "alexTeixeira",
                            "elonMusk@tesla.com",
                            "Azerty123&"});
#line 65
        testRunner.Given("my registration information", ((string)(null)), table6, "Given ");
#line hidden
#line 68
        testRunner.When("I create an account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 69
        testRunner.Then("I should be notified with \"EmailAlreadyExist\" message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Trying to create an account with an existing userName")]
        [Xunit.TraitAttribute("FeatureTitle", "UserRegistration")]
        [Xunit.TraitAttribute("Description", "Trying to create an account with an existing userName")]
        public virtual void TryingToCreateAnAccountWithAnExistingUserName()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Trying to create an account with an existing userName", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 71
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
    this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                            "UserName",
                            "Email",
                            "Password"});
                table7.AddRow(new string[] {
                            "elonMusk",
                            "alex1@gmail.com",
                            "Azerty123&"});
#line 72
        testRunner.Given("my registration information", ((string)(null)), table7, "Given ");
#line hidden
#line 75
        testRunner.When("I create an account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 76
        testRunner.Then("I should be notified with \"UserNameAlreadyExist\" message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="User create an account successfully")]
        [Xunit.TraitAttribute("FeatureTitle", "UserRegistration")]
        [Xunit.TraitAttribute("Description", "User create an account successfully")]
        public virtual void UserCreateAnAccountSuccessfully()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User create an account successfully", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 78
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
    this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                            "UserName",
                            "Email",
                            "Password"});
                table8.AddRow(new string[] {
                            "damien02",
                            "damien@gmail.com",
                            "Azerty123&"});
#line 79
      testRunner.Given("my registration information", ((string)(null)), table8, "Given ");
#line hidden
#line 82
      testRunner.When("I create an account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 83
      testRunner.Then("I should have an account", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                UserRegistrationFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                UserRegistrationFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion