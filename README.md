
# Weather Console Service 

The weather service will receive a daily file that contains a list of cities. For each city in the file we need to retrieve the weather information from the Open Weather RESTFUL web service. Results will need to be stored in the outputfolder, so that each file only holds the information for each city for today’s date.We need to establish historic information, so file naming should cater for it.

## Authors

- [@abhiseky93](https://github.com/abhiseky93/Weather-Service)


## Documentation


Project Name : WeathersService
Framework    : .Net Framework 4.7.2



## API Reference

#### Get all items - OpenWeather
(Current weather data)

Description :
Access current weather data for any location on Earth including over 200,000 cities! We collect and process weather data from different sources such as global and local weather models, satellites, radars and a vast network of weather stations. Data is available in JSON, XML, or HTML format.



```http
#### Get by city name 

You can call by city name or city name, state code and country code. Please note that searching by states available only for the USA locations.

 api.openweathermap.org/data/2.5/weather?q={city name}&appid={API key}

```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `q`       | `string` | **Required** City Name     |
| `appid`   | `string` | **Required** Token         |

Example : api.openweathermap.org/data/2.5/weather?q=London&appid={API key}



#### Get item by city ID 

We recommend to call API by city ID to get unambiguous result for your city.

```http
api.openweathermap.org/data/2.5/weather?id={city id}&appid={API key}
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `id`      | `int`    | **Required** City id       |
| `appid`   | `string` | **Required** Token         |



## Installation

Install my-project with npm

```bash
  npm install my-project
  cd my-project
```
    
## Deployment

To deploy this project run

```bash
  npm run deploy
```


## How to execute Project  

Execute console application

Place files in Input Folder
Input : D:\DEVELOPMENT\M&G\Data\Input

Fetch API data with CITYCODE 
File Convenstion : CITYCODE_YYYYMMdd.txt 

Fetch API data with CITYNAME 
File Convenstion : CITYNAME_YYYYMMdd.txt 

Once you start console application 
All Output file will be created in
Output - D:\DEVELOPMENT\M&G\Data\Output
CITYCODE_YYYYMMdd_id_.txt
CITYNAME_YYYYMMdd_countryName_.txt

Postman Collection Attached : WeatherSearch.postman_collection.json

Console app can be mapped for scheduling of Scheduller

