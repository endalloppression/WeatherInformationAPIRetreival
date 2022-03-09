# WeatherInformationAPIRetreival
Overview
 
This is a console C# 5.0 program that will take command line input of one or more valid US zip codes in the command line.  The weather will be retrieved for each zip code using https://api.weatherbit.io.  The temperature will be printed out on a separte line per zip code entered.  If a user accidentally enters an invalid US zip code the program will iterate over regular expression pattern matching to remove the invalid input and continue on.  

Input EX.) 33101 33102 test 88 33104
The above input will remove the input "test" and "88" and will continue to get minutely weather tempurature for zip codes 33101, 33102, and 33104

Uses the following API to retrieve the weather information for the zip code:  
 
  https://www.weatherbit.io/api/swaggerui/weather-api-v2#!/Current32Weather32Data/get_current_postal_code_postal_code
 
Uses the following API key:
 
  24d6f2a2e84849e2aaa77f8e372ba681
 
