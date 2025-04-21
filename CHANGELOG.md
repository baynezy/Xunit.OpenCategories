# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Fixed

- Bug where `Components` attribute was not adding the correct traits
- Bug where `Services` attribute was not adding the correct traits

## [2.1.0.8] - 2025-03-18

### Added

- Added `Services` attribute

## [2.0.0.7] - 2025-03-18

### Added

- Upgraded to .NET 8.0
- Migrated to xUnit v3
- Concurrently support xUnit v2 and v3

### Fixed

- Issue with PR builds not running properly due to not being able to check out the fork

## [1.2.0.5] - 2025-01-01

### Added

- Added `Components` attribute
- Feature branches now publish a beta package to GitHub Packages

### Fixed

- Fixed the issue with CI not running properly for PRs from forks
- Removed unnecessary spaced from attribute names in README
- Fixed possible multiple enumeration issue in test

## [1.1.0.4] - 2024-09-22

### Added

- Added `Component` attribute
- Improved descriptions for attributes
- Add additional testing for discoverers

## [1.0.4.5] - 2024-09-18

### Fixed

- Fixed issue with discoverers not being found in some cases

## [1.0.3.3] - 2024-09-10

### Changed

- Split tests to be single file per attribute for readability
- Reduce duplicate code for discoverers

## [1.0.2.2] - 2024-09-10

### Added

- README.md for NuGet.Org page

## [1.0.1.2] - 2024-09-10

### Fixes

- Documentation generation

## [1.0.0.1] - 2024-09-10

### Added

- Forked from [Xunit.Categories](https://github.com/brendanconnolly/Xunit.Categories)
- Renamed to Xunit.OpenCategories
- Converted to GitFlow
- Added a changelog
- Modified to use custom GA workflows
- Published to NuGet

[unreleased]: https://github.com/baynezy/Xunit.OpenCategories/compare/2.1.0.8...HEAD
[2.1.0.8]: https://github.com/baynezy/Xunit.OpenCategories/compare/2.0.0.7...2.1.0.8
[2.0.0.7]: https://github.com/baynezy/Xunit.OpenCategories/compare/1.2.0.5...2.0.0.7
[1.2.0.5]: https://github.com/baynezy/Xunit.OpenCategories/compare/1.1.0.4...1.2.0.5
[1.1.0.4]: https://github.com/baynezy/Xunit.OpenCategories/compare/1.0.4.5...1.1.0.4
[1.0.4.5]: https://github.com/baynezy/Xunit.OpenCategories/compare/1.0.3.3...1.0.4.5
[1.0.3.3]: https://github.com/baynezy/Xunit.OpenCategories/compare/1.0.2.2...1.0.3.3
[1.0.2.2]: https://github.com/baynezy/Xunit.OpenCategories/compare/1.0.1.2...1.0.2.2
[1.0.1.2]: https://github.com/baynezy/Xunit.OpenCategories/compare/1.0.0.1...1.0.1.2
[1.0.0.1]: https://github.com/baynezy/Xunit.OpenCategories/compare/12759d2d3b8613ed850a1d018ac1779cbb798a37...1.0.0.1
