# Playwright-csharp

* **`ApplicationTest`**: This project contains the Playwright tests. It references the `Framework` project for common utilities and setup.
* **`Framework`**: This project provides reusable components, drivers, and helper functions for the tests.
* **`docker-compose.yml`**: This file defines the Docker configuration for running the tests in a containerized environment.
* **.gitignore**: This file excludes build artifacts (`bin`, `obj`) and other unnecessary files from being tracked by Git.
* **.github/workflows/dotnet.yml**: This GitHub Actions workflow automates the build and test execution in a CI/CD pipeline.

## Prerequisites

Before you can run the tests, ensure you have the following installed:

* **.NET SDK 8.0**:  Download and install the .NET SDK 8.0 from the official [.NET website](https://dotnet.microsoft.com/download/dotnet/8.0).
* **A suitable IDE or Text Editor**: (e.g., Visual Studio, Visual Studio Code, Rider).
* **Git**:  Install Git from the official [Git website](https://git-scm.com/downloads).

## Local Setup and Execution

### Installation

1.  **Clone the repository:**

    ```bash
    git clone https://github.com/Arunkumar-Arivazhagan/Playwright-Csharp.git
    cd Playwright-csharp
    ```

2.  **Restore NuGet packages:**

    ```bash
    dotnet restore ApplicationTest/ApplicationTest.csproj
    ```

    This command downloads all the necessary dependencies for the `ApplicationTest` project.

### Running Tests Locally

1.  **Navigate to the test project directory:**

    ```bash
    cd ApplicationTest
    ```

2.  **Build the test project:**

    ```bash
    dotnet build
    ```

3.  **Run the tests:**

    ```bash
    dotnet test
    ```

    This command will execute all the tests defined in the `ApplicationTest` project.  You can add additional parameters to filter tests or specify the test runner output format.  Refer to the `dotnet test` documentation for more options.

## Docker Setup and Execution

### Docker Installation

1.  **Install Docker Desktop:** Download and install Docker Desktop from the official [Docker website](https://www.docker.com/products/docker-desktop). Follow the installation instructions for your operating system (Windows, macOS).

### Building and Running with Docker Compose

1.  **Navigate to the project root directory:**

    ```bash
    cd Playwright-csharp
    ```

2.  **Build and run the Docker container using Docker Compose:**

    ```bash
    docker-compose up --build
    ```

    This command will:

    * Build the Docker image based on the `docker-compose.yml` configuration.
    * Start the container.
    * Execute the Playwright tests within the container.

    The test results will be displayed in the console output.

## GitHub Actions Integration

The repository includes a GitHub Actions workflow (`.github/workflows/dotnet.yml`) to automate the build and test execution whenever code is pushed to the `main` branch or a pull request is created against it.

* The workflow uses the `mcr.microsoft.com/playwright/dotnet` Docker image, which comes with the necessary Playwright browsers and dependencies pre-installed.
* It restores, builds, and runs the tests within the container in the GitHub Actions environment.

## Reporting
* Playwright with C# does not have a Reporting system (like playwright with typescript), but third party reporting framework like Extent Reports can be added. Those are effective if the code is written in BDD fashion.

## Contributing

Contributions to this project are welcome! Please follow these guidelines:

1.  Fork the repository.
2.  Create a new branch for your feature or bug fix.
3.  Make your changes and write clear, concise commit messages.
4.  Test your changes thoroughly.
5.  Create a pull request against the `main` branch.