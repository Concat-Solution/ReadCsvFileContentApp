using System;
using System.Collections.Generic;
using System.Text;

namespace ReadCsvFileContent
{
    public class Covid19Model
    {
        public string UrlConfirmed { get; set; } = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";
        public string UrlDeaths { get; set; } = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_deaths_global.csv";
        public string UrlRecovered { get; set; } = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_recovered_global.csv";
        public string Country { get; set; } = "Germany";
        public string Delimiter { get; set; } = ",";
        public int Today { get; set; }
        public int DayBefore { get; set; }
        public int DayBeforeDiff { get; set; }
        public string ErrorMessage { get; set; }
    }
}
