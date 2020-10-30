using NUnit.Framework;
using IndiaCensusDataDemo;
using IndiaCensusDataDemo.DataDAO;
using IndiaCensusDataDemo.DTO;
using System.Collections.Generic;


namespace CensusAnalyserTest
{
    public class Tests
    {
        public string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        public string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        public string indianStateCensusFilePath = @"C:\Users\MUKHESH\source\repos\IndianStatesCensus\CSVFiles\IndiaStateCensusData.csv";
        public string wrongHeaderIndianCensusFilePath = @"C:\Users\MUKHESH\source\repos\IndianStatesCensus\CSVFiles\WrongIndiaStateCensusData.csv";
        public string delimiterIndianCensusFilePath = @"C:\Users\MUKHESH\source\repos\IndianStatesCensus\CSVFiles\DelimiterIndiaStateCensusData.csv";
        public string indianStateCodeFilePath = @"C:\Users\MUKHESH\source\repos\IndianStatesCensus\CSVFiles\IndiaStateCode.csv";
        public string wrongIndianStateCensusFileType = @"C:\Users\MUKHESH\source\repos\IndianStatesCensus\CSVFiles\IndiaStateCode.txt";
        public string wrongIndianStateCodeFilePath = @"C:\Users\MUKHESH\source\repos\IndianStatesCensus\CSVFiles\WrongIndiaStateCode.csv";
        public string delimiterIndianStateCodeFilePath = @"C:\Users\MUKHESH\source\repos\IndianStatesCensus\CSVFiles\DelimiterIndiaStateCode.csv";
        public string indianStateCensusWrongFilePath = @"C:\Users\MUKHESH\source\repos\IndianStatesCensus\CSVFiles\IndiaStateCensus.csv";
        public string indianStateCodeWrongFilePath = @"C:\Users\MUKHESH\source\repos\IndianStatesCensus\CSVFiles\IndiaStateCensus.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecords;
        Dictionary<string, CensusDTO> stateRecords;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecords = new Dictionary<string, CensusDTO>();
            stateRecords = new Dictionary<string, CensusDTO>();

        }

        /// <summary>
        /// TC 1.1 : 
        /// Given the states code csv file when read should return census data count.
        /// </summary>
        [Test]
        public void GivenIndianStateCensusDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            totalRecords = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecords.Count);
        }

        /// <summary>
        /// TC 1.2 : 
        /// Given the wrong file path of code data should throw custom exception.
        /// </summary>
        [Test]
        public void GivenWrongIndianStateCodeDataFile_WhenRead_ShouldThrowCustomException()
        {
            var indianStateCodeResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indianStateCodeWrongFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.FILE_NOT_FOUND, indianStateCodeResult.exception);
        }

        /// <summary>
        /// TC 1.3 : 
        /// Given the wrong indian code file type should throw custom exceotion.
        /// </summary>
        [Test]
        public void GivenWrongIndianCodeDataFileType_WhenRead_ShouldThrowCustomException()
        {
            var indianStateCodeResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INVALID_FILE_TYPE, indianStateCodeResult.exception);
        }

        /// <summary>
        /// TC 1.4 : 
        /// Given the state code CSV file when correct but delimeter incorrect should throw custom exception.
        /// </summary>
        [Test]
        public void GivenStateCodeCSVFileWhenCorrectButDelimeterIncorrect_WhenRead_ShouldThrowCustomException()
        {
            var indianStateCodeResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, delimiterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INCOREECT_DELIMITER, indianStateCodeResult.exception);
        }

        /// <summary>
        /// TC 1.5 : 
        /// Given the state code CSV file when correct but CSV header incorrect should throw custom exception.
        /// </summary>
        [Test]
        public void GivenStateCodeCSVFileWhenCorrectButCSVHeaderIncorrect_WhenRead_ShouldThrowCustomException()
        {
            var indianStateCodeResult = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, wrongIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.Exception.INCORRECT_HEADER, indianStateCodeResult.exception);
        }
    }
}