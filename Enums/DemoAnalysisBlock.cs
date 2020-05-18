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
        UnknownDemoDownloader = 1000,

        #region DemoFileWorker
        
        /// <summary>
        /// Indicates DemoFileWorker failed without a specified reason.
        /// </summary>
        UnknownDemoFileWorker = 2000,

        /// <summary>
        /// Indicates the Blob Download failed.
        /// </summary>
        BlobDownload = 2010,

        /// <summary>
        /// Indicates Unzipping Failed.
        /// </summary>
        Unzip = 2020,

        /// <summary>
        /// Indicates Http Communication for checking the Demo Hash failed.
        /// </summary>
        HttpHashCheck = 2030,

        /// <summary>
        /// Indicates the Demo was a duplicate.
        /// </summary>
        Duplicate = 2040,

        /// <summary>
        /// Indicates the Analyze step failed.
        /// </summary>
        Analyze = 2050,

        /// <summary>
        /// Indicates the Enrich step failed.
        /// </summary>
        Enrich = 2060,

        /// <summary>
        /// Indicates Storage to Redis failed.
        /// </summary>
        RedisStorage = 2070,
        #endregion

        /// <summary>
        /// Indicates MatchWriter failed without a specified reason.
        /// </summary>
        UnknownMatchWriter = 3000,

        /// <summary>
        /// Indicates SituationOperator failed without a specified reason.
        /// </summary>
        UnknownSituationOperator = 4000,
    }
}