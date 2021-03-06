﻿#I "../../../bin/XPlot.GoogleCharts.Deedle/netstandard2.0"
#r "Deedle.dll"
#r "XPlot.GoogleCharts.dll"
#r "XPlot.GoogleCharts.Deedle.dll"

open Deedle
open XPlot.GoogleCharts

type Correlation =
    {
        country : string
        lifeExpectancy : float
        fertilityRate : float
        region : string
        population : int
    }

    static member New (c, l, f, r, p) =
        {
            country = c
            lifeExpectancy = l
            fertilityRate = f
            region = r
            population = p
        }

let data =
    [
        "CAN", 80.66, 1.67, "North America", 33739900
        "DEU", 79.84, 1.36, "Europe", 81902307
        "DNK", 78.6, 1.84, "Europe", 5523095
        "EGY", 72.73, 2.78, "Middle East", 79716203
        "GBR", 80.05, 2., "Europe", 61801570
        "RUS", 68.6, 1.54, "Europe", 141850000
        "USA", 78.09, 2.05, "North America", 307007000
    ]
    |> List.map Correlation.New

let options =
    Options(
        title = "Correlation between life expectancy, fertility rate and population of some world countries (2010)",
        hAxis = Axis(title = "Life Expectancy"),
        vAxis = Axis(title = "Fertility Rate"),
        bubble = Bubble(textStyle = TextStyle(fontSize = 11))
    )

let chart1 =
    data
    |> Frame.ofRecords
    |> Frame.indexRowsString "country"     
    |> Chart.Bubble
    |> Chart.WithOptions options
    |> Chart.WithLabels ["Life Expectancy"; "Fertility Rate"; "Region"; "Population"]
    |> Chart.WithLegend true
    |> Chart.Show
