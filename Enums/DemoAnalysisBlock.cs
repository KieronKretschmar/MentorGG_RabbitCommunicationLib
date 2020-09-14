namespace RabbitCommunicationLib.Enums
{
    /// <summary>
    /// Possible failures when Analzing a Demo.
    /// </summary>
    public enum DemoAnalysisBlock : int
    {

        /// <summary>
        /// Unknown Block.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Indicates DemoDownloader failed without a specified reason.
        /// </summary>
        DemoDownloader_Unknown = 1000,

        /// <summary>
        /// Indicates Demo is expected to be deleted from Valve servers because it is too old (2 weeks).
        /// </summary>
        DemoDownloader_TooOld = 1010,

        #region DemoFileWorker
        
        /// <summary>
        /// Indicates DemoFileWorker failed without a specified reason.
        /// </summary>
        DemoFileWorker_Unknown = 2000,

        /// <summary>
        /// Indicates the Blob Download failed.
        /// </summary>
        DemoFileWorker_BlobDownload = 2010,

        /// <summary>
        /// Indicates Unzipping Failed.
        /// </summary>
        DemoFileWorker_Unzip = 2020,

        /// <summary>
        /// Indicates Http Communication for checking the Demo Hash failed.
        /// </summary>
        DemoFileWorker_HttpHashCheck = 2030,

        /// <summary>
        /// Indicates the Demo was a duplicate.
        /// </summary>
        DemoFileWorker_Duplicate = 2040,

        /// <summary>
        /// Indicates the Analyze step failed.
        /// </summary>
        DemoFileWorker_Analyze = 2050,

        /// <summary>
        /// Indicates the Enrich step failed.
        /// </summary>
        DemoFileWorker_Enrich = 2060,

        /// <summary>
        /// Indicates Storage to Redis failed.
        /// </summary>
        DemoFileWorker_RedisStorage = 2070,
        #endregion

        #region MatchWriter
        /// <summary>
        /// Indicates MatchWriter failed without a specified reason.
        /// </summary>
        MatchWriter_Unknown = 3000,

        /// <summary>
        /// Indicates MatchWriter failed because the MatchDataSet was not available.
        /// </summary>
        MatchWriter_MatchDataSetUnavailable = 3010,

        /// <summary>
        /// Indicates MatchWriter failed because the MatchDataSet was found in redis, but accessing it failed.
        /// </summary>
        MatchWriter_RedisConnectionFailed = 3020,

        /// <summary>
        /// Indicates MatchWriter failed because of a TimeoutException, mostly caused by the database or redis connection timing out.
        /// </summary>
        MatchWriter_Timeout = 3030,

        /// <summary>
        /// Indicates MatchWriter failed during upload, most likely because database constraints (e.g. ForeignKeys or non-nullable columns) weren't satisfied.
        /// </summary>
        MatchWriter_DatabaseUpload = 3040,

        #endregion

        #region SituationOperator
        /// <summary>
        /// Indicates SituationOperator failed without a specified reason.
        /// </summary>
        SituationOperator_Unknown = 4000,

        /// <summary>
        /// Indicates access of MatchDataSet failed
        /// </summary>
        SituationOperator_MatchDataSetAccess = 4010,

        #endregion
    }
}