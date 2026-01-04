using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Scriban;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Xunit.OpenCategories.SourceGenerators.Shared
{
    /// <summary>
    /// Helper class containing shared utility methods for source generation.
    /// </summary>
    internal static class GeneratorHelpers
    {
        /// <summary>
        /// Creates a source file from a template.
        /// </summary>
        public static void CreateSourceFile(string categoryName, string fileName, Template template, SourceProductionContext context)
        {
            string output = template.Render(new
            {
                categoryname = categoryName
            });

            context.AddSource(fileName, SourceText.From(output, Encoding.UTF8));
        }

        /// <summary>
        /// Gets the category names from the additional files.
        /// </summary>
        public static IEnumerable<string> GetCategoryNames(IEnumerable<AdditionalText> categoryFiles)
        {
            List<string> categoryNames = new List<string>();

            foreach (AdditionalText categoryFile in categoryFiles)
            {
                SourceText? categoryFileContent = categoryFile.GetText();

                if (categoryFileContent == null)
                {
                    continue;
                }

                categoryNames.AddRange(categoryFileContent.Lines.Select(l => l.ToString()));
            }

            return categoryNames;
        }

        /// <summary>
        /// Gets the content of an embedded template file.
        /// </summary>
        public static string GetTemplateContent(Type generatorType, string fileName)
        {
            string resourceName = $"{generatorType.Namespace}.Templates.{fileName}";
            using var stream = generatorType.Assembly.GetManifestResourceStream(resourceName);

            if (stream == null)
            {
                throw new InvalidOperationException($"Could not find embedded resource: {resourceName}");
            }

            using var streamReader = new StreamReader(stream);

            return streamReader.ReadToEnd();
        }
    }
}
