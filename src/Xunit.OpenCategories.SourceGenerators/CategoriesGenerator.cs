using Microsoft.CodeAnalysis;
using Scriban;
using System;
using Xunit.OpenCategories.SourceGenerators.Shared;

namespace Xunit.OpenCategories.SourceGenerators
{
    [Generator]
    public class CategoriesGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            IncrementalValuesProvider<AdditionalText> categories = context.AdditionalTextsProvider
                .Where(f => f.Path.EndsWith("Xunit.OpenCategories.txt", StringComparison.Ordinal));

            IncrementalValueProvider<FileOptions> inputs = categories.Collect()
                .Select(
                    static (x, _) => new FileOptions { CategoryFiles = x });

            context.RegisterSourceOutput(inputs, Execute);
        }

        private static void Execute(SourceProductionContext context, FileOptions result)
        {
            var categoryNames = GeneratorHelpers.GetCategoryNames(result.CategoryFiles);

            string attributeTemplateFileContent = GeneratorHelpers.GetTemplateContent(typeof(CategoriesGenerator), "Attribute.liquid");
            string discovererTemplateFileContent = GeneratorHelpers.GetTemplateContent(typeof(CategoriesGenerator), "Discoverer.liquid");

            var attributeTemplate = Template.Parse(attributeTemplateFileContent);
            var discovererTemplate = Template.Parse(discovererTemplateFileContent);

            foreach (string categoryName in categoryNames)
            {
                GeneratorHelpers.CreateSourceFile(categoryName, $"{categoryName}Attribute.cs", attributeTemplate, context);
                GeneratorHelpers.CreateSourceFile(categoryName, $"{categoryName}Discoverer.cs", discovererTemplate, context);
            }
        }
    }
}
