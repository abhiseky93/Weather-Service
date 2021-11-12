
# Weather Console Service 

The weather service will receive a daily file that contains a list of cities. For each city in the file we need to retrieve the weather information from the Open WeatherRESTful web service. Results will need to be stored in the outputfolder, so that each file only holds the information for each city for today’s date.We need to establish historic information, so file naming should cater for it.

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


