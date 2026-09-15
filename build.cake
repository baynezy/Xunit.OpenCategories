var target = Argument("target", "Test");
var configuration = Argument("configuration", "Release");
var versionNumber = Argument("versionNumber", "0.1.0");
var projectName = "Xunit.OpenCategories";
var solutionFolder = "./";

bool UsesMsBuildTestRunner(FilePath project)
{
    var projectFile = System.Xml.Linq.XDocument.Load(project.FullPath);
    var projectNamespace = projectFile.Root?.Name.Namespace ?? System.Xml.Linq.XNamespace.None;
    foreach (var packageReference in projectFile.Descendants(projectNamespace + "PackageReference"))
    {
        var include = packageReference.Attribute("Include")?.Value;
        if (!string.IsNullOrWhiteSpace(include) && include.StartsWith("xunit.v3", StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }
    }

    return false;
}

Task("Clean")
    .Does(() =>
    {
        // Clean solution
        DotNetClean(solutionFolder);
    });

Task("Restore")
	.Does(() =>
	{
		// Restore NuGet packages
		DotNetRestore(solutionFolder);
	});

Task("Build")
	.Does(() =>
	{
		// Build solution
		DotNetBuild(solutionFolder, new DotNetBuildSettings
		{
			NoRestore = true,
			Configuration = configuration,
            ArgumentCustomization = args => args.Append("/p:Version=" + versionNumber)
		});
	});

Task("Test")
    .Does(() =>
    {
        // Run tests for all projects in the test folder
        var testProjects = GetFiles("./test/**/*.csproj");
        var msBuildTestProjects = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (var project in testProjects)
        {
            if (UsesMsBuildTestRunner(project))
            {
                msBuildTestProjects.Add(project.FullPath);
            }
        }

        foreach (var project in testProjects)
        {
            if (msBuildTestProjects.Contains(project.FullPath))
            {
                var repositoryRoot = MakeAbsolute(Directory("./")).FullPath;
                var repositoryRootUri = new System.Uri(repositoryRoot.EndsWith("/") ? repositoryRoot : $"{repositoryRoot}/");
                var projectRelativePath = System.Uri.UnescapeDataString(repositoryRootUri.MakeRelativeUri(new System.Uri(project.FullPath)).ToString());
                var projectIdentifier = System.Text.RegularExpressions.Regex.Replace(projectRelativePath, "[^A-Za-z0-9]+", "_").Trim('_');
                var resultFileName = $"{projectIdentifier}.results.xml";
                var settings = new DotNetMSBuildSettings();
                settings.Targets.Add("Test");
                settings.Properties.Add("Configuration", new List<string> { configuration });
                settings.Properties.Add(
                    "TestingPlatformCommandLineArguments",
                    new List<string> { $"--report-xunit-junit --report-xunit-junit-filename {resultFileName}" });

                DotNetMSBuild(project.FullPath, settings);

                continue;
            }

            DotNetTest(project.FullPath, new DotNetTestSettings
            {
                NoRestore = true,
                NoBuild = true,
                Configuration = configuration,
                Loggers = new string[] { "junit;LogFileName=results.xml" }
            });
        }
    });

Task("Pack")
    .Does(() =>
    {
        // Publish solution
        DotNetPack(solutionFolder, new DotNetPackSettings
        {
            NoRestore = true,
            NoBuild = true,
            Configuration = configuration,
            ArgumentCustomization = args => args.Append("/p:PackageVersion=" + versionNumber)
        });
    });

RunTarget(target);