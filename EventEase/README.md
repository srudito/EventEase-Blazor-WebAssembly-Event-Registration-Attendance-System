# EventEase - Blazor WebAssembly Event Registration and Attendance System

EventEase is a Blazor WebAssembly web application for browsing events, viewing event details, registering participants, and tracking attendance. The project was developed as part of a three-activity assignment focused on using Microsoft Copilot to build, debug, optimize, and finalize a front-end event management application.

## Project Overview

EventEase is a fictional event management company that needs a web application where users can:

- Browse available corporate and social events.
- View event information such as name, date, location, and description.
- Navigate between the event list, event details, registration, and participant pages.
- Register for an event using a validated form.
- Track attendance and view registered participants.
- Handle invalid event routes gracefully.

This application demonstrates core Blazor WebAssembly concepts, including reusable components, routing, data binding, form validation, dependency injection, simple state management, and list rendering optimization.

## Features

### Event Browsing

- Displays a list of events using reusable event cards.
- Each event card shows the event name, date, and location.
- Users can navigate directly to event details or registration from each card.

### Event Details

- Provides a dedicated details page for each event.
- Shows event name, date, location, description, and registered attendee count.
- Includes links to register for the event or view participants.

### Registration Form

- Allows users to register for an event by entering their full name and email address.
- Uses Blazor form validation with data annotations.
- Validates required fields, name length, and email format.
- Prevents duplicate registration by checking the participant's full name.

### Attendance Tracker

- Stores participant records for each event.
- Tracks participant name, email, and registration timestamp.
- Displays registered participants in a table.
- Shows the total attendance count on the event details page.

### Session Tracking

- Uses a scoped `SessionService` to track the current user's name.
- Stores the event IDs registered by the current user during the session.

### Routing and Error Handling

- Supports routing for:
  - `/events`
  - `/events/{id}`
  - `/events/{id}/register`
  - `/events/{id}/participants`
  - `/not-found`
- Redirects users to a not-found page when an invalid event ID is requested.
- Includes fallback handling for unknown routes.

### Performance Optimization

- Uses Blazor's `Virtualize` component to improve event list rendering performance.
- Loads event data through an `ItemsProvider` pattern to support larger datasets more efficiently.

## Technologies Used

- Blazor WebAssembly
- C#
- .NET
- Razor Components
- Bootstrap
- Microsoft Copilot

## Project Structure

```text
EventEase/
├── Components/
│   ├── EventCard.razor
│   └── EventModel.cs
├── Layout/
│   ├── MainLayout.razor
│   ├── MainLayout.razor.css
│   ├── NavMenu1.razor
│   └── NavMenu1.razor.css
├── Pages/
│   ├── About.razor
│   ├── EventDetails.razor
│   ├── Events.razor
│   ├── Home.razor
│   ├── NotFound.razor
│   ├── Participants.razor
│   ├── Register.razor
│   └── Weather.razor
├── Services/
│   ├── EventService.cs
│   └── SessionService.cs
├── wwwroot/
│   ├── css/
│   │   └── app.css
│   └── index.html
├── App.razor
├── Program.cs
└── EventEase.csproj
```

## Main Components and Services

### `EventCard.razor`

A reusable component that displays event information in a Bootstrap card. It validates that the event data is available and contains required values before rendering the event details.

### `EventModel.cs`

Defines the event data model with properties for:

- Event ID
- Name
- Date
- Location
- Description

The model uses data annotation attributes such as `Required` and `MinLength`.

### `EventService.cs`

Provides mock event data and attendance management logic, including:

- Retrieving all events.
- Retrieving a single event by ID.
- Registering participants.
- Preventing duplicate registrations.
- Returning participant lists.
- Returning attendance counts.

### `SessionService.cs`

Stores simple user session data, including the current user's name and the list of events registered during the session.

## Getting Started

### Prerequisites

Make sure the following tools are installed:

- Visual Studio 2022 or later, or Visual Studio Code
- .NET SDK compatible with the project target framework
- A modern web browser

> Note: The current project file targets `net10.0` and references `Microsoft.AspNetCore.Components.WebAssembly` version `10.0.0`. If you do not have a compatible .NET SDK installed, update the target framework and package versions to match your installed SDK before running the app.

### Run the Application

1. Clone the repository:

```bash
git clone https://github.com/your-username/EventEase-Blazor-WebAssembly-Event-Registration-Attendance-System.git
```

2. Navigate to the project folder:

```bash
cd EventEase-Blazor-WebAssembly-Event-Registration-Attendance-System/EventEase
```

3. Restore dependencies:

```bash
dotnet restore
```

4. Run the application:

```bash
dotnet run
```

5. Open the local URL shown in the terminal, usually:

```text
https://localhost:5001
```

or

```text
http://localhost:5000
```

## How to Use the App

1. Open the application in a browser.
2. Go to the Events page.
3. Browse the list of available events.
4. Select Details to view full event information.
5. Select Register to open the registration form.
6. Enter a valid full name and email address.
7. Submit the form to register for the event.
8. Open the Participants page to view registered attendees.

## Testing Summary

The application was tested for the following scenarios:

- Event cards display valid event name, date, and location.
- Invalid or missing event data displays a warning message.
- Navigation works between event list, details, registration, and participant pages.
- Invalid event IDs redirect to the not-found page.
- Registration form validates empty name, invalid email, and invalid name length.
- Duplicate participant names are not registered twice for the same event.
- Attendance count updates after successful registration.
- Participant list displays registered users with timestamps.
- Event list rendering remains responsive by using virtualization.

## Assignment Activities Completed

### Activity 1: Foundation

- Created the Event Card component.
- Added event fields for name, date, and location.
- Implemented dynamic data binding using an event model.
- Added mock event data through a service.
- Set up routing between event list, details, and registration pages.

### Activity 2: Debugging and Optimization

- Added validation to prevent invalid event data from being rendered incorrectly.
- Added not-found handling for invalid routes and missing event IDs.
- Improved event list performance with Blazor virtualization.
- Tested edge cases for routing, invalid inputs, and larger event lists.

### Activity 3: Expansion and Finalization

- Added a validated registration form.
- Added session tracking through a scoped session service.
- Added attendance tracking and participant records.
- Added a participants page to view event attendees.
- Cleaned up the codebase for a more production-ready structure.

## How Microsoft Copilot Assisted

Microsoft Copilot was used throughout the development process to speed up implementation and improve code quality:

- Suggested the initial structure for the reusable Event Card component.
- Helped create model properties and data-binding syntax.
- Assisted with Blazor routing patterns for event list, details, and registration pages.
- Suggested validation improvements for event data and registration input.
- Helped identify routing edge cases and improve invalid route handling.
- Recommended using Blazor's `Virtualize` component to improve performance for large event lists.
- Assisted in creating the session tracking and attendance tracking logic.
- Helped refine the final code structure and prepare the application for GitHub submission.

## Future Improvements

Possible future enhancements include:

- Store events and participants in a database.
- Add authentication and user accounts.
- Add event creation and editing features for administrators.
- Add search, filtering, and sorting for events.
- Add confirmation emails after registration.
- Improve the UI with a more customized design.
- Add automated unit and component tests.

## License

This project was created for educational purposes as part of a Blazor WebAssembly assignment.