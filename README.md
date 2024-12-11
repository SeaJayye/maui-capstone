<h1 align="center">Don't Burn it! </h1>

## Table of Contents
1. [Features](#features)
2. [Development Stack](#development-stack)
3. [Installation and Setup](#installation-and-setup)
4. [App Structure](#app-structure)
5. [Usage Instruction](#usage-instruction)
6. [UI Details](#ui-details)

## Documentation
[Dont Burn It Doc.pdf](https://github.com/user-attachments/files/18089782/Dont.Burn.It.Doc.pdf)


### Core Functionalities of this program

- **Multi-Timer Support**:

    - Have multiple timers running at the same time for different dishes
    
    - Active timers are displayed and has a scrollable layout

    - Has synchronous timers so everything will end at the same time

- **Two-Page App layout**:

    - Main page is for viewing all the active timers

    - Timer detail page is the page for detailed timer information

- **Responsive Design**:

    - Adapts to varying screen sizes using grids and stack layouts

    - Optimized for both portrait and landscape orientations

- **Customizable themes and fonts**:

    - Uses a cohesive color palette from "Styles.xaml" and "Colors.xaml"

    - Includes different fonts for a more moderns and professional look

- **Clean Navigation**:

    - Built to have a smooth navigation with room for future scalability

## Development Stack

1. **.NET MAUI**: A cross-platform framework for building apps

2. **XAML**: XML-based language for defining user interfaces

3. **C#**: Language of coding, handles application logistics

4. **Custom Resource Dictionaries**:
    
    - *Colors.xaml* is for defining a consisten color palette

    - *Styles.xaml* for reusable styles and formatting across the app 

## Installation and Setup

### Prerequisites

    - Visual Studio 2022 or later with .NET MAUI installed

    - Android emulator or other testing device

    - .NET 6 SDK or higher

### Steps to Install

    1. Clone the repository

    2. Open the project in Visual Studios

    3. Restore dependencies using:
        -dotnet restore

    4. Choose a target device or emulator in Visual Studios

    5. Run the app using:
        -dotnet build
        -dotnet run

## App Structure

1. *App.xaml*:

    - Declares application-wide resources like styles and colors

    - Combines dictionaries (Colors.xaml and Styles.xaml) for easy maintenance

2. *AppShell.xaml*:

    - Configures the apps navigation structure

    - Ensures clean and minimal navigation

3. *MainPage.xaml*:

    - Implements the primary user interface for viewing and interacting with timers

    - Uses a grid based layout for displaying timers 

4. *MauiProgram.cs*:

    - Handles app initializations, including fonts, styles and debugging

5. *TimerCreate.xaml.cs*:

    - Allows the user to manage the timers and handeling the logics

6. *TimerViewmodel.cs*:

    -  Manages a collection of timers and their properties in a structured and observable way

6. *Resources/Styles/Colors.xaml and Styles.xaml*:
    - Defines visual properties for a consisten and professional appearence

## Usage Instruction

1. Home Page Overview:

    - The home page greets the user with the message: "What's cooking, chef?"

    - Active timers will be displayed in a scrollable grid

2. Timer Interaction:

    - You can add timers for different dishes you wish to cook

    - Can stop all timers at once 

    - Have multiple timers running at once

    - Manage timers in many different ways

3. Grid Layout:

    - The top half of the screen is reserved for timers

    - the bottom sections provides information about active timers

## UI Details

1. Grid-Based Layout:

    - Rows split evenly for a balanced design

    - Ensure timers are displayed side by side for visibility

2. ScrollView Integration

    - Ensures that all timers can be viewed easily

3. Typography

    - Headers use bold large fonts to grab attention

    - Active timer labels are centered for readability

4. Colors and Themes

    - Background color: White for a clean interface

    - Text colors and fonts are defined in Styles.xaml








