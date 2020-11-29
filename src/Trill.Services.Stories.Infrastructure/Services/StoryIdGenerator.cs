using System;
using IdGen;
using Trill.Services.Stories.Application.Services;

namespace Trill.Services.Stories.Infrastructure.Services
{
    internal class StoryIdGenerator : IStoryIdGenerator
    {
        private readonly IdGenerator _generator;

        public StoryIdGenerator()
        {
            var generatorId = 0;
            var generatorIdEnv = Environment.GetEnvironmentVariable("GENERATOR_ID");
            if (!string.IsNullOrWhiteSpace(generatorIdEnv))
            {
                int.TryParse(generatorIdEnv, out generatorId);
            }
            
            _generator = new IdGenerator(generatorId);
        }

        public long GenerateId() => _generator.CreateId();
    }
}