using BindOpen.Kernel.Data.Helpers;
using BindOpen.Labs.i18n;
using BindOpen.Labs.i18n.Models;
using System;
using System.IO;
using System.Reflection;

if (args?.Length < 1) return;

var defaultFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

var function = args[0]?.ToLower();

switch (function)
{
    case "convert":

        // i18n-tool convert <input_filepath> <target_filepath> <output_filepath>
        // i18n-tool convert "translation_en.json" "translation_fr.xlf" "translation_en.xlf"

        if (args?.Length < 4) return;

        try
        {
            var inputFilePath = args[1].GetConcatenatedPath(defaultFolderPath);
            var targetFilePath = args[2].GetConcatenatedPath(defaultFolderPath);
            var outputFilePath = args[3].GetConcatenatedPath(defaultFolderPath);

            var inputLoader = TranslationSheetLoaderFactory.Create(TranslationFileFormats.Json);
            var targetLoader = TranslationSheetLoaderFactory.Create(TranslationFileFormats.Xliff2);

            var inputSheet = inputLoader.Load(inputFilePath);
            var targetSheet = targetLoader.Load(targetFilePath);

            inputSheet.Merge(
                targetSheet, false,
                TranslationElementKinds.Entry_Locations,
                TranslationElementKinds.Entry_Target_Source,
                TranslationElementKinds.Entry_Source);

            var exporter = TranslationSheetExporterFactory.Create(TranslationFileFormats.Xliff2);
            var result = exporter.Export(inputSheet, outputFilePath);

            if (result)
            {
                Console.WriteLine("Translation file generated successfully");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occured while processing: " + ex.ToString());
        }
        break;
    case "translate":

        // i18n-tool translate <input_filepath> <output_filepath>
        // i18n-tool translate "W:\repos\Fidal\Fidal.MarkManager\src\UI\src\locale\_translation.fr.json" "W:\repos\Fidal\Fidal.MarkManager\src\UI\src\locale\_translation.en.json"

        if (args?.Length < 3) return;

        try
        {
            var inputFilePath = args[1].GetConcatenatedPath(defaultFolderPath);
            var outputFilePath = args[2].GetConcatenatedPath(defaultFolderPath);

            var inputLoader = TranslationSheetLoaderFactory.Create(TranslationFileFormats.Json);
            var targetLoader = TranslationSheetLoaderFactory.Create(TranslationFileFormats.Xliff2);

            var inputSheet = inputLoader.Load(inputFilePath);
            var outputSheet = File.Exists(outputFilePath) ? targetLoader.Load(outputFilePath) : new TranslationSheet();
            inputSheet.Merge(
                outputSheet,
                true,
                TranslationElementKinds.Entry_Target_Source,
                TranslationElementKinds.Entry_Target_Entry_Source);

            var exporter = TranslationSheetExporterFactory.Create(TranslationFileFormats.Json);
            var result = exporter.Export(inputSheet, outputFilePath);

            if (result)
            {
                Console.WriteLine("Translation file generated successfully");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occured while processing: " + ex.ToString());
        }

        break;
}
