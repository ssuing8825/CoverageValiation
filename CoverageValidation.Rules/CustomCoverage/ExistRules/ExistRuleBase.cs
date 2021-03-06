﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoverageValidation.Model;

namespace CoverageValidation.Rules.ExistRules
{
    public abstract class ExistRuleBase : RuleBase
    {
        protected string CoverageAMnemonic;
        protected string CoverageBMnemonic;

        protected Model.Coverage CoverageAFact;
        protected Model.Coverage CoverageBFact;
        protected Func<Model.Coverage, Model.Coverage, bool> comparer;

        public override RuleBase Execute()
        {
            IsValid = comparer(CoverageAFact, CoverageBFact);
            Message = ToString();
            return this;
        }

        public ExistRuleBase SetMnemonicForCoverageA(string coverageAMnemonic)
        {
            CoverageAMnemonic = coverageAMnemonic;
            return this;
        }

        public ExistRuleBase SetMnemonicForCoverageB(string coverageAMnemonic)
        {
            CoverageBMnemonic = coverageAMnemonic;
            return this;
        }

        public override RuleBase Build(CoverageRulesContainer request)
        {
            CoverageAFact = GetCoverage(request, CoverageAMnemonic);
            CoverageBFact = GetCoverage(request, CoverageBMnemonic);
            return this;
        }
        public override string ToString()
        {
            return string.Format("If {0} is carried than {1} must be carried", CoverageAMnemonic, CoverageBMnemonic);
        }
    }
}
