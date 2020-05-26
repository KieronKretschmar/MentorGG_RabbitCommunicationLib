# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0] - 2020-05-26
##Added
- SituationExtractionReport
- MatchDatabaseInsertionReport (MatchWriter was previously using TaskCompletedReport)
- Constructor for TaskCompletedReport
- Added enum values for SituationOperator to DemoAnalysisBlock

### Changed
- Make DemoAnalysisBlock props nullable and default to null

### Removed
- Property DemoAnalyzeReport.FramesPerSecond

## [0.9.0] - 2020-05-25
### Changed
- DemoAnalyzeReport, added Block field to indicate reason for Analysis blocking.

## [0.8.0] - 2020-05-05
### Changed
- Add methods for adding producers to be used in startup

## [0.7.1] - 2020-04-28
### Changed
- DemoAnalyzeReport, Add `Unknown` and `HttpHashCheck` possible failures.

## [0.7.0] - 2020-04-28
### Changed 
- DemoAnalyzeReport, Replace BoolParty with Enum

