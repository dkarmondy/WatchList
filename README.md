# WatchList - Watch Collection Manager

## Overview

**WatchList** is a web application designed to help users create, manage, and track their watch collections. Users can add watches, upload images, categorize them, and monitor details such as purchase price, condition, service history, and more. The app integrates with Azure services to handle image storage, notifications, background tasks, and monitoring.

### Key Features:
- **Add Watches to Collection**: Users can input details of watches, including brand, model, purchase date, and price.
- **Image Upload**: Upload images of watches, stored securely in Azure Blob Storage.
- **Track Watch History**: Monitor watch status, including service history and condition, via Azure Functions.
- **Search and Filter**: Easily search and filter watches by various attributes (e.g., brand, model, price range).
- **Notifications**: Get notified when a watch reaches a certain value or status, powered by Azure Functions.

## Architecture Overview

### Front-end and Back-End Services:
1. **Azure Web Apps**:
   - **Purpose**: Hosts both the frontend and backend of the application.
   - **Usage**:
   1. **Frontend**: Host the React web pages of this application, which the users can access via the browser
   2. **Backend**: The backend APIs handle the server-side logic, like user authentication, CRUD operations for watch data, and interaction with the database.


### Storage and Background Services:
1. **Azure Blob Storage**:
   - **Purpose**: Stores images of watches uploaded by users.
   - **Usage**: When a user uploads a watch image, it’s stored in Azure Blob Storage, and the URL is linked to the user's watch record in the database.

2. **Azure Functions**:
   - **Purpose**: Event-driven serverless, background tasks
   - **Usage**: 
      1. Upload event to process the image (e.g., resize, optimize, or generate thumbnail) of watch image and store in Azure Blob storage
      2. Store image metadata (file URL, size) in the database
      3. Background tasks like sending notifications

3. **Azure API Management**:
   - **Purpose**: Exposes backend APIs for managing watch data.
   - **Usage**: Creates RESTful APIs for the app to handle CRUD operations for watch details. API Management also secures, scales, and manages these APIs.

4. **Azure Service Bus**:
   - **Purpose**: Queues background tasks (e.g., image resizing, sending emails).
   - **Usage**: Asynchronous tasks like image processing or email notifications are queued and handled by Azure Functions via Service Bus.

5. **Azure Monitor**:
   - **Purpose**: Monitors app health, performance, and logs.
   - **Usage**: Logs various components of the app (APIs, functions, services) for tracking performance, errors, and user interactions.

## Simple User Flow

### 1. **User Adds a Watch**:
- The user enters details for a watch and uploads an image.
- The image is stored in Azure Blob Storage, and the details are saved in an Azure SQL Database.
- An Azure Function is triggered to calculate the value or notify the user if the watch is rare or has increased in value.

### 2. **User Views Collection**:
- The user can view their watch collection through the app's UI (via API calls).
- Watches can be filtered by criteria such as brand, model, or price.

### 3. **Notifications**:
- If there is a significant change in the value or status of a user's watch collection, an Azure Function sends a notification.

### 4. **Service Bus for Background Tasks**:
- Tasks like image resizing or sending emails are handled asynchronously by Azure Functions, triggered by requests in the Service Bus.

## Tech Stack

- **Frontend**: Angular (or React, based on preference)
- **Backend**: .NET Core API, with Azure Functions for handling background operations and notifications
- **Database**: Azure SQL Database to store watch details
- **Azure Services**:
  - Blob Storage: Image storage
  - Functions: Background tasks and notifications
  - API Management: API exposure, scaling, and security
  - Service Bus: Queued background tasks
  - Monitor: Health and performance monitoring

## Why This Project Works as a Learning Tool

### 1. **Comprehensive Use of Azure Services**:
  Gain hands-on experience with essential Azure services like Blob Storage, API Management, Functions, Service Bus, and Monitor. This demonstrates your ability to integrate multiple Azure components into a cohesive solution.

### 2. **Simple Yet Scalable**:
   While the functionality is straightforward, the project offers a robust foundation for learning about scalable architecture and can evolve into a more complex application with advanced features.

### 3. **Learning Opportunities**:
   - Integrating Azure services into an app architecture.
   - Managing background tasks and notifications via Azure Functions.
   - Using API Management to expose and scale backend services.
   - Utilizing Azure Monitor to track performance and errors in real-time.

## How to Run the Project Locally

### Prerequisites
- [Node.js](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)
- [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet)
- [Azure Subscription](https://azure.microsoft.com/en-us/free/) (for accessing Azure services like Blob Storage, Functions, etc.)

### Steps

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/dkarmondy/watchlist.git
   cd watchlist
