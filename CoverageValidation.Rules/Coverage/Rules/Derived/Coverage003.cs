﻿using CoverageValidation.Rules.Coverage.Rules.Foundation;
using CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons;
using Geico.Applications.Foundation.Rules;

namespace CoverageValidation.Rules.Coverage.Rules.Derived
{
    [Rule("Coverage003")]
    public class Coverage003 : CoverageRuleBase
    {
        private readonly CompareTwoCoveragesBase BINOtCarriedAndCOLIsNotCared = new CoverageAIsCarriedAndCoverageBIsNotCarried("BI", @"SLBI/PD");
        private readonly CompareCoverageToListBase AnyOfTHeFollowingAreCarried = new AnyAreCarried("MED", "UM","UMPD", "UMBIEC",@"SLUM/PD");

        public Coverage003()
        {
            ExcludedStates.AddRange(new[] { "NJ"});
            //Would need Basic Contract include
        }

        protected override bool If(Model.CoverageValidationRequest fact)
        {
           if  (!base.RuleApplies(fact))
            return false;

            var coverageA = GetCoverage(fact, BINOtCarriedAndCOLIsNotCared.CoverageAMnemonic);
            var coverageB = GetCoverage(fact, BINOtCarriedAndCOLIsNotCared.CoverageBMnemonic);
            var bINOtCarriedAndCOLIsNotCared = BINOtCarriedAndCOLIsNotCared.Comparer()(coverageA, coverageB);

            var anyOfTHeFollowingAreCarried = AnyOfTHeFollowingAreCarried.Comparer()(fact.PolicyCoverages);

            if (bINOtCarriedAndCOLIsNotCared && anyOfTHeFollowingAreCarried)
            {
                return true;
            }
            return false;
        }

        protected override void Then(Model.CoverageValidationRequest fact)
        {
            throw new System.NotImplementedException();
        }
    }
}