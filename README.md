# ✈️ Holiday Search 🏖️
A Console app designed to read data from two Json files, run queries on the parsed data, and return records.

## :link: Table of contents
1. [Introduction](#introduction)
2. [Application Overview](#applicationOverview)
   1. [Technologies Used](#technologiesUsed)
   2. [Query References](#QueryReference)
3. [Pre-Requisites](#prerequisites)
4. [Getting Started](#gettingStarted)
   1. [Application Setup](#applicationsetup)
   2. [Restore Dependencies](#restoredependencies)
   3. [Running Tests](#runningtests)
   4. [Main Entry Point](#mainentrypoint)

## Introduction :wave: <a name="introduction"></a>
A .NET Console application designed to parse two Json files consisting of flight and hotel data, the app accepts a Json 'search' string as an input parameter and runs queries against the flight and hotel data and returns a list of 'best' matching results.

The project structure consists of the following:

 * HolidaySearcherApp
   * Models
   * Services
 * HolidaySearcherAppTests
   * Data
   * ServicesTests 

## :computer: Application Overview <a name="applicationOverview"></a>

The application consists of the following main components:

* FileLoader
* JsonParser
* Data Queryer
* Airport Code Merger
* Holiday Searcher

### ⚒️ Technologies Used <a name="technologiesUsed"></a>

<div>
<img align="left" alt="C#" title="C-Sharp" src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" />
<img align="left" alt=".NET 6" title=".NET 6" src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
</div>
</br></br>

### ❓ Query References <a name="QueryReference"></a>

#### Get Best Matching results when user wants to depart from a specific airport

| Query     | ReturnType                                            | Description                       |
| :-------- | :-----------------------------------------------------| :---------------------------------|
| `MAN`     | `ValueTuple<List<Flight>, List<Hotel> int TotalCost>` | Returns best matching results     |

#### Get Best Matching results when user wants to depart from any airport in a given city

| Query                    | ReturnType                                            | Description                       |
| :------------------------| :-----------------------------------------------------| :---------------------------------|
| `Any London Airport`     | `ValueTuple<List<Flight>, List<Hotel> int TotalCost>` | Returns best matching results     |

#### Get Best Matching results when user wants to depart from any airport

| Query     | ReturnType                                            | Description                       |
| :---------| :-----------------------------------------------------| :---------------------------------|
| `Any`     | `ValueTuple<List<Flight>, List<Hotel> int TotalCost>` | Returns best matching results     |

## ⭐ Pre-requisites <a name="prerequisites"></a>

* C# / .NET 6
* NuGet

## 🔀 Getting Started <a name="gettingStarted"></a>

### Application Setup <a name="applicationsetup"></a>

Fork this repo to your Github and then clone the forked version of this repo.

- Setup:
	- Open up project in Visual Studio
	- This application requires a path pointing to the data files. By default the path is set using the 'Visual Studio Default Working Directory' and returning its great grand-parent directory (project root folder). This now defaults to: [.\HolidaySearcherAppTests\Data](./HolidaySearcherAppTests/Data)
	 - If your 'Default Working Directory' is not set to application root '\bin\Debug\net6.0', then you will need to specify a new file path:
       - To change the filepath in the appliation, you will need to modify the path in the following file:
	      * [FileLoader.cs](https://github.com/Hayley96/HolidaySearcher/blob/main/HolidaySearcherApp/Services/FileLoader.cs)

### Restore Dependencies <a name="restoredependencies"></a>

- Open up a terminal and navigate to the root folder of the main application directory [HolidaySearcherApp](./HolidaySearcherApp):
 - run: `dotnet restore`

### Running the Unit Tests <a name="runningtests"></a>

- You can run the unit tests in Visual Studio, or you can go to your terminal and inside the root of this directory [HolidaySearcherApp](./HolidaySearcherApp):
 - run: `dotnet test`


### Main Entry Point <a name="mainentrypoint"></a>
- The Main Entry Point for the application is: [HolidaySearch.cs](https://github.com/Hayley96/HolidaySearcher/blob/main/HolidaySearcherApp/Services/HolidaySearch.cs)


## Thank you!! 👋

