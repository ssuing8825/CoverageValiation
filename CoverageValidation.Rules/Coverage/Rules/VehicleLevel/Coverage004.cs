﻿using CoverageValidation.Model.Resource.Validation;
using CoverageValidation.Rules.Coverage.Rules.Foundation.Comparisons;
using Geico.Applications.Foundation.Rules;

namespace CoverageValidation.Rules.Coverage.Rules.Derived
{
    [Rule("Coverage004")]
    public class Coverage004 : CoverageRuleBase
    {
        private readonly CoverageIsCarried CB = new CoverageIsCarried("CB");
        private readonly CoverageIsCarried COMP = new CoverageIsCarried("COMP");
        private readonly CoverageIsCarried COMB = new CoverageIsCarried("COLL");

        protected override void Then(CoverageRulesContainer fact)
        {
            throw new System.NotImplementedException();
        }

        public override bool Evaluate(CoverageRulesContainer fact)
        {
            var CB_Radio_Car_Phone_coverage_is_carried = CB.Comparer()(fact);
            var ComprehensiveIsNotCarried = !COMP.Comparer()(fact);
            var Combined_AdditionalIsNotCarried = !COMB.Comparer()(fact);

            if (CB_Radio_Car_Phone_coverage_is_carried && (ComprehensiveIsNotCarried || Combined_AdditionalIsNotCarried))
            {
                return true;
            }
            return false;
        }


        public override string ToString()
        {
            return string.Format("{0} {1} {2}", CB, COMP, COMB);
        }

    }
}
