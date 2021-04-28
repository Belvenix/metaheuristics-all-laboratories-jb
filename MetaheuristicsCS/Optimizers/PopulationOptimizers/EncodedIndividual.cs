﻿using Optimizers.PopulationOptimizers;
using EvaluationsCLI;
using Utility;
using System.Collections.Generic;
using System;

namespace MetaheuristicsCS.Optimizers.PopulationOptimizers
{
    class EncodedIndividual<Element> : Individual<Element>
    {

        private readonly int? seed;
        private readonly Shuffler shuffler;

        public EncodedIndividual(List<Element> genotype, int? seed)
            : base(genotype)
        {
            this.seed = seed;
            if (seed != null)
            {
                shuffler = new Shuffler(seed.Value);
            }
            else
            {
                shuffler = new Shuffler();
            }
            
        }

        public override double Evaluate(IEvaluation<Element> evaluation)
        {
            List<Element> shuffledGenotype = new List<Element>(this.Genotype);
            if (!evaluated)
            {
                Fitness = evaluation.dEvaluate(shuffledGenotype);
                evaluated = true;
            }

            return Fitness;
        }

    }
}
